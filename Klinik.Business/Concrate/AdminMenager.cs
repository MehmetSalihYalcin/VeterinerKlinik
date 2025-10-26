using Klinik.Business.Abstract;
using Klinik.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinik.Business.Concrate
{
	public class AdminMenager : GenericMenager<Admin>, IAdminService
	{
		public AdminMenager(IRepository<Admin> _repository) : base(_repository)
		{
		}
	}
}
