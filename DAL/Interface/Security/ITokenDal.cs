using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface ITokenDal
    {
        TokenDTO GetByID(int id);
        TokenDTO GetByToken(Guid token);
        List<TokenDTO> GetAll();
        TokenDTO Create(TokenDTO dto);
        TokenDTO Update(TokenDTO dto);
        bool Delete(int id);
    }
}
