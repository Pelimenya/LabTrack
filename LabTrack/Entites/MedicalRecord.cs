using System;
using System.Collections.Generic;

namespace LabTrack.Entites;

public partial class MedicalRecord
{
    public int IdMedicalRecord { get; set; }

    public string? Recommendations { get; set; }

    public string? Diagnosis { get; set; }

    public string? Prescriptions { get; set; }

    public int? IdPatient { get; set; }

    public int? IdDoctor { get; set; }

    public virtual Doctor? IdDoctorNavigation { get; set; }

    public virtual Patient? IdPatientNavigation { get; set; }
}
