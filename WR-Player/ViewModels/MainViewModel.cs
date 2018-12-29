using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WR_Player.Models;

namespace WR_Player.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {
        public FileViewModel FileVM { get; }
        public PlaylistViewModel PlaylistVM { get; }
        public PlayerViewModel PlayerVM { get; }

        public MainViewModel()
        {
            FileVM = new FileViewModel(this);
            PlaylistVM = new PlaylistViewModel(this);
            PlayerVM = new PlayerViewModel(this);
        }
    }
}
