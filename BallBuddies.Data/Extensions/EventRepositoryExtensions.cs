using BallBuddies.Models.Entities;
using System.Linq.Dynamic.Core;
using BallBuddies.Models.Enums;
using System.Reflection;
using System.Text;

namespace BallBuddies.Data.Extensions
{
    public static class EventRepositoryExtensions
    {
        public static IQueryable<Event> FilterEventsByPrice(this IQueryable<Event> query,
            decimal? minPrice,
            decimal? maxPrice,
            uint? minSlots,
            uint? maxSlots,
            SportCategory? category
            )
        {
            if(minPrice.HasValue)
                query = query.Where(e => e.Price >= minPrice);

            if(maxPrice.HasValue)
                query = query.Where(e => e.Price <= maxPrice);

            if(minSlots.HasValue)
                query = query.Where(e => e.Slots >= minSlots);

            if(maxSlots.HasValue)
                query = query.Where(e => e.Slots  <= maxSlots); 
            
            if(category.HasValue)
                query = query.Where(e =>e.Category >= category.Value);


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



        public static IQueryable<Event> Sort(this IQueryable<Event> events,
            string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return events.OrderBy(e => e.CreatedAt);

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(Event).GetProperties(BindingFlags.Public 
                | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach( var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0];

                var objectProperty = propertyInfos.FirstOrDefault(pi =>
                pi.Name.Equals(propertyFromQueryName, StringComparison
                .InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";

                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            if(string.IsNullOrWhiteSpace(orderQuery))
                return events.OrderBy(e => e.CreatedAt);

            return events.OrderBy(orderQuery);
        }
    }
}
