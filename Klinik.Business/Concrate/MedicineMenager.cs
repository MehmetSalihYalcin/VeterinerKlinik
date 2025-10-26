 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinik.Business.Abstract;
using Klinik.Entity.Models;

namespace Klinik.Business.Concrate
{
	public class MedicineMenager : GenericMenager<Medicine>,IMedicineService
	{
		public MedicineMenager(IRepository<Medicine> _repository) : base(_repository)
		{
		}
	}
}
