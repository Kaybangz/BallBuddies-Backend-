using BallBuddies.Models.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBuddies.Models.Dtos.Response
{
    public class EventResponseDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? EventImageUrl { get; set; }
        public string Location { get; set; } = null!;
        public string State { get; set; } = null!;
        public string City { get; set; } = null!;
        public DateTime EventDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public SportCategory Category { get; set; }
        public EventStatus Status { get; set; }
    }
}
