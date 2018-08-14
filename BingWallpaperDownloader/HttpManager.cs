using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BingWallpaperDownloader
{
    public class HttpManager
    {
        public RestClient client = new RestClient("https://www.bing.com/");

        public List<string> URLParser()
        {
            List<string> ImageUrls = new List<string>();
            for (int i = 0; i < 15; i+=9)
            {
                var request = new RestRequest("HPImageArchive.aspx?format=js&idx={idx}&n=1000", Method.GET);

                request.AddParameter("idx", i, ParameterType.UrlSegment);

                var queryResult = client.Execute(request);

                JObject o = JObject.Parse(queryResult.Content);
                JArray arr = (JArray)o.SelectToken("images");

                foreach (var item in arr)
                {
                    var url = item.Value<string>("url");
                    var name = item.Value<string>("copyright");
                    var bingUrl = "https://www.bing.com" + url;
                    if (!ImageUrls.Contains(bingUrl))
                    {

                    }
                }
            }
            return ImageUrls;
        }
    }
}