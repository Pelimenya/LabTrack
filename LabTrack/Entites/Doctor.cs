using System;
using System.Collections.Generic;

namespace LabTrack.Entites;

public partial class Doctor
{
    public int IdDoctor { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public int? IdSpecialization { get; set; }

    public virtual Specialization? IdSpecializationNavigation { get; set; }

    public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

    public virtual ICollection<PatientDoctorAppointment> PatientDoctorAppointments { get; set; } = new List<PatientDoctorAppointment>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
