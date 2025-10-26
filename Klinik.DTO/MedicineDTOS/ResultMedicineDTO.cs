using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinik.DTO.MedicineDTOS
{
	public class ResultMedicineDTO
	{
		public Guid Id { get; set; }
		public DateTime CreateDate { get; set; }
		public string SerialNumber { get; set; } = null!;
		public string MedicineName { get; set; } = null!;
		public string MedicineDescription { get; set; } = null!;
		public string MedicinePrice { get; set; }
		public int MedicinePiece { get; set; }
		public int MedicineRealStok { get; set; }
	}
}
