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
    class TokenManagerTest
    {
        private Mock<ITokenDal> tokenDal;
        private Mock<IClientDal> clientDal;
        private TokenManager manager;

        [SetUp]
        public void Setup()
        {
            clientDal = new Mock<IClientDal>(MockBehavior.Strict);
            tokenDal = new Mock<ITokenDal>(MockBehavior.Strict);
            manager = new TokenManager(tokenDal.Object,clientDal.Object);
        }

        [Test]
        public void GenerateNewTokenTest([Values("login")] string login)
            
        {
            var clDTO = new ClientDTO {client_id =1,device_id=1,login =login };
            var tokenDTO =new TokenDTO { id = 1, expire_date = DateTime.Now.AddMinutes(1), token = Guid.NewGuid()};

            clientDal.Setup(m => m.GetByLogin(It.IsNotNull<string>())).Returns(clDTO);
            tokenDal.Setup(m => m.GetByID(It.Is<int>(p => p > 0))).Returns(tokenDTO);
            tokenDal.Setup(m => m.Create(It.IsNotNull<TokenDTO>())).Returns(tokenDTO);
            tokenDal.Setup(m => m.Update(tokenDTO)).Returns(tokenDTO);

            var res = manager.GenerateNewToken(login, 10);

            Assert.IsTrue(res.expire_date > DateTime.Now);

        }

        [Test]
        public void GenerateNewTokenTest1()

        {
            var tokenDTO = new TokenDTO { id = 1, expire_date = DateTime.Now.AddMinutes(1), token = Guid.NewGuid() };

            tokenDal.Setup(m => m.GetByID(It.Is<int>(p => p > 0))).Returns(tokenDTO);
            tokenDal.Setup(m => m.Create(It.IsNotNull<TokenDTO>())).Returns(tokenDTO);
            tokenDal.Setup(m => m.Update(tokenDTO)).Returns(tokenDTO);

            var res = manager.GenerateNewToken(tokenDTO, 10);

            Assert.IsTrue(res.expire_date > DateTime.Now);

        }


        [Test]
        public void GetByToken()
        {
            Guid token = Guid.NewGuid();
            var to_ret = new List<TokenDTO>() { new TokenDTO { id = 1, expire_date = DateTime.Now, token = token } };

            tokenDal.Setup(m => m.GetByToken(It.IsNotNull<Guid>())).Returns(to_ret);
            var res = manager.GetByToken(token);

            Assert.AreEqual(res.token, token);
        }


        [Test,Sequential]
        public void IsValidToken([Values(1,2)]int id, [Values(1,20)] int add_minutes)
        {
            Guid token = Guid.NewGuid();
            var to_ret = new List<TokenDTO>() { new TokenDTO { id = id, expire_date = DateTime.Now.AddMinutes(add_minutes), token = token } };

            tokenDal.Setup(m => m.GetByToken(It.IsNotNull<Guid>())).Returns(to_ret);
            var res = manager.IsValidToken(token);
            Assert.IsTrue(res);
        }

        [Test, Sequential]
        public void IsValidToken2([Values(1)] int id, [Values(0)] int add_minutes)
        {
            Guid token = Guid.NewGuid();
            var to_ret = new List<TokenDTO>() { new TokenDTO { id = id, expire_date = DateTime.Now.AddMinutes(add_minutes), token = token } };

            tokenDal.Setup(m => m.GetByToken(It.IsNotNull<Guid>())).Returns(to_ret);
            var res = manager.IsValidToken(token);
            Assert.IsFalse(res);
        }


    }
}
