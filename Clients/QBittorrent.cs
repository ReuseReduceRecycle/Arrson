using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Clients
{
    public class QBittorrent : IClient
    {
        public QBittorrent(string url, int port)
        {
            Client = new HttpClient();
            Url = url;
            Port = port;
        }

        private HttpClient Client { get; }
        private string Url { get; }
        private int Port { get; }

        public async Task Login(string username, string password)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });

            var result = await Client.PostAsync($"{Url}:{Port}/login", content);

            if (result.StatusCode != HttpStatusCode.OK)
                throw new ClientLoginError();
        }

        public async Task AddTorrent(string url)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("urls", url)
            });

            var result = await Client.PostAsync($"{Url}:{Port}/command/download", content);

            if (result.StatusCode != HttpStatusCode.OK)
                throw new ClientDownloadError($"{result.StatusCode}");
        }
    }
}