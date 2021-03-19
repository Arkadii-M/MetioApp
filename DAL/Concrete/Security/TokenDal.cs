using DAL.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class TokenDal : ITokenDal
    {
        private string connectionString;
        public TokenDal(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public TokenDTO Create(TokenDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TokenDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public TokenDTO GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public TokenDTO Update(TokenDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
