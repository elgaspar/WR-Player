using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WR_Player.ViewModels
{
    public class ViewModelBase : PropertyChangedBase
    {
        protected MainViewModel ParentVM;

        public ViewModelBase(MainViewModel parent)
        {
            ParentVM = parent;
        }
    }
}
