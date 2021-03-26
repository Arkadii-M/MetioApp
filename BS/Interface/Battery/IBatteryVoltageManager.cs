using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Interface
{
    public interface IBatteryVoltageManager
    {
        BatteryVoltageDTO GetBatteryVoltageByID(int id);
        List<BatteryVoltageDTO> GetAllBatteryVoltage();
        List<BatteryVoltageDTO> GetAllBatteryVoltageForPeriod(DateTime start, DateTime end);
        BatteryVoltageDTO AddBatteryVoltage(BatteryVoltageDTO voltage);

        void DeleteBatteryVoltage(int id);
    }
}
