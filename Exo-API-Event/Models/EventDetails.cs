using Exo_API_Event.Fake.Entities;

namespace Exo_API_Event.Models
{
    public class EventDetails
    {
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool Dresscode { get; set; }
        public IEnumerable<Guest> Guests { get; set; }
        public int HowManyInvitationSended
        {
            get => Guests.Count();
        }
        public int HowManyInvitationAccepted
        {
            get => Guests.Count(g => g.IsPresent);
        }
    }
}
