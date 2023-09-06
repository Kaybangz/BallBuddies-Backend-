using BallBuddies.Models.Entities;
using BallBuddies.Models.Enums;

namespace BallBuddies.Data.Extensions
{
    public static class EventRepositoryExtensions
    {
        public static IQueryable<Event> FilterEventsByPrice(this IQueryable<Event> query,
            decimal? minPrice,
            decimal? maxPrice,
            uint? minSlots,
            uint? maxSlots
            /*SportCategory category*/
            /*DateTime? currentDate,
            DateTime? nextWeekDate,
            DateTime nextMonthDate*/)
        {
            if(minPrice.HasValue)
                query = query.Where(e => e.Price >= minPrice);

            if(maxPrice.HasValue)
                query = query.Where(e => e.Price <= maxPrice);

            if(minSlots.HasValue)
                query = query.Where(e => e.Slots >= minSlots);

            if(maxSlots.HasValue)
                query = query.Where(e => e.Slots  <= maxSlots);   


            return query;
        }
            


        public static IQueryable<Event> Search(this IQueryable<Event> query,
            string? searchTerm)
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
