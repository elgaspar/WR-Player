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
                generateType();
                generateDuration();
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

        private void generateType()
        {
            if (Path.ToLower().StartsWith("http"))
            {
                Type = AudioType.Url;
                return;
            }
            string extension = System.IO.Path.GetExtension(Path);
            extension = extension.Substring(1); //first character is '.' so we remove it
            extension = extension.First().ToString().ToUpper() + extension.Substring(1).ToLower();
            Enum.TryParse(extension, out AudioType type);
            Type = type;
        }

        private void generateDuration()
        {
            if (Type == AudioType.Url)
            {
                DurationInSeconds = -1;
                return;
            }

            string durationString = getDurationStringFromShell();
            DurationInSeconds = parseDurationStringToSeconds(durationString);
        }

        private string getDurationStringFromShell()
        {
            FileInfo fileInfo = new FileInfo(Path);
            string directoryName = fileInfo.DirectoryName;
            string filename = fileInfo.Name;

            string fileLength = string.Empty;

            var shell = new Shell();
            var directory = shell.NameSpace(directoryName);
            foreach (FolderItem2 file in directory.Items())
            {
                if (file.Name == filename)
                    fileLength = directory.GetDetailsOf(file, 27).Trim();
            }
            Marshal.ReleaseComObject(directory);
            Marshal.ReleaseComObject(shell);

            return fileLength;
        }

        private int parseDurationStringToSeconds(string durationString)
        {
            try
            {
                int hours = Int32.Parse(durationString.Substring(0, 2));
                int minutes = Int32.Parse(durationString.Substring(3, 2));
                int seconds = Int32.Parse(durationString.Substring(6, 2));
                TimeSpan tp = new TimeSpan(hours, minutes, seconds);
                return (int)tp.TotalSeconds;
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
}
