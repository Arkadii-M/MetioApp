using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ClientDTO
    {
        public int client_id { get; set; }
        public string login { get; set; }

        //public string password { get; set; }
        public int device_id { get; set; }
    }
}
