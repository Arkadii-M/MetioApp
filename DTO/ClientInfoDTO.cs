using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ClientInfoDTO
    {
        private DeviceDTO _device;

        private RoleDTO _role;

        private TokenDTO _token;
        public ClientInfoDTO()
        {
            this._device = null;
            this._role = null;
            this._token = null;
        }

        public ClientInfoDTO(DeviceDTO device, RoleDTO role, TokenDTO token)
        {
            this._device = device;
            this._role = role;
            this._token = token;
        }

        public string device_name { get { return this._device.device_name; } }
        public string role { get { return this._role.role; } }

        public DateTime token_exp_date { get { return this._token.expire_date; } }

        public Guid token { get { return this._token.token; } }
    }
}
