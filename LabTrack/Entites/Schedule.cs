using System;
using System.Collections.Generic;

namespace LabTrack.Entites;

public partial class Schedule
{
    public int IdSchedule { get; set; }

    public DateOnly? ScheduleDate { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public int? IdDoctor { get; set; }

    public virtual Doctor? IdDoctorNavigation { get; set; }

    public virtual ICollection<ReservationSchedule> ReservationSchedules { get; set; } = new List<ReservationSchedule>();

    public virtual ICollection<ScheduleException> ScheduleExceptions { get; set; } = new List<ScheduleException>();
}
