using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WR_Player.Views.Assist;

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

        private bool _hideTaskbarIcon;
        public bool HideTaskbarIcon
        {
            get { return _hideTaskbarIcon; }
            set
            {
                _hideTaskbarIcon = value;
                NotifyOfPropertyChange(() => HideTaskbarIcon);
            }
        }

        private bool _hideSeekingBar;
        public bool HideSeekingBar
        {
            get { return _hideSeekingBar; }
            set
            {
                _hideSeekingBar = value;
                NotifyOfPropertyChange(() => HideSeekingBar);
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
            OpenLastUsedFile = Settings.OpenLastUsedFile;
            AlwaysOnTop = Settings.AlwaysOnTop;
            HideTaskbarIcon = Settings.HideTaskbarIcon;
            HideSeekingBar = Settings.HideSeekingBar;
            Theme = Settings.Theme;
        }

        private void saveCurrentSettings()
        {
            Settings.OpenLastUsedFile = OpenLastUsedFile;
            Settings.AlwaysOnTop = AlwaysOnTop;
            Settings.HideTaskbarIcon = HideTaskbarIcon;
            Settings.HideSeekingBar = HideSeekingBar;
            Settings.Theme = Theme;
        }
    }
}
