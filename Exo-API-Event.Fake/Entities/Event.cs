using System;
using System.Collections.Generic;
using System.Text;

namespace Exo_API_Event.Fake.Entities
{
    public class Event
    {
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool Dresscode { get; set; }
    }
}
