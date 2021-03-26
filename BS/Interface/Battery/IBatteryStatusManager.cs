using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Interface
{
    public interface IBatteryStatusManager
    {
        BatteryStatusDTO GetBatteryStatusByID(int id);
        List<BatteryStatusDTO> GetAllBatteryStatuses();
        List<BatteryStatusDTO> GetBatteryStatusForPeriod(DateTime start, DateTime end);
        BatteryStatusDTO AddBatteryStatus(BatteryStatusDTO status);

        void DeleteBatteryStatus(int id);
    }
}
