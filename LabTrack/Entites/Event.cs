using System;
using System.Collections.Generic;

namespace LabTrack.Entites;

public partial class Event
{
    public int IdEvent { get; set; }

    public string? EventType { get; set; }

    public DateOnly? EventDate { get; set; }

    public TimeOnly? EventStartTime { get; set; }

    public TimeOnly? EventEndTime { get; set; }

    public int? IdRoomReservation { get; set; }

    public virtual RoomReservation? IdRoomReservationNavigation { get; set; }
}
