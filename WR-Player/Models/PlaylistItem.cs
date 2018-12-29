using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WR_Player.Models
{
    public class PlaylistItem : NotifyBase
    {
        public PlaylistItem()
        {
        }

        public PlaylistItem(string title, string path)
        {
            Title = title;
            Path = path;
            IsSelected = false;
        }


        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyPropertyChanged();
            }
        }

        private string _path;
        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
                NotifyPropertyChanged();
            }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                NotifyPropertyChanged();
            }
        }

    }
}
