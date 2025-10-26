using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinik.DTO.AdminDTOS
{
	public class ResultAdminDTO
	{
		public Guid Id { get; set; }
		public DateTime CreateDate { get; set; }
		public string UserName { get; set; } = null!;
		public string Password { get; set; } = null!; 
	}
}
