using DAL.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class BatteryStatusDal : IBatteryStatusDal
    {
        private string connectionString;
        public BatteryStatusDal(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public BatteryStatusDTO Create(BatteryStatusDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<BatteryStatusDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public BatteryStatusDTO GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public BatteryStatusDTO Update(BatteryStatusDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
