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
			value.MedicineRealStok = create.MedicinePiece;
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

		public IActionResult HaftalikRapor(int page = 1)
		{
			var today = DateTime.Today; // Current date (e.g., 2025-10-26)

			// Calculate the start of the week (Monday)
			var startOfWeek = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday);
			if (today.DayOfWeek == DayOfWeek.Sunday)
			{
				startOfWeek = startOfWeek.AddDays(-7); // If today is Sunday, use previous Monday
			}

			// Get medicines from Monday to today (inclusive)
			var medicines = _medicineMenager.TGetList()
				.Where(m => m.CreateDate.Date >= startOfWeek && m.CreateDate.Date <= today)
				.OrderBy(m => m.CreateDate)
				.ToList();

			// Map to DTO and apply pagination
			var modelList = _mapper.Map<List<ResultMedicineDTO>>(medicines).ToPagedList(page, 10);

			ViewBag.StartOfWeek = startOfWeek.ToString("dd/MM/yyyy");
			ViewBag.EndOfWeek = today.ToString("dd/MM/yyyy");
			return View(modelList);
		}

		public IActionResult AylikRapor(int page = 1)
		{
			var today = DateTime.Today; // Current date (e.g., 2025-10-26)

			// Calculate the start of the month
			var startOfMonth = new DateTime(today.Year, today.Month, 1);

			// Get medicines from the start of the month to today (inclusive)
			var medicines = _medicineMenager.TGetList()
				.Where(m => m.CreateDate.Date >= startOfMonth && m.CreateDate.Date <= today)
				.OrderBy(m => m.CreateDate)
				.ToList();

			// Map to DTO and apply pagination
			var modelList = _mapper.Map<List<ResultMedicineDTO>>(medicines).ToPagedList(page, 10);

			ViewBag.StartOfMonth = startOfMonth.ToString("dd/MM/yyyy");
			ViewBag.EndOfMonth = today.ToString("dd/MM/yyyy");
			return View(modelList);
		}
	}
}
