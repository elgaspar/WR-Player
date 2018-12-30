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
        public Playlist Playlist { get; }

        public PlaylistViewModel(MainViewModel parent) : base(parent)
        {
            Playlist = new Playlist();
        }

    }
}
