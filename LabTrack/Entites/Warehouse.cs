using System;
using System.Collections.Generic;

namespace LabTrack.Entites;

public partial class Warehouse
{
    public int IdWarehouse { get; set; }

    public string WarehouseName { get; set; } = null!;

    public virtual ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();
}
