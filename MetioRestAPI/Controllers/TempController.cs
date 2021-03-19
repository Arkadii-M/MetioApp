using BS.Interface;
using BS.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL.Concrete;

namespace MetioRestAPI.Controllers
{
    public class TempController : ApiController
    {
        public TempController()
        {
            //this.TempManager = new TemperatureManager(new TemperatureDal("Data Source=;Initial Catalog=metiodata;User ID=metiodata;Password="));
        }
        // GET: api/Temp
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Temp/5
        public string Get(int id)
        {
            return "";
        }

        // POST: api/Temp
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Temp/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Temp/5
        public void Delete(int id)
        {
        }
    }
}
