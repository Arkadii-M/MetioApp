using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BS.Concrete;
using DAL.Interface;
using Moq;
using NUnit;
using NUnit.Framework;

namespace BSTests.Security
{
    [TestFixture]
    class AuthManagerTest
    {
        private Mock<IClientDal> clientDal;
        private AuthManager manager;

        [SetUp]
        public void Setup()
        {
            clientDal = new Mock<IClientDal>(MockBehavior.Strict);
            manager = new AuthManager(clientDal.Object);
        }

        [Test]
        public void AuthorizeTest([Values]bool to_ret, [Values("login1", "login2")] string login, [Values("pass1", "pass2")] string pass)
        {

            clientDal.Setup(m => m.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(to_ret);
            var res = manager.Authorize(login, pass);

            Assert.AreEqual(to_ret, res);
        }
    }
}
