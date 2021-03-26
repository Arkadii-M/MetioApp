using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Interface
{
    public interface IAuthManager
    {
        bool Authorize(string login,string password);

    }
}
