using Shell32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WR_Player.Models
{
    static class PlaylistItemHelper
    {
        private const int DURATION_DEFAULT_VALUE = -1;



        public static AudioType GenerateType(string path)
        {
            if (path.ToLower().StartsWith("http"))
                return AudioType.Url;

            try
            {
                return tryParseExtension(path);
            }
            catch (Exception)
            {
                return AudioType.Url;
            }
        }

        public static int GenerateDuration(string path, AudioType type)
        {
            if (type == AudioType.Url)
                return DURATION_DEFAULT_VALUE;

            try
            {
                string durationString = getDurationStringFromShell(path);
                return parseDurationStringToSeconds(durationString);
            }
            catch (Exception)
            {
                return DURATION_DEFAULT_VALUE;
            }
        }





        private static AudioType tryParseExtension(string path)
        {
            string extension = System.IO.Path.GetExtension(path);
            extension = extension.Substring(1); //first character is '.' so we remove it
            extension = extension.First().ToString().ToUpper() + extension.Substring(1).ToLower();
            Enum.TryParse(extension, out AudioType type);
            return type;
        }

        private static string getDurationStringFromShell(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
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

        private static int parseDurationStringToSeconds(string durationString)
        {
            int hours = Int32.Parse(durationString.Substring(0, 2));
            int minutes = Int32.Parse(durationString.Substring(3, 2));
            int seconds = Int32.Parse(durationString.Substring(6, 2));
            TimeSpan tp = new TimeSpan(hours, minutes, seconds);
            return (int)tp.TotalSeconds;
        }
    }
}
