using DAL.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class RoleDal : IRoleDal
    {
        private string connectionString;
        public RoleDal(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public RoleDTO Create(RoleDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<RoleDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public RoleDTO GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public RoleDTO Update(RoleDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
