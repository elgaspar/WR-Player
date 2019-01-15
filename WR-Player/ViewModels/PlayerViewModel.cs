using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
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

            player.PlaybackStarted += NotifyStatus;
            player.PlaybackFinished += Player_PlaybackFinished;
            player.PlaybackError += NotifyStatus;
        }


        public PlaylistItem LoadedItem { get { return PlaylistVM.SelectedItem; } }

        public Player.PlayerStatus Status { get { return player.Status; } }





        public int DurationInSeconds
        {
            get
            {
                if (player.DurationInSeconds == -1)
                    return 1;
                return player.DurationInSeconds;
            }
        }

        public int PositionInSeconds
        {
            get { return player.PositionInSeconds; }
            set
            {
                player.PositionInSeconds = value;
                NotifyOfPropertyChange(() => PositionInSeconds);
            }
        }




        private bool _isPlaying;
        public bool IsPlaying
        {
            get
            {
                return _isPlaying;
            }
            private set
            {
                _isPlaying = value;
                NotifyOfPropertyChange(() => IsPlaying);
            }
        }

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
            IsPlaying = true;
            if (LoadedItem.Type != AudioType.Url)
                enablePositionNotifier();
            notifyAll();
        }

        public void Stop()
        {
            if (!IsPlaying)
                return;
            player.Stop();
            IsPlaying = false;
            disablePositionNotifier();
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






        private Timer positionNotifierTimer;

        private void enablePositionNotifier()
        {
            if (positionNotifierTimer != null)
                positionNotifierTimer.Dispose();
            positionNotifierTimer = new Timer();
            positionNotifierTimer.Elapsed += new ElapsedEventHandler(notifyPosition);
            positionNotifierTimer.Interval = 100;
            positionNotifierTimer.Enabled = true;


            NotifyOfPropertyChange(() => PositionInSeconds);
            NotifyOfPropertyChange(() => DurationInSeconds);
        }

        private void disablePositionNotifier()
        {
            if (positionNotifierTimer!=null)
                positionNotifierTimer.Dispose();
        }

        private void notifyPosition(object source, ElapsedEventArgs e)
        {
            NotifyOfPropertyChange(() => PositionInSeconds);
            NotifyOfPropertyChange(() => DurationInSeconds);
        }




        

        

        private void notifyAll()
        {
            NotifyOfPropertyChange(() => Status);
            NotifyOfPropertyChange(() => IsPlaying);
            NotifyOfPropertyChange(() => LoadedItem);
            NotifyOfPropertyChange(() => PositionInSeconds);
            NotifyOfPropertyChange(() => DurationInSeconds);
        }

        private bool thereIsNoNextItem { get { return !PlaylistVM.AreThereItems || LoadedItem == PlaylistVM.Items.Last(); } }

        private bool thereIsNoPreviousItem { get { return !PlaylistVM.AreThereItems || LoadedItem == PlaylistVM.Items.First(); } }




        private void NotifyStatus(object sender, EventArgs e)
        {
            NotifyOfPropertyChange(() => Status);
            NotifyOfPropertyChange(() => IsPlaying);
        }

        private void Player_PlaybackFinished(object sender, EventArgs e)
        {
            if (thereIsNoNextItem)
            {
                Stop();
                Console.WriteLine("Playback finished: No next item to load.");//TODO: deleteme
                NotifyStatus(null, null);
                return;
            }
            Next();
            Console.WriteLine("Playback finished: Next item loaded.");//TODO: deleteme
        }

    }
}
