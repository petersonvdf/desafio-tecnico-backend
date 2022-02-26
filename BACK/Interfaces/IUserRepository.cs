using BACK.Models;
using System.Threading.Tasks;

namespace BACK.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> Get(string login, string senha);
    }
}
