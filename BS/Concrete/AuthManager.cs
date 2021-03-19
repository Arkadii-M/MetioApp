using BS.Interface;
using DAL.Interface;
using DAL.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Concrete
{
    public class AuthManager : IAuthManager
    {
        private readonly IDeviceDal _deviceDal;
        private readonly IRoleDal _roleDal;
        private readonly ITokenDal _tokenDal;
        private readonly IPermissionDal _permissionDal;
        public AuthManager(IDeviceDal deviceDal, IRoleDal roleDal, ITokenDal tokenDal, IPermissionDal permissionDal)
        {
            this._deviceDal = deviceDal;
            this._roleDal = roleDal;
            this._tokenDal = tokenDal;
            this._permissionDal = permissionDal;

        }
        public ClientDTO Authorize(Guid token)
        {
            var _token = this._tokenDal.GetByToken(token);
            if(token != null)
            {
                var _device = this._deviceDal.GetByID(_token.id);
                var _permission = this._permissionDal.GetByID(_token.id);
                var _role = this._roleDal.GetByID(_permission.role_id);
                var _client = new ClientDTO(_device, _role, _token);
                return _client;
            }
            else
            {
                return null;
            }
        }
    }
}
