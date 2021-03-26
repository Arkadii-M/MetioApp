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
    public class BatteryVoltageManager: IBatteryVoltageManager
    {
        private readonly IBatteryVoltageDal _batteryVoltageDal;
        public BatteryVoltageManager(IBatteryVoltageDal batteryVoltageDal)
        {
            _batteryVoltageDal = batteryVoltageDal;

        }
        public BatteryVoltageDTO AddBatteryVoltage(BatteryVoltageDTO voltage)
        {
            return this._batteryVoltageDal.Create(voltage);
        }
        public void DeleteBatteryVoltage(int id)
        {
            this._batteryVoltageDal.Delete(id);
        }

        public List<BatteryVoltageDTO> GetAllBatteryVoltage()
        {
            return this._batteryVoltageDal.GetAll();
        }

        public List<BatteryVoltageDTO> GetAllBatteryVoltageForPeriod(DateTime start, DateTime end)
        {
            var data = this._batteryVoltageDal.GetAll();

            return data.Where(dt => ((dt.date_time >= start) && (dt.date_time <= end))).ToList();
        }
        public BatteryVoltageDTO GetBatteryVoltageByID(int id)
        {
            return this._batteryVoltageDal.GetByID(id);
        }
    }
}
