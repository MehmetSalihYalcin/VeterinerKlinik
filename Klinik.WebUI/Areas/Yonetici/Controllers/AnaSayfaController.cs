using AutoMapper;
using Klinik.Business.Concrate;
using Klinik.DTO.MedicineDTOS;
using Klinik.Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using PagedList;

namespace Klinik.WebUI.Areas.Yonetici.Controllers
{
	[Area("Yonetici")]
	[Authorize]
	public class AnaSayfaController : Controller
	{
		protected readonly MedicineMenager _medicineMenager;
		protected readonly IMapper _mapper;

		public AnaSayfaController(MedicineMenager medicineMenager, IMapper mapper)
		{
			_medicineMenager = medicineMenager;
			_mapper = mapper;
		}

		public IActionResult Index(int page = 1, string searchTerm = "")
		{

			var data = _medicineMenager.TGetList().OrderBy(x => x.CreateDate);
			var modelList = _mapper.Map<List<ResultMedicineDTO>>(data);
			// Eğer arama yapılmışsa, burada filtreleme yapılır
			if (!string.IsNullOrEmpty(searchTerm))
			{
				modelList = modelList.Where(p => p.SerialNumber.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || p.MedicineName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || p.MedicineDescription.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
			}

			var pagedMedicine = modelList.ToPagedList(page, 10);
			return View(pagedMedicine);
		}

		[HttpGet]
		public IActionResult IlacEkle()
		{
			return View();
		}
		[HttpPost]
		public IActionResult IlacEkle(CreateMedicineDTO create)
		{
			var value = _mapper.Map<Medicine>(create);
			_medicineMenager.TCreate(value);
			return Redirect("/Yonetici/AnaSayfa/Index");
		}
		[HttpGet]
		public IActionResult IlacGuncelle(Guid Id)
		{
			var model = _medicineMenager.TGetById(Id);
			var updateModel = _mapper.Map<ResultMedicineDTO>(model);
			return View(updateModel);
		}
		[HttpPost]
		public IActionResult IlacGuncelle(UpdateMedicineDTO update)
		{
			var model = _medicineMenager.TGetById(update.Id);
			model.SerialNumber = update.SerialNumber;
			model.MedicineName = update.MedicineName;
			model.MedicineDescription = update.MedicineDescription;
			model.MedicinePrice = update.MedicinePrice;
			model.MedicinePiece = update.MedicinePiece;
			_medicineMenager.TUpdate(model);
			return Redirect("/Yonetici/AnaSayfa/Index");
		}

		public IActionResult IlacSil(Guid Id)
		{
			_medicineMenager.TDelete(Id);
			return Redirect("/Yonetici/AnaSayfa/Index");
		}
	}
}
