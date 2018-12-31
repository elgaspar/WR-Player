using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WR_Player.ViewModels
{
    class DialogViewModelBase : Screen
    {
        public MainViewModel ParentVM { get; protected set; }

        public DialogViewModelBase(MainViewModel parent)
        {
            ParentVM = parent;
        }
    }
}
