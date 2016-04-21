using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ChannelSorting
{
    class Program
    {
        static void GetAndSortChannels(string path)
        {
            if (!File.Exists(path))
                return;
            List<TVChannel> channels = new List<TVChannel>();
            var channelsNameAndCountry = File.ReadAllLines(path).Where(
                (l, index) =>l.Length>0 && index % 2 == 0).ToArray();
            var channelsUrl= File.ReadAllLines(path).Where(
                (l, index) => l.Length > 0 && index % 2!= 0).ToArray();
            for (int i = 0; i < channelsUrl.Length; i++)
            {
                var value = channelsNameAndCountry[i].Split(':');
                var country = value.Length > 2?  value[1]:"Default";
                var name = value.Length > 2 ? value[2] : value[1];
                var url=new string(channelsUrl[i].Select(c => c).Skip(channelsUrl[i].IndexOf(':') + 1).ToArray());

                channels.Add(new TVChannel(country, name, url));
            }
          
            using (StreamWriter sr=File.CreateText("SortByCountryChannels.txt"))
            {
                foreach (var sortChannels in channels.GroupBy(c => c.Country))
                {
                    sr.WriteLine(sortChannels.Key+":");
                    foreach (var channel in sortChannels)
                    {
                        sr.WriteLine(channel.Name);
                        sr.WriteLine(channel.URL);
                    }

                }
            }
        }
        static void Main(string[] args)
        {

            GetAndSortChannels("webtv list (2).txt");

            Console.ReadKey();
        }
    }
}
