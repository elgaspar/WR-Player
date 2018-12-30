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
            New();
        }



        public ObservableCollection<PlaylistItem> Items { get { return playlist.Items; } }

        public bool AreThereItems { get { return playlist.AreThereItems; } }

        public PlaylistItem SelectedItem { get { return playlist.SelectedItem; } }



        public void New()
        {
            if (ParentVM.PlayerVM != null)
                ParentVM.PlayerVM.Stop();
            playlist = new Playlist();
            filepath = null;
            NotifyOfPropertyChange(() => Items);
        }

        public bool Save(string filepath)
        {
            this.filepath = filepath;
            return playlist.SaveToFile(filepath);
        }

        public bool Load(string filepath)
        {
            this.filepath = filepath;
            ParentVM.PlayerVM.Stop();
            bool succeed = playlist.LoadFromFile(filepath);
            NotifyOfPropertyChange(() => Items);
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
    }
}
