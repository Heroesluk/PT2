using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT2.data
{


    public abstract class Event
    {

        public int EventId { get; set; }

        public string EventName { get; set; }

        public DateTime Timestamp { get; set; }

    }


}
