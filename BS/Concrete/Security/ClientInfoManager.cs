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
    public class ClientInfoManager : IClientInfoManager
    {
        private readonly IPermissionDal _permissionDal;
        private readonly IRoleDal _roleDal;
        public ClientInfoManager(IPermissionDal permissionDal, IRoleDal roleDal)
        {
            this._permissionDal = permissionDal;
            this._roleDal = roleDal;

        }
        public List<RoleDTO> GetUserRoles(string login)
        {
            throw new NotImplementedException();
        }

        public List<RoleDTO> GetUserRoles(ClientDTO client)
        {
            try
            {
                var perm = this._permissionDal.GetByID(client.client_id);
                List<RoleDTO> to_ret = new List<RoleDTO>();

                foreach (var p in perm)
                {
                    to_ret.Add(this._roleDal.GetByID(p.role_id));
                }
                return to_ret;
            }
            catch(Exception exp)
            {
                throw exp;
            }
        }
    }
}
