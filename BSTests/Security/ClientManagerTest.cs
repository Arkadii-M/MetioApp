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

namespace BSTests.Security
{
    [TestFixture]
    class ClientManagerTest
    {
        private Mock<IClientDal> clientDal;
        private ClientManager manager;

        [SetUp]
        public void Setup()
        {
            clientDal = new Mock<IClientDal>(MockBehavior.Strict);
            manager = new ClientManager(clientDal.Object);
        }

        [Test]
        public void GetClientByIDTest([Values(1,2)]int client_id, [Values(1, 2)] int device_id,[Values("login")]string login)
        {
            var cltDTO = new ClientDTO {login =login,client_id=client_id,device_id=device_id };

            clientDal.Setup(m => m.GetByID(It.IsNotNull<int>())).Returns(cltDTO);

            var res = manager.GetClientByID(client_id);

            Assert.IsTrue(device_id == res.device_id);
        }

        [Test]
        public void GetClientByLogin([Values(1, 2)] int client_id, [Values(1, 2)] int device_id, [Values("login")] string login)
        {
            var cltDTO = new ClientDTO { login = login, client_id = client_id, device_id = device_id };

            clientDal.Setup(m => m.GetByLogin(It.IsNotNull<string>())).Returns(cltDTO);

            var res = manager.GetClientByLogin(login);

            Assert.IsTrue(device_id == res.device_id);
        }


    }
}
