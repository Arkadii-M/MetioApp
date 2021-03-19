using DAL.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class RainModuleDal : IRainModuleDal
    {
        private string connectionString;
        public RainModuleDal(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public RainModuleDTO Create(RainModuleDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<RainModuleDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public RainModuleDTO GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public RainModuleDTO Update(RainModuleDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
