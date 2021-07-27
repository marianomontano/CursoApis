using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClientMvc.Models
{
	public class ShipperModel
	{
		[Required]
		[Key]
		[Display(Name ="Shipper Id")]
		public int Id { get; set; }

		[Required]
		[Display(Name ="Company Name")]
		public string CompanyName { get; set; }

		[Required]
		[Display(Name ="Phone Number")]
		public string Phone { get; set; }

	}
}
