using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WR_Player.Models;

namespace WR_Player.ViewModels
{
    class PlayerViewModel : PropertyChangedBase
    {

        public PlayerViewModel()
        {
            player = new Player();

            SelectedStream = new Stream("web radio name 95,7", "http://46.4.37.132:9382");//TODO
        }

        private Player player;

        public Player.PlayerStatus Status
        {
            get { return player.Status; }
        }

        //TODO: move it into StreamsViewModel
        private Stream _selectedStream;
        public Stream SelectedStream
        {
            get { return _selectedStream; }
            set
            {
                _selectedStream = value;
                NotifyOfPropertyChange(() => SelectedStream);
            }
        }

        public double Volume
        {
            get { return player.Volume; }
            set { player.SetVolume(value); }
        }

        public void Play()
        {
            player.Play(SelectedStream.Url);
            refresh();
        }

        public void Stop()
        {
            player.Stop();
            refresh();
        }

        public void Next()
        {
            //TODO
        }

        public void Previous()
        {
            //TODO
        }

        //TODO: better name?
        private void refresh()
        {
            NotifyOfPropertyChange(() => Status);
        }
    }
}
