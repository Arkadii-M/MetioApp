using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BmpModuleDTO
    {
        public int id { get; set; }

        public DateTime date_time { get; set; }

        public float temperature { get; set; }

        public float pressure { get; set; }

        public float humidity { get; set; }
    }
}
