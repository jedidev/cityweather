using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace cityweather.Services
{
    public class DownloadService
    {
        public async Task<byte[]> DownloadItem(string url)
		{
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (var response = await client.GetAsync(url + "?APPID=" + Strings.ApiKey))
                    {
                        response.EnsureSuccessStatusCode();
                        byte[] bytes = await response.Content.ReadAsByteArrayAsync();
                        return bytes;
                    }
                }
            }
			catch
			{
				return null;
			}
        }
    }
}
