using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BingWallpaperDownloader
{
    public class IOManager
    {
        public string DownloadPath = @"..\SavedFromBing";

        public IOManager()
        {
            if (!Directory.Exists(DownloadPath))
            {
                Directory.CreateDirectory(DownloadPath);
            }
        }

        public string ResultPathGenerator(string url)
        {
            string name = Path.GetFileName(url);
            string resultPath = Path.Combine(DownloadPath, name);
            return resultPath;
        }

        public void DownloadImages(List<string> Urls)
        {
            using (WebClient client = new WebClient())
            {
                foreach (var url in Urls)
                {
                    client.DownloadFile(new Uri(url), DownloadPath);
                }
            }
        }

        public void DownloadImage(string Url)
        {
            using (WebClient client = new WebClient())
            {
                if (!File.Exists(ResultPathGenerator(Url)))
                {
                    client.DownloadFile(new Uri(Url), ResultPathGenerator(Url));
                }
            }
        }
    }
}