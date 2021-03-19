using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IBatteryVoltageDal
    {
        BatteryVoltageDTO GetByID(int id);
        List<BatteryVoltageDTO> GetAll();
        BatteryVoltageDTO Create(BatteryVoltageDTO dto);

        BatteryVoltageDTO Update(BatteryVoltageDTO dto);
        bool Delete(int id);
    }
}
