using System.Threading.Tasks;
using CodeHollow.FeedReader;

namespace Providers
{
    internal interface IProvider
    {
        string SearchTerm { set; }

        Task<Feed> Run();
    }
}