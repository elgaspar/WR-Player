using Shell32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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
                Type = PlaylistItemHelper.GenerateType(Path);
                DurationInSeconds = PlaylistItemHelper.GenerateDuration(Path, Type);
                NotifyPropertyChanged();
            }
        }

        private AudioType _type;
        public AudioType Type
        {
            get { return _type; }
            set
            {
                _type = value;
                NotifyPropertyChanged();
            }
        }

        private int _durationInSeconds;
        public int DurationInSeconds
        {
            get { return _durationInSeconds; }
            set
            {
                _durationInSeconds = value;
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
