using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WR_Player.Models;

namespace WR_Player.ViewModels
{
    class MainViewModel : PropertyChangedBase
    {

        public MainViewModel()
        {
            player = new Player();
        }

        private Player player;


        public double Volume
        {
            get { return player.Volume; }
            set
            {
                player.SetVolume(value);
                //NotifyOfPropertyChange(() => Volume);
            }
        }

        public void Play()
        {
            player.Play("http://46.4.37.132:9382");
        }

        public void Stop()
        {
            player.Stop();
        }

        public void Next()
        {
            //TODO
        }

        public void Previous()
        {
            //TODO
        }

    }
}
