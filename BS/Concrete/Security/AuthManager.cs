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
        private readonly IClientDal _clientDal;

        public AuthManager(IClientDal clientDal)
        {
            this._clientDal = clientDal;

        }

        public bool Authorize(string login, string password)
        {
            
            try
            {
                return this._clientDal.Login(login, password);
            }
            catch(Exception exp)
            {
                throw exp;
            }
        }
    }
}
