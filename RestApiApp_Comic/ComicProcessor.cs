using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RestApiApp_Comic
{
    public static class ComicProcessor
    {
        private static HttpClient client = new HttpClient();

        public static async Task<ComicModel> LoadComic(int idComic = 0)
        {
            string url = "";

            if (idComic > 0)
            {
                url = $"https://xkcd.com/{idComic}/info.0.json";
            }
            else
            {
                url = "https://xkcd.com/info.0.json";
            }

            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                var headers = response.Headers;

                string responceString = await response.Content.ReadAsStringAsync();

                ComicModel comicModel = JsonConvert.DeserializeObject<ComicModel>(responceString);

                return comicModel;
            }
        }
    }
}
