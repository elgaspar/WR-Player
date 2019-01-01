using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WR_Player.Models
{
    static class PlaylistParser
    {
        private static Playlist playlist;
        private static List<string> lines;



        public static bool WriteToFile(Playlist playlistToWrite, string filepathToWrite)
        {
            playlist = playlistToWrite;
            lines = new List<string>();

            writeStartingLine();
            writeAllItems();

            return tryWriteToFile(filepathToWrite);
        }

        public static Playlist ReadFromFile(string filepathToRead)
        {
            string[] linesRead = tryReadFile(filepathToRead);

            playlist = new Playlist();
            lines = new List<string>();
            lines.AddRange(linesRead);

            try
            {
                trimLinesAndRemoveEmpty();
                readStartingLine();
                readAllItems();
            }
            catch (Exception)
            {
                return null;
            }

            return playlist;
        }



        

        private static void writeStartingLine()
        {
            lines.Add("#EXTM3U");
        }

        private static void writeAllItems()
        {
            foreach (PlaylistItem item in playlist.Items)
                writeItem(item);
        }

        private static void writeItem(PlaylistItem item)
        {
            lines.Add("#EXTINF:-1," + item.Title);
            lines.Add(item.Path);
        }

        private static bool tryWriteToFile(string filepath)
        {
            try
            {
                File.WriteAllLines(filepath, lines);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }



        private static string[] tryReadFile(string filepath)
        {
            try
            {
                return File.ReadAllLines(filepath);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static void trimLinesAndRemoveEmpty()
        {
            List<string> newList = new List<string>();
            foreach (string line in lines)
            {
                string newLine = line.Trim();
                if ( newLine != string.Empty )
                    newList.Add(newLine);
            }
            lines = newList;
        }

        private static void readStartingLine()
        {
            if (lines[0] != "#EXTM3U")
                throwCouldNotReadException();
        }

        private static void readAllItems()
        {
            //first line already read by readStartingLine() so we start reading from second line
            for (int i = 1; i < lines.Count; i++)
            {
                if (lines[i].StartsWith("#EXTINF"))
                {
                    string[] itemLines = new string[2] { lines[i], lines[i + 1] };
                    readItem(itemLines);
                }
                
            }
        }

        private static void readItem(string[] itemLines)
        {
            string firstLine = itemLines[0];
            string secondLine = itemLines[1];
            if (!firstLine.StartsWith("#EXTINF"))
                throwCouldNotReadException();

            string title = readTitle(firstLine);
            string path = secondLine;

            PlaylistItem item = new PlaylistItem(title, path);
            playlist.Add(item);
        }

        private static string readTitle(string line)
        {
            int i = line.IndexOf(',');
            return line.Substring(i + 1).Trim();
        }

        private static void throwCouldNotReadException()
        {
            throw new InvalidDataException("Playlist file is not properly formatted.");
        }
    }
}
