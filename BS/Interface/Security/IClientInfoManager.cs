using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Interface
{
    public interface IClientInfoManager
    {
        List<RoleDTO> GetUserRoles(string login);
        List<RoleDTO> GetUserRoles(ClientDTO client);
    }
}
