using System;
using System.Collections.Generic;

namespace LabTrack.Entites;

public partial class Patient
{
    public int IdPatient { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? Gender { get; set; }

    public DateOnly? Birthdate { get; set; }

    public string? PassportSeries { get; set; }

    public string? PassportNumber { get; set; }

    public string? PassportIssuedBy { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? InsurancePolicyNumber { get; set; }

    public DateOnly? InsurancePolicyEndDate { get; set; }

    public string? MedicalCardNumber { get; set; }

    public DateOnly? MedicalCardStartDate { get; set; }

    public byte[]? Photo { get; set; }

    public DateOnly? DateLastVisit { get; set; }

    public DateOnly? DateNextVisit { get; set; }

    public string? HealthHistory { get; set; }

    public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

    public virtual ICollection<PatientDoctorAppointment> PatientDoctorAppointments { get; set; } = new List<PatientDoctorAppointment>();
}
