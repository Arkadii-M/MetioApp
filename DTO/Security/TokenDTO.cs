using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TokenDTO
    {
        public int id { get; set; }

        public Guid token { get; set; }

        public DateTime expire_date { get; set; }

    }
}
