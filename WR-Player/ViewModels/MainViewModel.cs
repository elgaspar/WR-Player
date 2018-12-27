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
        public PlayerViewModel PlayerVM { get; }

        public MainViewModel()
        {
            PlayerVM = new PlayerViewModel();

            
        }

        


        

    }
}
