using System;
using System.Collections.Generic;
using Klinik.Entity.Models.Base;

namespace Klinik.Entity.Models;

public partial class Admin:BaseClass
{ 
	public string UserName { get; set; } = null!; 
    public string Password { get; set; } = null!; 
}
