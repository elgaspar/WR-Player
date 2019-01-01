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

        private string filepath;

        public PlaylistViewModel(MainViewModel parent) : base(parent)
        {
            initPlaylist();
        }



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

        public bool isPlaylistFileOpen { get { return !string.IsNullOrEmpty(filepath); } }

        public bool CanSave { get { return playlist.Items.Count > 0; } }

        public bool CanEditRemove { get { return ItemToProcess != null; } }

        public void New()
        {
            stopPlaying();
            initPlaylist();
            notifyAll();
        }

        
        public bool Save()
        {
            return playlist.SaveToFile(filepath);
        }

        public bool SaveAs(string path)
        {
            bool succeed = playlist.SaveToFile(path);
            if (succeed)
                this.filepath = path;
            return succeed;
        }

        public bool Load(string path)
        {
            stopPlaying();
            bool succeed = playlist.LoadFromFile(path);
            if (succeed)
                this.filepath = path;
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


        public void AddStream(PlaylistItem stream)
        {
            playlist.Add(stream);
            notifyAll();
        }

        public void RemoveStream()
        {
            if (ItemToProcess == SelectedItem)
                stopPlaying();
            playlist.Remove(ItemToProcess);
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
            filepath = null;
        }

        private void notifyAll()
        {
            NotifyOfPropertyChange(() => Items);
            NotifyOfPropertyChange(() => CanSave);
            NotifyOfPropertyChange(() => SelectedItem);
        }
    }
}
