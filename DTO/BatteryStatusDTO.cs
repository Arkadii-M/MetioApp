using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BatteryStatusDTO
    {
        public int id { get; set; }

        public DateTime date_time { get; set; }

        public string status_code { get; set; }
    }
}
