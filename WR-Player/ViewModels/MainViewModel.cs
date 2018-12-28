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
        public FileViewModel FileVM { get; }
        public StreamsViewModel StreamsVM { get; }
        public PlayerViewModel PlayerVM { get; }

        public MainViewModel()
        {
            FileVM = new FileViewModel(this);
            StreamsVM = new StreamsViewModel(this);
            PlayerVM = new PlayerViewModel(this);
        }
    }
}
