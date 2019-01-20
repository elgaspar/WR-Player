using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
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

            ItemsToProcess = new ObservableCollection<PlaylistItem>();
            ItemsToProcess.CollectionChanged += ItemsToProcess_Changed;
        }



        public string Filepath { get; private set; }

        public bool AnyChangeHappened { get; set; }

        public ObservableCollection<PlaylistItem> ItemsToProcess { get; }

        public ReadOnlyObservableCollection<PlaylistItem> Items { get { return playlist.Items; } }

        public bool AreThereItems { get { return playlist.AreThereItems; } }

        public PlaylistItem SelectedItem { get { return playlist.SelectedItem; } }

        public bool IsPlaylistFileOpen { get { return !string.IsNullOrEmpty(Filepath); } }

        public bool CanPlay { get { return ItemsToProcess.Count == 1; } }

        public bool CanEdit { get { return ItemsToProcess.Count == 1; } }

        public bool CanRemove { get { return ItemsToProcess.Count > 0; } }



        public void New()
        {
            stopPlaying();
            initPlaylist();
            notifyAll();
        }
        
        public bool Save()
        {
            bool success = playlist.SaveToFile(Filepath);
            if (success)
                AnyChangeHappened = false;
            return success;
        }

        public bool SaveAs(string path)
        {
            bool success = playlist.SaveToFile(path);
            if (success)
            {
                Filepath = path;
                AnyChangeHappened = false;
            }
            return success;
        }

        public bool Load(string path)
        {
            stopPlaying();
            bool success = playlist.LoadFromFile(path);
            if (success)
            {
                Filepath = path;
            }
            AnyChangeHappened = false;
            notifyAll();
            return success;
        }



        public void SelectNextItem()
        {
            playlist.SelectNextItem();
        }

        public void SelectPreviousItem()
        {
            playlist.SelectPreviousItem();
        }



        public void AddFile(string path)
        {
            PlaylistItem newItem = new PlaylistItem(createTitleFromPath(path), path);
            AddItem(newItem);
        }

        public void AddItem(PlaylistItem item)
        {
            playlist.Add(item);
            AnyChangeHappened = true;
            notifyAll();
        }

        public void EditItem(string newTitle, string newPath)
        {
            PlaylistItem itemToEdit = ParentVM.PlaylistVM.ItemsToProcess[0];

            bool wasPlaying = PlayerVM.IsPlaying;
            bool editedItemWasLoadedOnPlayer = (PlayerVM.LoadedItem == itemToEdit);
            bool pathChanged = (itemToEdit.Path != newPath);

            itemToEdit.Path = newPath;
            itemToEdit.Title = newTitle;

            if (wasPlaying && editedItemWasLoadedOnPlayer && pathChanged)
                PlayerVM.Play();

            AnyChangeHappened = true;
            notifyAll();
        }

        public void RemoveSelectedItems()
        {
            if (ItemsToProcess.Contains(SelectedItem))
                stopPlaying();

            for (int i = ItemsToProcess.Count - 1; i >= 0; i--)
                playlist.Remove(ItemsToProcess[i]);

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

        public void SetSelectedItem()
        {
            playlist.SelectItem(ItemsToProcess[0]);
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

        private string createTitleFromPath(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }

        private void notifyAll()
        {
            NotifyOfPropertyChange(() => Items);
            NotifyOfPropertyChange(() => SelectedItem);
            NotifyOfPropertyChange(() => AreThereItems);
            ParentVM.PlayerVM.notifyAll();
        }

        private void ItemsToProcess_Changed(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyOfPropertyChange(() => CanPlay);
            NotifyOfPropertyChange(() => CanEdit);
            NotifyOfPropertyChange(() => CanRemove);
        }
    }
}
