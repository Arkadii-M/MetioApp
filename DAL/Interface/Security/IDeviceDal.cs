using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IDeviceDal
    {
        DeviceDTO GetByID(int id);
        List<DeviceDTO> GetAll();
        DeviceDTO Create(DeviceDTO dto);

        DeviceDTO Update(DeviceDTO dto);
        bool Delete(int id);
    }
}
