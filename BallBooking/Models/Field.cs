using System;
using System.Collections.Generic;

namespace BallBooking.Models;

public partial class Field
{
    public int FieldId { get; set; }

    public string FieldName { get; set; } = null!;

    public string? Location { get; set; }

    public string? Description { get; set; }

    public decimal PricePerHour { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
