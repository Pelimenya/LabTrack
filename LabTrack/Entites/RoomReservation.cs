using System;
using System.Collections.Generic;

namespace LabTrack.Entites;

public partial class RoomReservation
{
    public int IdRoomReservation { get; set; }

    public string? RoomType { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<ReservationSchedule> ReservationSchedules { get; set; } = new List<ReservationSchedule>();
}
