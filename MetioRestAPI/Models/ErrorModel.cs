using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetioRestAPI.Models
{
    public class ErrorModel
    {
        public string date_time { set; get; }

        public DateTime dateTime { 
            get {
                if (DateTime.TryParse(this.date_time, out DateTime dt))
                {
                    return dt;
                }
                else
                {
                    return DateTime.MinValue;
                }
            }
        }
        public string message { get; set; }
    }
}