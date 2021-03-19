using DAL.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class DeviceDal : IDeviceDal
    {
        private string connectionString;
        public DeviceDal(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public DeviceDTO Create(DeviceDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<DeviceDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public DeviceDTO GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public DeviceDTO Update(DeviceDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
