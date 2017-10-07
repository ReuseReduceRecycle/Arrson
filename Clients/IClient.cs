using System.Threading.Tasks;

namespace Clients
{
    public interface IClient
    {
        Task Login(string username, string password);
        Task AddTorrent(string url);
    }
}