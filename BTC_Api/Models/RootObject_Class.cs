using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTC_Api.Classes
{
   public class RootObject_Class
    {
        public Time_Class time { get; set; }
        public string disclaimer { get; set; }
        public string chartName { get; set; }
        public Bpi_Class bpi { get; set; }
    }
}
