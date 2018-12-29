using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WR_Player.Models
{
    public class Player
    {
        public double Volume { get; private set; }        
        public PlayerStatus Status { get; private set; }


        private MediaPlayer player;

        public Player()
        {
            player = new MediaPlayer();
            Volume = 0.5;
            Status = PlayerStatus.Idle;
        }

        public enum PlayerStatus
        {
            Idle, Buffering, Playing 
        }

        public void Play(string Url)
        {
            player.Close();
            player.Open(new Uri(Url));
            player.Play();
            player.Volume = Volume;

            Status = PlayerStatus.Playing;
        }

        public void Stop()
        {
            player.Stop();
            Status = PlayerStatus.Idle;
        }

        public void SetVolume(double vol)
        {
            Volume = vol;
            player.Volume = vol;
        }
    }
}
