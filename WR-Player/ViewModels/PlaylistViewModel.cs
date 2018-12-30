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
        private Playlist playlist { get; }

        public string Filepath { get; set; }

        public PlaylistViewModel(MainViewModel parent) : base(parent)
        {
            playlist = new Playlist();
        }



        public ObservableCollection<PlaylistItem> Items { get { return playlist.Items; } }

        public bool AreThereItems { get { return playlist.AreThereItems; } }

        public PlaylistItem SelectedItem { get { return playlist.SelectedItem; } }



        public void SelectNextItem()
        {
            playlist.SelectNextItem();
        }

        public void SelectPreviousItem()
        {
            playlist.SelectPreviousItem();
        }

        public bool Save(string filepath)
        {
            return playlist.SaveToFile(filepath);
        }

        public bool Load(string filepath)
        {
            ParentVM.PlayerVM.Stop();
            return playlist.LoadFromFile(filepath);
        }
    }
}
