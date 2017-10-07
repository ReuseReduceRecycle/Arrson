using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Web;
using CodeHollow.FeedReader;

namespace Providers
{
    public class Nyaa : IProvider
    {
        public Nyaa()
        {
            Uri = new UriBuilder(Url);

            QueryDictionary = HttpUtility.ParseQueryString(Uri.Query);

            QueryDictionary["page"] = "rss";
        }

        private NameValueCollection QueryDictionary { get; }

        private UriBuilder Uri { get; }

        private static string Url => "https://nyaa.si/";

        public string SearchTerm
        {
            set => QueryDictionary["q"] = value;
        }

        public async Task<Feed> Run()
        {
            Uri.Query = QueryDictionary.ToString();

            return await FeedReader.ReadAsync(Uri.ToString());
        }
    }
}