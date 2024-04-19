using API.Authenticate.JWT.Models;

namespace API.Authenticate.JWT.Interfaces
{
    public interface ITokenService
    {
        string GetToken(User usuario);
    }
}
