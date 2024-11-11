using System;
using System.Collections.Generic;

namespace LabTrack.Entites;

public partial class ReservationSchedule
{
    public int IdReservationSchedule { get; set; }

    public DateOnly? ReservationDate { get; set; }

    public TimeOnly? ReservationStartTime { get; set; }

    public TimeOnly? ReservationEndTime { get; set; }

    public int? IdSchedule { get; set; }

    public int? IdRoomReservation { get; set; }

    public virtual RoomReservation? IdRoomReservationNavigation { get; set; }

    public virtual Schedule? IdScheduleNavigation { get; set; }
}
