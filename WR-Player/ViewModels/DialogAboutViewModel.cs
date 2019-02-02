using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WR_Player.ViewModels
{
    class DialogAboutViewModel : DialogViewModelBase
    {
        private const string VersionNo = "1.0.2";

        private const string MY_SITE_URL = @"http://www.elgaspar.com";
        private const string LICENSE_WR_PLAYER = @"Resources\LICENSE WR-Player.txt";

        private const string LICENSE_CALIBURN_MICRO = @"Resources\third-party licenses\LICENSE Caliburn.Micro.txt";
        private const string LICENSE_MAHAPPS_METRO = @"Resources\third-party licenses\LICENSE MahApps.Metro.txt";
        private const string LICENSE_CONTROLZ_EX = @"Resources\third-party licenses\LICENSE ControlzEx.txt";
        private const string LICENSE_MATERIAL_DESIGN_GOOGLE_ICONS = @"Resources\third-party licenses\LICENSE Material Design Google Icons.txt";
        private const string LICENSE_MATERIAL_DESIGN_COMMUNITY_ICONS = @"Resources\third-party licenses\LICENSE Material Design Community Icons.txt";



        public string Version { get { return "version " + VersionNo; } }

        public void VisitMySite()
        {
            Process.Start(MY_SITE_URL);
        }

        public void ShowMyLicense()
        {
            Process.Start(LICENSE_WR_PLAYER);
        }

        public void ShowCaliburnMicroLicense()
        {
            Process.Start(LICENSE_CALIBURN_MICRO);
        }

        public void ShowMahAppsMetroLicense()
        {
            Process.Start(LICENSE_MAHAPPS_METRO);
        }

        public void ShowControlzExLicense()
        {
            Process.Start(LICENSE_CONTROLZ_EX);
        }

        public void ShowMaterialDesighGoogleIconsLicense()
        {
            Process.Start(LICENSE_MATERIAL_DESIGN_GOOGLE_ICONS);
        }

        public void ShowMaterialDesighCommunityIconsLicense()
        {
            Process.Start(LICENSE_MATERIAL_DESIGN_COMMUNITY_ICONS);
        }


        public void Ok()
        {
            //Do nothing
            TryClose(true);
        }
    }
}
