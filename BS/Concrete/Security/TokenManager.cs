using BS.Interface;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Concrete
{
    public class TokenManager : ITokenManager
    {
        private readonly ITokenDal _tokenDal;
        private readonly IClientDal _clientDal;
        public TokenManager(ITokenDal tokenDal, IClientDal clientDal)
        {

            this._tokenDal = tokenDal;
            this._clientDal = clientDal;
        }

        public DTO.TokenDTO GenerateNewToken(DTO.TokenDTO old_token, int minutes)
        {
            throw new NotImplementedException();
        }

        public DTO.TokenDTO GenerateNewToken(string login,int minutes)
        {
            try
            {
                var _client = _clientDal.GetByLogin(login);
                var _token = _tokenDal.GetByID(_client.device_id);
                if(_token == null)
                {
                    return _tokenDal.Create(new DTO.TokenDTO { id = _client.client_id, token = Guid.NewGuid(), expire_date = DateTime.Now.AddMinutes(minutes) });
                }

                var new_guid = Guid.NewGuid();
                _token.token = new_guid;
                //_token.expire_date = DateTime.Now.AddHours(1);
                _token.expire_date = DateTime.Now.AddMinutes(minutes);

                return _tokenDal.Update(_token);
            }
            catch(Exception exp)
            {
                throw exp;
            }

        }

        public DTO.TokenDTO GetByToken(Guid token)
        {
            try
            {
                return this._tokenDal.GetByToken(token).First();
            }
            catch(Exception exp)
            {
                throw exp;
            }
        }

        public bool IsValidToken(Guid token)
        {
            try
            {
                var _tokens = this._tokenDal.GetByToken(token);
                if (_tokens.Count == 0)
                {
                    throw new Exception("No token found");
                }

                var _token = _tokens.OrderByDescending(p => p.expire_date).First();

                return (_token.expire_date > DateTime.Now);

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
