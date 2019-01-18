using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WR_Player.ViewModels
{
    class DialogAboutViewModel : DialogViewModelBase
    {
        public void Ok()
        {
            //Do nothing
            TryClose(true);
        }
    }
}
