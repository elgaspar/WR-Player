using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WR_Player.Models
{
    class Station
    {
        public string Title { get; set; }
        public string Url { get; set; }

        public Station()
        {
        }

        public Station(string title, string url)
        {
            Title = title;
            Url = url;
        }
    }
}
