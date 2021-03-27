using BS.Concrete;
using DAL.Interface;
using DTO;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTests.BatteryManager
{
    [TestFixture]
    class BatteryVoltageTest
    {
        private Mock<IBatteryVoltageDal> batteryVoltageDal;
        private BatteryVoltageManager manager;

        [SetUp]
        public void Setup()
        {
            batteryVoltageDal = new Mock<IBatteryVoltageDal>(MockBehavior.Strict);
            manager = new BatteryVoltageManager(batteryVoltageDal.Object);
        }

        [Test]
        public void AddBatteryVoltageTest()
        {
            BatteryVoltageDTO voltage = new BatteryVoltageDTO { id = 1, date_time = DateTime.Now, voltage = (float)4.1 };

            batteryVoltageDal.Setup(m => m.Create(It.IsAny<BatteryVoltageDTO>())).Returns(voltage);

            var res = manager.AddBatteryVoltage(voltage);

            Assert.IsTrue(res.id == voltage.id);
        }
        [Test]
        public void GetAllBatteryVoltage()
        {
            List<BatteryVoltageDTO> voltage =new List<BatteryVoltageDTO>() { new BatteryVoltageDTO { id = 1, date_time = DateTime.Now, voltage = (float)4.1 } };

            batteryVoltageDal.Setup(m => m.GetAll()).Returns(voltage);

            var res = manager.GetAllBatteryVoltage();

            Assert.IsTrue(res.Count !=0);
        }

        [Test]
        public void GetAllBatteryVoltageForPeriod()
        {
            List<BatteryVoltageDTO> voltage = new List<BatteryVoltageDTO>() {
                new BatteryVoltageDTO { id = 1, date_time = DateTime.Now.AddDays(-2), voltage = (float)4.1 },
                new BatteryVoltageDTO { id = 2, date_time = DateTime.Now.AddDays(1), voltage = (float)4.1 },
                new BatteryVoltageDTO { id = 3, date_time = DateTime.Now.AddHours(1), voltage = (float)4.1 },
                new BatteryVoltageDTO { id = 4, date_time = DateTime.Now.AddMinutes(-10), voltage = (float)4.1 },
                new BatteryVoltageDTO { id = 5, date_time = DateTime.Now.AddDays(1).AddMinutes(10), voltage = (float)4.1 }};

            batteryVoltageDal.Setup(m => m.GetAll()).Returns(voltage);

            var dt_left = DateTime.Now.AddDays(-10);
            var dt_right = DateTime.Now.AddDays(1).AddMinutes(8);

            var res = manager.GetAllBatteryVoltageForPeriod(dt_left, dt_right);

            Assert.IsTrue(res.Count ==4);
        }

        [Test]
        public void GetBatteryVoltageByID([Values(1)]int id)
        {
            BatteryVoltageDTO voltage = new BatteryVoltageDTO { id = id, date_time = DateTime.Now, voltage = (float)4.1 };

            batteryVoltageDal.Setup(m => m.GetByID(It.IsNotNull<int>())).Returns(voltage);

            var res = manager.GetBatteryVoltageByID(id);

            Assert.IsTrue(res.id == voltage.id );
        }



    }
}
