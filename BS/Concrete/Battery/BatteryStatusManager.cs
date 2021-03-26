using BS.Interface;
using DAL.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Concrete
{
    public class BatteryStatusManager: IBatteryStatusManager
    {
        private readonly IBatteryStatusDal _batteryStatusDal;
        public BatteryStatusManager(IBatteryStatusDal batteryStatusDal)
        {
            _batteryStatusDal = batteryStatusDal;

        }
        public BatteryStatusDTO AddBatteryStatus(BatteryStatusDTO status)
        {
            return this._batteryStatusDal.Create(status);
        }

        public void DeleteBatteryStatus(int id)
        {
            this._batteryStatusDal.Delete(id);
        }
        public List<BatteryStatusDTO> GetAllBatteryStatuses()
        {
            return this._batteryStatusDal.GetAll();
        }


        public BatteryStatusDTO GetBatteryStatusByID(int id)
        {
            return this._batteryStatusDal.GetByID(id);
        }

        public List<BatteryStatusDTO> GetBatteryStatusForPeriod(DateTime start, DateTime end)
        {
            var data = this._batteryStatusDal.GetAll();

            return data.Where(dt => ((dt.date_time >= start) && (dt.date_time <= end))).ToList();
        }
    }
}
