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

        public string Filepath { get; private set; }

        public PlaylistViewModel(MainViewModel parent) : base(parent)
        {
            initPlaylist();
        }



        public ObservableCollection<PlaylistItem> Items { get { return playlist.Items; } }

        public bool AreThereItems { get { return playlist.AreThereItems; } }

        public PlaylistItem SelectedItem { get { return playlist.SelectedItem; } }



        public void New()
        {
            stopPlaying();
            initPlaylist();
            notifyAll();
        }

        public bool CanSave { get { return playlist.Items.Count > 0; } }

        public bool Save()
        {
            return playlist.SaveToFile(Filepath);
        }

        public bool SaveAs(string path)
        {
            this.Filepath = path;
            return playlist.SaveToFile(path);
        }

        public bool Load(string path)
        {
            this.Filepath = path;
            stopPlaying();
            bool succeed = playlist.LoadFromFile(path);
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



        private void stopPlaying()
        {
            if (ParentVM.PlayerVM != null)
                ParentVM.PlayerVM.Stop();
        }

        private void initPlaylist()
        {
            playlist = new Playlist();
            Filepath = null;
        }

        private void notifyAll()
        {
            NotifyOfPropertyChange(() => Items);
            NotifyOfPropertyChange(() => CanSave);
        }
    }
}
