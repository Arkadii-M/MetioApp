using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IClientDal
    {
        ClientDTO GetByID(int id);
        ClientDTO GetByLogin(string login);
        bool Login(string login,string password);
        List<ClientDTO> GetAll();
        ClientDTO Create(ClientDTO dto);

        ClientDTO Update(ClientDTO dto);
        bool Delete(int id);
    }
}
