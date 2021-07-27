using System;
using System.Collections.Generic;
using WebApi.Data;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class Shippers : IEntity
    {
		public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
	}
}
