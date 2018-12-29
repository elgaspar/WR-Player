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

            //TODO: values for debugging only
            Playlist.Items.Add(new PlaylistItem("1-kritikorama", "http://46.4.37.132:9382"));
            Playlist.Items.Add(new PlaylistItem("2-derti", "http://derti.live24.gr:80/derty1000"));
            Playlist.Items.Add(new PlaylistItem("3-mousikos", "http://netradio.live24.gr:80/mousikos986"));
            Playlist.Items.Add(new PlaylistItem("4-dromos", "http://dromos898.live24.gr:80/dromos898"));
        }

    }
}
