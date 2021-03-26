using BS.Concrete;
using BS.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;

namespace MetioRestAPI.App.Security
{
    public class CustomPrincipal : IPrincipal
    {
        public int ClientID { get; set; }

        public TokenDTO Token { get; set; }
        public string Login { get; set; }
        public string[] Roles { get; set; }

        private readonly ITokenManager _tokenManager;
        private readonly IClientManager _clientManager;
        private readonly IClientInfoManager _clientInfoManager;
        public IIdentity Identity { get; set; }

        public bool IsInRole(string role)
        {
            if (Roles.Any(r => r.Contains(role)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public CustomPrincipal(string token)
        {
            _tokenManager = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ITokenManager)) as ITokenManager;
            _clientManager = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IClientManager)) as IClientManager;
            _clientInfoManager = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IClientInfoManager)) as IClientInfoManager;


            Guid parse;
            if(Guid.TryParse(token,out parse))
            {
                Token = _tokenManager.GetByToken(parse);
            }
            else
            {
                Token = null;
                //Identity = new GenericIdentity("null");
                return;
            }


            var _client = _clientManager.GetClientByID(Token.id);

            Login = _client.login;
            Roles = _clientInfoManager.GetUserRoles(_client).Select(p => p.role).ToArray();
            ClientID = _client.client_id;

            Identity = new GenericIdentity(_client.login);
        }

        public bool ValidateToken()
        {
            return this._tokenManager.IsValidToken(Token.token);
        }
        public bool IsValidTokenForm()
        {
            return (Token != null);
        }

    }
}