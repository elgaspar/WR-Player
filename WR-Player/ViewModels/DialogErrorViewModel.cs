using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WR_Player.ViewModels
{
    class DialogErrorViewModel : DialogViewModelBase
    {
        public DialogErrorViewModel(string msg)
        {
            Msg = msg;
        }

        public string Msg { get; }

        public void Ok()
        {
            //Do nothing
            TryClose(true);
        }
    }
}
