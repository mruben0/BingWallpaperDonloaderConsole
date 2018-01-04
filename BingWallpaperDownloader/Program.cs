using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingWallpaperDownloader
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var hTManager = new HttpManager();

            var IO = new IOManager();

            List<string> images = hTManager.URLParser();

            Console.WriteLine(images.Count);

            foreach (var image in images)
            {
                IO.DownloadImage(image);
                Console.WriteLine(Path.GetFileName(image));
            }

            Console.WriteLine("Done");
            Console.Read();
        }
    }
}