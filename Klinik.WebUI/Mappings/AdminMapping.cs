using AutoMapper;
using Klinik.DTO.AdminDTOS;
using Klinik.Entity.Models;

namespace Klinik.WebUI.Mappings
{
	public class AdminMapping : Profile
	{
		public AdminMapping()
		{ 
			CreateMap<ResultAdminDTO, Admin>().ReverseMap(); // mapple ve tam tersini mapple
		}
	}
}
