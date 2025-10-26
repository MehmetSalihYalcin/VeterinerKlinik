using System;
using System.Collections.Generic;
using Klinik.Entity.Models.Base;

namespace Klinik.Entity.Models;

public partial class Medicine:BaseClass
{  
    public string SerialNumber { get; set; } = null!; 
    public string MedicineName { get; set; } = null!; 
    public string MedicineDescription { get; set; } = null!; 
    public string MedicinePrice { get; set; } 
    public int MedicinePiece { get; set; } 
    public int MedicineRealStok { get; set; } 
}
