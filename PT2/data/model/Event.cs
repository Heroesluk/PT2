using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT2.data.model
{


    public abstract class Event
    {

        public int EventId { get; set; }

        public string EventName { get; set; }

        public DateTime Timestamp { get; set; }

        // of the user that invoked the vent
        public int UserId { get; set; }

        public string EventDesciription { get; set; }

    }


}
