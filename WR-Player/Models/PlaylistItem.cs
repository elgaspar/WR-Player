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
                Type = generateAudioTypeFromPath(value);
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

        private static AudioType generateAudioTypeFromPath(string path)
        {
            if (path.ToLower().StartsWith("http"))
                return AudioType.Url;
            string extension = System.IO.Path.GetExtension(path);
            extension = extension.Substring(1); //first character is '.' so we remove it
            extension = extension.First().ToString().ToUpper() + extension.Substring(1).ToLower();
            Enum.TryParse(extension, out AudioType type);
            return type;
        }

    }
}
