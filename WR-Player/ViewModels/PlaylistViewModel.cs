using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WR_Player.Models;

namespace WR_Player.ViewModels
{
    public class PlaylistViewModel : ViewModelBase
    {
        private Playlist playlist;

        private PlayerViewModel PlayerVM { get { return ParentVM.PlayerVM; } }

        public PlaylistViewModel(MainViewModel parent) : base(parent)
        {
            initPlaylist();
        }



        public string Filepath { get; private set; }

        public bool AnyChangeHappened { get; set; }

        private PlaylistItem _itemToProcess;
        public PlaylistItem ItemToProcess
        {
            get { return _itemToProcess; }
            set
            {
                _itemToProcess = value;
                NotifyOfPropertyChange(() => ItemToProcess);
                NotifyOfPropertyChange(() => CanEditRemove);
            }
        }

        public ReadOnlyObservableCollection<PlaylistItem> Items { get { return playlist.Items; } }

        public bool AreThereItems { get { return playlist.AreThereItems; } }

        public PlaylistItem SelectedItem { get { return playlist.SelectedItem; } }

        public bool IsPlaylistFileOpen { get { return !string.IsNullOrEmpty(Filepath); } }

        public bool CanEditRemove { get { return ItemToProcess != null; } }

        public void New()
        {
            stopPlaying();
            initPlaylist();
            notifyAll();
        }

        
        public bool Save()
        {
            bool succeed = playlist.SaveToFile(Filepath);
            if (succeed)
                AnyChangeHappened = false;
            return succeed;
        }

        public bool SaveAs(string path)
        {
            bool succeed = playlist.SaveToFile(path);
            if (succeed)
            {
                Filepath = path;
                AnyChangeHappened = false;
            }
            return succeed;
        }

        public bool Load(string path)
        {
            stopPlaying();
            bool succeed = playlist.LoadFromFile(path);
            if (succeed)
            {
                Filepath = path;
            }
            AnyChangeHappened = false;
            notifyAll();
            return succeed;
        }


        public void SelectNextItem()
        {
            playlist.SelectNextItem();
        }

        public void SelectPreviousItem()
        {
            playlist.SelectPreviousItem();
        }


        public void AddItem(PlaylistItem item)
        {
            playlist.Add(item);
            AnyChangeHappened = true;
            notifyAll();
        }

        //TODO: it is not used yet. Do i need edit only for urls?
        public void EditUrl(string newTitle, string newPath)
        {
            PlaylistItem itemToEdit = ParentVM.PlaylistVM.ItemToProcess;

            bool wasPlaying = PlayerVM.IsPlaying;
            bool editedItemWasLoadedOnPlayer = (PlayerVM.LoadedItem == itemToEdit);
            bool pathChanged = (itemToEdit.Path != newPath);

            itemToEdit.Title = newTitle;
            itemToEdit.Path = newPath;

            if (wasPlaying && editedItemWasLoadedOnPlayer && pathChanged)
                PlayerVM.Play();

            AnyChangeHappened = true;
            notifyAll();
        }

        public void RemoveSelectedItem()
        {
            if (ItemToProcess == SelectedItem)
                stopPlaying();
            playlist.Remove(ItemToProcess);
            AnyChangeHappened = true;
            notifyAll();
        }

        public void RemoveAllItems()
        {
            stopPlaying();
            playlist.Clear();
            AnyChangeHappened = true;
            notifyAll();
        }


        private void stopPlaying()
        {
            if (ParentVM.PlayerVM != null)
                ParentVM.PlayerVM.Stop();
        }

        private void initPlaylist()
        {
            playlist = new Playlist();
            Filepath = null;
            AnyChangeHappened = false;
        }

        private void notifyAll()
        {
            NotifyOfPropertyChange(() => Items);
            NotifyOfPropertyChange(() => SelectedItem);
            NotifyOfPropertyChange(() => AreThereItems);
        }
    }
}
