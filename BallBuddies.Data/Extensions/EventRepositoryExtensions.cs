using BallBuddies.Models.Entities;

namespace BallBuddies.Data.Extensions
{
    public static class EventRepositoryExtensions
    {
       /* public static IQueryable<Event> FilterEventsByPrice(this IQueryable<Event> query,
            decimal minPrice,
            decimal maxPrice,
            DateTime currentDate,
            DateTime nextWeekDate,
            DateTime nextMonthDate)
        {
            if 
        }
            */


        public static IQueryable<Event> Search(this IQueryable<Event> query,
            string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return query;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return query.Where(e => e.Name.ToLower().Contains(lowerCaseTerm) ||
                                    e.Venue.ToLower().Contains(lowerCaseTerm) ||
                                    e.City.ToLower().Contains(lowerCaseTerm) ||
                                    e.State.ToLower().Contains(lowerCaseTerm));
        }
    }
}
