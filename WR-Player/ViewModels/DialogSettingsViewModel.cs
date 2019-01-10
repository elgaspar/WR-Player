using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WR_Player.ViewModels
{
    class DialogSettingsViewModel : DialogViewModelBase
    {
        public DialogSettingsViewModel(MainViewModel parent) : base(parent)
        {
            loadCurrentSettings();
        }


        private bool _openLastUsedFile;
        public bool OpenLastUsedFile
        {
            get { return _openLastUsedFile; }
            set
            {
                _openLastUsedFile = value;
                NotifyOfPropertyChange(() => OpenLastUsedFile);
            }
        }

        private bool _alwaysOnTop;
        public bool AlwaysOnTop
        {
            get { return _alwaysOnTop; }
            set
            {
                _alwaysOnTop = value;
                NotifyOfPropertyChange(() => AlwaysOnTop);
            }
        }

        private bool _showTaskbarIcon;
        public bool ShowTaskbarIcon
        {
            get { return _showTaskbarIcon; }
            set
            {
                _showTaskbarIcon = value;
                NotifyOfPropertyChange(() => ShowTaskbarIcon);
            }
        }

        public List<string> Themes
        {
            get
            {
                return new List<string>(){"Blue", "Cobalt", "Mauve", "Olive", "Sienna"};
            }
        }

        private string _theme;
        public string Theme
        {
            get { return _theme; }
            set
            {
                _theme = value;
                NotifyOfPropertyChange(() => Theme);
            }
        }



        public void Ok()
        {
            saveCurrentSettings();
            TryClose(true);
        }

        public void Cancel()
        {
            //Do nothing
            TryClose(null);
        }



        private void loadCurrentSettings()
        {
            OpenLastUsedFile = Properties.Settings.Default.OpenLastUsedFile;
            AlwaysOnTop = Properties.Settings.Default.AlwaysOnTop;
            ShowTaskbarIcon = Properties.Settings.Default.HideTaskbarIcon;
            Theme = Properties.Settings.Default.Theme;
        }

        private void saveCurrentSettings()
        {
            Properties.Settings.Default.OpenLastUsedFile = OpenLastUsedFile;
            Properties.Settings.Default.AlwaysOnTop = AlwaysOnTop;
            Properties.Settings.Default.HideTaskbarIcon = ShowTaskbarIcon;
            Properties.Settings.Default.Theme = Theme;

            Properties.Settings.Default.Save();
        }
    }
}
