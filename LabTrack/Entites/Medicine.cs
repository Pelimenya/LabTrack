using System;
using System.Collections.Generic;

namespace LabTrack.Entites;

public partial class Medicine
{
    public int IdMedicine { get; set; }

    public string MedicineName { get; set; } = null!;

    public string TradeName { get; set; } = null!;

    public string Manufacturer { get; set; } = null!;

    public byte[]? Image { get; set; }

    public int Price { get; set; }

    public int StockQuantity { get; set; }

    public int IdWarehouse { get; set; }

    public virtual Warehouse IdWarehouseNavigation { get; set; } = null!;
}
