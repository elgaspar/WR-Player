using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WR_Player.Models
{
    public class Player : NotifyBase
    {
        private const int DEFAULT_DURATION_POSITION = -1;

        public double Volume { get; private set; }        
        public PlayerStatus Status { get; private set; }

        public int DurationInSeconds
        {
            get
            {
                if (player.NaturalDuration.HasTimeSpan)
                    return (int)player.NaturalDuration.TimeSpan.TotalSeconds;
                return DEFAULT_DURATION_POSITION;
            }
        }

        public int PositionInSeconds
        {
            get
            {
                if (Status != PlayerStatus.Playing)
                    return 0;
                if (!player.NaturalDuration.HasTimeSpan)
                    return DEFAULT_DURATION_POSITION;
                return (int)player.Position.TotalSeconds;
            }
            set
            {
                if (player.NaturalDuration.HasTimeSpan)
                    player.Position = new TimeSpan(0, 0, (int)value);
            }
        }

        public event EventHandler PlaybackFinished
        {
            add { player.MediaEnded += value; }
            remove { player.MediaEnded -= value; }
        }

        private MediaPlayer player;

        public Player()
        {
            player = new MediaPlayer();
            Volume = 0.5;
            Status = PlayerStatus.Idle;
        }

        public enum PlayerStatus
        {
            Idle, Playing, Error
        }

        public void Play(string Url)
        {
            player.Close();
            try
            {
                player.Open(new Uri(Url));
                player.Play();
            }
            catch (Exception)
            {
                Console.WriteLine("---Invalid URL");//TODO deleteme
                Status = PlayerStatus.Error;
                return;
            }
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
