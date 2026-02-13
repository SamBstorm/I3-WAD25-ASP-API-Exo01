using System;
using System.Collections.Generic;
using System.Text;

namespace Exo_API_Event.Fake.Entities
{
    public class Guest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsPresent { get; set; }
    }
}
