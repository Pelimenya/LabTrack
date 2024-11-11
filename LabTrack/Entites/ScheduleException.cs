using System;
using System.Collections.Generic;

namespace LabTrack.Entites;

public partial class ScheduleException
{
    public int IdException { get; set; }

    public string? ExceptionDescription { get; set; }

    public int? IdSchedule { get; set; }

    public DateOnly? ExceptionDate { get; set; }

    public TimeOnly? ExceptionTime { get; set; }

    public virtual Schedule? IdScheduleNavigation { get; set; }
}
