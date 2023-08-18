using BallBuddies.Models.Dtos.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;


namespace BallBuddies.Services
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }



        protected override bool CanWriteType(Type? type)
        {
            if(typeof(EventResponseDto).IsAssignableFrom(type)
                || typeof(IEnumerable<EventResponseDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }

            return false;
        }


        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context,
            Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();

            if(context.Object is IEnumerable<EventResponseDto>)
            {
                foreach(var item in (IEnumerable<EventResponseDto>)context.Object)
                {
                    FormatCsv(buffer, item);
                }
            }
            else
            {
                FormatCsv(buffer, (EventResponseDto)context.Object);
            }

            await response.WriteAsync(buffer.ToString());
        }

        private static void FormatCsv(StringBuilder buffer, EventResponseDto eventResponse)
        {
            buffer.AppendLine($"{eventResponse.Id}," +
                $"\"{eventResponse.Name}," +
                $"\"{eventResponse.Description}," +
                $"\"{eventResponse.Price}\"," +
                $"\"{eventResponse.EventImageUrl}\"," +
                $"\"{eventResponse.Venue}\"," +
                $"\"{eventResponse.State}\"," +
                $"\"{eventResponse.City}\"," +
                $"\"{eventResponse.EventStartDate}\"," +
                $"\"{eventResponse.EventEndDate}\"," +
                $"\"{eventResponse.CreatedAt}\"," +
                $"\"{eventResponse.Category}\",");
        }
    }
}
