using BallBuddies.Models.Enums;

namespace BallBuddies.Models.RequestFeatures
{
    public class EventParameters: RequestParameters
    {
        public EventParameters() => OrderBy = "newest";
        public SportCategory Category { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public uint? MinSlots { get; set; }
        public uint? MaxSlots { get; set; }
        public string? SearchTerm { get; set; }

    }
}
