using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.System
{
    public class AccessCaller
    {
        public int ID { get; set; }

        public string IP { get; set; }

        public string DomainName { get; set; }

        public string CallerName { get; set; }

        public DateTime? CallTime { get; set; }

        public int CallCount { get; set; }
    }
}
