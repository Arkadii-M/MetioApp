using DAL.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class PrecipitationModuleDal : IPrecipitationModuleDal
    {
        private string connectionString;
        public PrecipitationModuleDal(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public PrecipitationModuleDTO Create(PrecipitationModuleDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<PrecipitationModuleDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public PrecipitationModuleDTO GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public PrecipitationModuleDTO Update(PrecipitationModuleDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
