using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WR_Player.Models;

namespace WR_Player.ViewModels
{
    public class PlayerViewModel : ViewModelBase
    {
        private Player player;

        private Playlist playlist { get { return ParentVM.PlaylistVM.Playlist; } }

        public PlayerViewModel(MainViewModel parent) : base(parent)
        {
            player = new Player();
        }



        public PlaylistItem LoadedItem { get { return playlist.SelectedItem; } }

        public Player.PlayerStatus Status { get { return player.Status; } }

        public double Volume
        {
            get { return player.Volume; }
            set { player.SetVolume(value); }
        }


        public void Play()
        {
            if (!playlist.AreThereItems)
                return;
            player.Play(LoadedItem.Path);
            NotifyOfPropertyChange(() => Status);
            NotifyOfPropertyChange(() => LoadedItem);
        }

        public void Stop()
        {
            player.Stop();
            NotifyOfPropertyChange(() => Status);
        }

        public void Next()
        {
            if (LoadedItem == playlist.Items.Last())
                return;
            bool isPlaying = player.Status != Player.PlayerStatus.Idle;
            Stop();
            playlist.SelectNextItem();
            if (isPlaying)
                Play();
            NotifyOfPropertyChange(() => LoadedItem);
        }

        public void Previous()
        {
            if (LoadedItem == playlist.Items.First())
                return;
            bool isPlaying = player.Status != Player.PlayerStatus.Idle;
            Stop();
            playlist.SelectPreviousItem();
            if (isPlaying)
                Play();
            NotifyOfPropertyChange(() => LoadedItem);
        }

    }
}
