using System;
using System.Collections.Generic;

namespace LabTrack.Entites;

public partial class PatientDoctorAppointment
{
    public int? IdPatient { get; set; }

    public int? IdDoctor { get; set; }

    public DateOnly? AppointmentDate { get; set; }

    public TimeOnly? AppointmentStartTime { get; set; }

    public TimeOnly? AppointmentEndTime { get; set; }

    public int IdPatientDoctorAppointment { get; set; }

    public virtual Doctor? IdDoctorNavigation { get; set; }

    public virtual Patient? IdPatientNavigation { get; set; }
}
