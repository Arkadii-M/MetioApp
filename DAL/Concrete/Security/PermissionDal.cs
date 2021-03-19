using DAL.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class PermissionDal : IPermissionDal
    {
        private string connectionString;
        public PermissionDal(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public PermissionDTO Create(PermissionDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<PermissionDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public PermissionDTO GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public PermissionDTO Update(PermissionDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
