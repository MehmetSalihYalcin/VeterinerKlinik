using AutoMapper;
using Klinik.DTO.MedicineDTOS;
using Klinik.Entity.Models;

namespace Klinik.WebUI.Mappings
{
	public class MedicineMapping : Profile
	{
		public MedicineMapping()
		{
			CreateMap<CreateMedicineDTO, Medicine>().ReverseMap(); // mapple ve tam tersini mapple
			CreateMap<UpdateMedicineDTO, Medicine>().ReverseMap(); // mapple ve tam tersini mapple
			CreateMap<ResultMedicineDTO, Medicine>().ReverseMap(); // mapple ve tam tersini mapple
		}
	}
}
