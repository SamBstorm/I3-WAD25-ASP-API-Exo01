using Exo_API_Event.Fake.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exo_API_Event.Fake.Services
{
    public class FakeContext : IContext
    {
        private static Event _event;
        private static List<Guest> _guests;
        public Event Event { 
            get => _event;
            set => _event = value;
        }
        public IEnumerable<Guest> Guests { 
            get => _guests; 
            set => _guests = value.ToList(); 
        }

        public FakeContext()
        {
            _event ??= new Event()
            {
                Date = DateTime.Now,
                StartTime = new DateTime(1, 1, 1, 17, 0, 0),
                EndTime = new DateTime(1, 1, 1, 19, 30, 0),
                Title = "After work : WAD25",
                Description = "Fiesta après les cours, fêtons dignement le vendredi 13 et la veille de Saint-Valentin!",
                Dresscode = false
            };
            _guests ??= new List<Guest>()
            {
                new Guest(){ Id = 1, FirstName="Laura", LastName="Coudyzer", IsPresent = true },
                new Guest(){ Id = 2, FirstName="Yuliia", LastName="Krempolska", IsPresent = false },
                new Guest(){ Id = 3, FirstName="Chuong", LastName="Tran", IsPresent = true },
                new Guest(){ Id = 4, FirstName="Orsula", LastName="Karmous", IsPresent = true },
                new Guest(){ Id = 5, FirstName="Chloé", LastName="Fersing", IsPresent = true },
                new Guest(){ Id = 6, FirstName="Ceren", LastName="Dogan", IsPresent = true }
            };
        }
    }
}
