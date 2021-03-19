using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IBatteryStatusDal
    {
        BatteryStatusDTO GetByID(int id);
        List<BatteryStatusDTO> GetAll();
        BatteryStatusDTO Create(BatteryStatusDTO dto);

        BatteryStatusDTO Update(BatteryStatusDTO dto);
        bool Delete(int id);
    }
}
