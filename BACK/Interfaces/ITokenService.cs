using BACK.Models;

namespace BACK.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
