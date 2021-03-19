using DAL.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class BatteryVoltageDal : IBatteryVoltageDal
    {
        private string connectionString;
        public BatteryVoltageDal(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public BatteryVoltageDTO Create(BatteryVoltageDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<BatteryVoltageDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public BatteryVoltageDTO GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public BatteryVoltageDTO Update(BatteryVoltageDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
