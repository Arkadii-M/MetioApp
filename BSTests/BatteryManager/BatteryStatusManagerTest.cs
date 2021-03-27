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
    class BatteryStatusManagerTest
    {
        private Mock<IBatteryStatusDal> batteryStatusDal;
        private BatteryStatusManager manager;

        [SetUp]
        public void Setup()
        {
            batteryStatusDal = new Mock<IBatteryStatusDal>(MockBehavior.Strict);
            manager = new BatteryStatusManager(batteryStatusDal.Object);
        }

        [Test]
        public void AddBatteryStatus()
        {
            BatteryStatusDTO status = new BatteryStatusDTO { id = 1, date_time = DateTime.Now, status_code="a1" };

            batteryStatusDal.Setup(m => m.Create(It.IsAny<BatteryStatusDTO>())).Returns(status);

            var res = manager.AddBatteryStatus(status);

            Assert.IsTrue(res.id == status.id);
        }
        [Test]
        public void GetAllBatteryStatuses()
        {
            List<BatteryStatusDTO> status = new List<BatteryStatusDTO>() { new BatteryStatusDTO { id = 1, date_time = DateTime.Now, status_code = "a1" } };

            batteryStatusDal.Setup(m => m.GetAll()).Returns(status);

            var res = manager.GetAllBatteryStatuses();

            Assert.IsTrue(res.Count != 0);
        }

        [Test]
        public void GetBatteryStatusForPeriod()
        {
            List<BatteryStatusDTO> status = new List<BatteryStatusDTO>() {
                new BatteryStatusDTO { id = 1, date_time = DateTime.Now.AddDays(-2), status_code = "a1"  },
                new BatteryStatusDTO { id = 2, date_time = DateTime.Now.AddDays(1), status_code = "a1" },
                new BatteryStatusDTO { id = 3, date_time = DateTime.Now.AddHours(1), status_code = "a1"  },
                new BatteryStatusDTO { id = 4, date_time = DateTime.Now.AddMinutes(-10), status_code = "a1"  },
                new BatteryStatusDTO { id = 5, date_time = DateTime.Now.AddDays(1).AddMinutes(10), status_code = "a1"  }};

            batteryStatusDal.Setup(m => m.GetAll()).Returns(status);

            var dt_left = DateTime.Now.AddDays(-10);
            var dt_right = DateTime.Now.AddDays(1).AddMinutes(8);

            var res = manager.GetBatteryStatusForPeriod(dt_left, dt_right);

            Assert.IsTrue(res.Count == 4);
        }

        [Test]
        public void GetBatteryStatusByID([Values(1)] int id)
        {
            BatteryStatusDTO status = new BatteryStatusDTO { id = id, date_time = DateTime.Now, status_code = "a1" };

            batteryStatusDal.Setup(m => m.GetByID(It.IsNotNull<int>())).Returns(status);

            var res = manager.GetBatteryStatusByID(id);

            Assert.IsTrue(res.id == status.id);
        }

    }
}
