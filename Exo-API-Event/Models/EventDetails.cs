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
    }
}
