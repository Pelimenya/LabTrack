using System;
using System.Collections.Generic;

namespace LabTrack.Entites;

public partial class Specialization
{
    public int IdSpecialization { get; set; }

    public string? SpecializationName { get; set; }

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
