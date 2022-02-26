using BACK.Models;
using BACK.Interfaces;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BACK.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _config;

        public UserRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<User> Get(string login, string senha)
        {
            var configLogin = _config["configLogin"];
            var configSenha = _config["configSenha"];

            if (login != configLogin || senha != configSenha) return null;

            User user = null;

            await Task.Run(() => user = new User { Id = 1, Login = configLogin });

            return user;
        }
    }
}