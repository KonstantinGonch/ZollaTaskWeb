using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTaskWebApp.Models
{
	public class MerchandizeListViewModel
	{
		public IEnumerable<Merchandize> Merchandize { get; set; }
		public long ClientId { get; set; }
	}
}