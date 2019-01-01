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

        private PlaylistViewModel PlaylistVM { get { return ParentVM.PlaylistVM; } }

        public PlayerViewModel(MainViewModel parent) : base(parent)
        {
            player = new Player();
        }



        public PlaylistItem LoadedItem { get { return PlaylistVM.SelectedItem; } }

        public Player.PlayerStatus Status { get { return player.Status; } }

        public bool IsPlaying { get { return Status != Player.PlayerStatus.Idle; } }

        public double Volume
        {
            get { return player.Volume; }
            set { player.SetVolume(value); }
        }


        public void Play()
        {
            if (!PlaylistVM.AreThereItems)
                return;
            player.Play(LoadedItem.Path);
            notifyAll();
        }

        public void Stop()
        {
            player.Stop();
            notifyAll();
        }

        public void Next()
        {
            if (thereIsNoNextItem)
                return;
            bool itWasPlaying = IsPlaying;
            Stop();
            PlaylistVM.SelectNextItem();
            if (itWasPlaying)
                Play();
            notifyAll();
        }

        public void Previous()
        {
            if (thereIsNoPreviousItem)
                return;
            bool itWasPlaying = IsPlaying;
            Stop();
            PlaylistVM.SelectPreviousItem();
            if (itWasPlaying)
                Play();
            notifyAll();
        }



        private void notifyAll()
        {
            NotifyOfPropertyChange(() => Status);
            NotifyOfPropertyChange(() => IsPlaying);
            NotifyOfPropertyChange(() => LoadedItem);
        }

        private bool thereIsNoNextItem { get { return LoadedItem == PlaylistVM.Items.Last(); } }

        private bool thereIsNoPreviousItem { get { return LoadedItem == PlaylistVM.Items.First(); } }

    }
}
