using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WR_Player.ViewModels
{
    class DialogConfirmViewModel : DialogViewModelBase
    {
        public DialogConfirmViewModel(string msg)
        {
            Msg = msg;
            Result = null;
        }

        public bool? Result;

        public string Msg { get; }

        public void Yes()
        {
            //do nothing
            Result = true;
            TryClose(true);
        }

        public void No()
        {
            //do nothing
            Result = false;
            TryClose(false);
        }

        public void Exit()
        {
            //do nothing
            Result = null;
            TryClose(null);
        }
    }
}
