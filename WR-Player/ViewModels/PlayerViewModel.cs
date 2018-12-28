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
    class PlayerViewModel : ViewModelBase
    {
        private Player player;

        public PlayerViewModel(MainViewModel parent) : base(parent)
        {
            player = new Player();

            loadFirstStream();//TODO
        }


        public Stream LoadedStream
        {
            get
            {
                if (LoadedStreamIndex < 0)
                    return null;
                return ParentVM.StreamsVM.Streams[LoadedStreamIndex];
            }
        }

        private int _loadedStreamIndex;
        public int LoadedStreamIndex
        {
            get { return _loadedStreamIndex; }
            set
            {
                if (value >= ParentVM.StreamsVM.Streams.Count || value < 0)
                    return;
                ParentVM.StreamsVM.MarkStreamAsSelected(value);
                _loadedStreamIndex = value;
                NotifyOfPropertyChange(() => LoadedStream);
            }
        }

        public Player.PlayerStatus Status { get { return player.Status; } }

        public double Volume
        {
            get { return player.Volume; }
            set { player.SetVolume(value); }
        }


        public void Play()
        {
            if (!ParentVM.StreamsVM.AreThereStreams)
                return;
            player.Play(LoadedStream.Url);
            NotifyOfPropertyChange(() => Status);
        }

        public void Stop()
        {
            player.Stop();
            NotifyOfPropertyChange(() => Status);
        }

        public void Next()
        {
            if (LoadedStreamIndex == ParentVM.StreamsVM.Streams.Count - 1)
                return;
            bool isPlaying = player.Status != Player.PlayerStatus.Idle;
            Stop();
            loadNextStream();
            if (isPlaying)
                Play();
        }

        public void Previous()
        {
            if (LoadedStreamIndex <= 0)
                return;
            bool isPlaying = player.Status != Player.PlayerStatus.Idle;
            Stop();
            loadPreviousStream();
            if (isPlaying)
                Play();
        }

        private void loadFirstStream()
        {
            LoadedStreamIndex = 0;
        }

        private void loadNextStream()
        {
            LoadedStreamIndex++;
        }

        private void loadPreviousStream()
        {
            LoadedStreamIndex--;
        }

    }
}
