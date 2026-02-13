using Exo_API_Event.Fake.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exo_API_Event.Fake
{
    public interface IContext
    {
        public Event Event { get; set; }
        public IEnumerable<Guest> Guests { get; set; }
    }
}
