using DAL.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class BmpModuleDal : IBmpModuleDal
    {
        private string connectionString;
        public BmpModuleDal(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public BmpModuleDTO Create(BmpModuleDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<BmpModuleDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public BmpModuleDTO GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public BmpModuleDTO Update(BmpModuleDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
