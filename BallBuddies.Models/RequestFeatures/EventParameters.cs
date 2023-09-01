using BallBuddies.Models.Enums;

namespace BallBuddies.Models.RequestFeatures
{
    public class EventParameters: RequestParameters
    {   
        public SportCategory Category { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public DateTime CurrentDate { get; set; } = DateTime.Today;
        public DateTime NextWeekDate { get; set; } = DateTime.Today.AddDays(7);
        public DateTime NextMonthDate { get; set; } = DateTime.Today.AddMonths(1);
        public uint MinSlots { get; set; }
        public uint MaxSlots { get; set; }
        public string? SearchTerm { get; set; }
    }
}
