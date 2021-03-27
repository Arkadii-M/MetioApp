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
    class ClientInfoManagerTest
    {
        private Mock<IPermissionDal> permissionDal;
        private Mock<IRoleDal> roleDal;
        private ClientInfoManager manager;

        [SetUp]
        public void Setup()
        {
            permissionDal = new Mock<IPermissionDal>(MockBehavior.Strict);
            roleDal = new Mock<IRoleDal>(MockBehavior.Strict);
            manager = new ClientInfoManager(permissionDal.Object,roleDal.Object);
        }

        [Test]
        public void GetUserRolesTest([Values(0, 1)]int role_id)
        {
            var cltDTO = new ClientDTO { login = "login", client_id = 1, device_id = 1 };

            var permDTO =new List<PermissionDTO>() { new PermissionDTO { id = 1, role_id = 1 }, new PermissionDTO { id = 1, role_id = 2 } };
            var roleDTO = new List<RoleDTO>() { new RoleDTO { id=1,role="role1"}, new RoleDTO { id = 2, role = "role2" } };


            permissionDal.Setup(m => m.GetByID(It.IsNotNull<int>())).Returns(permDTO);
            roleDal.Setup(m => m.GetByID(It.IsNotNull<int>())).Returns(roleDTO.ElementAt(role_id));


            var res = manager.GetUserRoles(cltDTO);
            Assert.IsTrue(res.Count != 0);
        }



    }
}
