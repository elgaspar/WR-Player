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
        
        public event EventHandler PlaybackStarted
        {
            add { player.MediaOpened += value; }
            remove { player.MediaOpened -= value; }
        }

        public event EventHandler PlaybackFinished
        {
            add { player.MediaEnded += value; }
            remove { player.MediaEnded -= value; }
        }

        public event EventHandler<ExceptionEventArgs> PlaybackError
        {
            add { player.MediaFailed += value; }
            remove { player.MediaFailed -= value; }
        }





        private MediaPlayer player;

        public Player()
        {
            player = new MediaPlayer();
            Volume = 0.5;
            Status = PlayerStatus.Stopped;

            PlaybackStarted += Player_PlaybackStarted;
            PlaybackFinished += Player_PlaybackFinished;
            PlaybackError += Player_PlaybackError;
        }

        public enum PlayerStatus
        {
            Stopped, Buffering, Loading, Playing, Error
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
                Status = PlayerStatus.Error;
                return;
            }
            player.Volume = Volume;
            bool isUrl = PlaylistItemHelper.GenerateType(Url) == AudioType.Url;
            if (isUrl)
                Status = PlayerStatus.Buffering;
            else
                Status = PlayerStatus.Loading;
        }

        public void Stop()
        {
            player.Stop();
            Status = PlayerStatus.Stopped;
        }

        public void SetVolume(double vol)
        {
            Volume = vol;
            player.Volume = vol;
        }





        private void Player_PlaybackStarted(object sender, EventArgs e)
        {
            Status = PlayerStatus.Playing;
        }

        private void Player_PlaybackFinished(object sender, EventArgs e)
        {
            Status = PlayerStatus.Stopped;
        }

        private void Player_PlaybackError(object sender, EventArgs e)
        {
            Status = PlayerStatus.Error;
        }

    }
}
