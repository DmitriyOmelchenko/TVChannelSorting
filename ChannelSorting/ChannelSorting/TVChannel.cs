using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelSorting
{
    class TVChannel
    {
        public string Country { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }

        public TVChannel(string country,string name,string url)
        {
            Country = country;
            Name = name;
            URL = url;

        }
     
    }
}
