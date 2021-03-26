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
    public class ClientManager : IClientManager
    {
        private readonly IClientDal _clientDal;
        public ClientManager(IClientDal clientDal)
        {
            this._clientDal = clientDal;
        }

        public ClientDTO GetClientByID(int id)
        {
            try
            {
                return this._clientDal.GetByID(id);
            }
            catch(Exception exp)
            {
                throw exp;
            }
        }

        public ClientDTO GetClientByLogin(string login)
        {
            try
            {
                return this._clientDal.GetByLogin(login);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
