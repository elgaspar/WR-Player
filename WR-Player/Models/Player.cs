using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WR_Player.Models
{
    class Player
    {
        public double Volume { get; private set; }
        public bool IsPlaying { get; private set; } //TODO: do i need this?

        private MediaPlayer player;

        public Player()
        {
            player = new MediaPlayer();
            Volume = 0.5;
        }

        public void Play(string Url)
        {
            player.Close();
            player.Open(new Uri(Url));
            player.Play();
            player.Volume = Volume;

            IsPlaying = true;
        }

        public void Stop()
        {
            player.Stop();
            IsPlaying = false;
        }

        public void SetVolume(double vol)
        {
            Volume = vol;
            player.Volume = vol;
        }
    }
}
