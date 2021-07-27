using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Models
{
	public class Region : IEntity
	{
		public int Id { get; set; }
		public string RegionDescription { get; set; }
	}
}
