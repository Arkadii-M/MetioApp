using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Interface
{
    public interface ITokenManager
    {
        bool IsValidToken(Guid token);
        TokenDTO GetByToken(Guid token);
        TokenDTO GenerateNewToken(TokenDTO old_token,int minutes);
        TokenDTO GenerateNewToken(string login,int minutes);
    }
}
