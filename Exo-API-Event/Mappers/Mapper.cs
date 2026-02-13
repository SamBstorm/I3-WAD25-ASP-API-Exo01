using Exo_API_Event.Fake.Entities;
using Exo_API_Event.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exo_API_Event.Mappers
{
    public static class Mapper
    {
        #region Event
        public static EventDetails ToDetails(this Event entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new EventDetails
            {
                Date = DateOnly.FromDateTime(entity.Date),
                StartTime = TimeOnly.FromDateTime(entity.StartTime),
                EndTime = TimeOnly.FromDateTime(entity.EndTime),
                Title = entity.Title,
                Description = entity.Description,
                Dresscode = entity.Dresscode
            };
        }
        #endregion
    }
}
