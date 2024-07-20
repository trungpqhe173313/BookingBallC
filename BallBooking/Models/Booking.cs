using System;
using System.Collections.Generic;

namespace BallBooking.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int? UserId { get; set; }

    public int? FieldId { get; set; }

    public DateOnly BookingDate { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public int StatusId { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual Field? Field { get; set; }

    public virtual Status Status { get; set; } = null!;

    public virtual User? User { get; set; }
}
