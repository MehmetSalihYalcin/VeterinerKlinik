 using Klinik.Business.Abstract;
using Klinik.Business.Concrate;
using Klinik.DataAccess.Repositories;
using NuGet.Protocol.Core.Types;

namespace Klinik.WebUI.Extensions
{
    public static class ServiceExtensions
	{
		public static void AddServiceExtensions(this IServiceCollection services)
		{
			services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

			services.AddScoped<IAdminService, AdminMenager>();
			services.AddScoped<IMedicineService, MedicineMenager>();

			// FilmMenager'ı doğrudan kaydedin
			services.AddScoped<AdminMenager>();  // Burayı ekledik
			services.AddScoped<MedicineMenager>();  // Burayı ekledik  
		}

	}
}
