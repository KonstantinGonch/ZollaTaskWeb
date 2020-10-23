using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestTaskWebApp.Models
{
	public class Merchandize
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		public long Id { get; set; }
		/// <summary>
		/// Наименование
		/// </summary>
		[Required]
		public string Name { get; set; }
		/// <summary>
		/// Стоимость
		/// </summary>
		[Required]
		public double Price { get; set; }

		[ForeignKey("Client")]
		public long ClientId { get; set; }
		/// <summary>
		/// Ссылка на клиента
		/// </summary>
		public Client Client { get; set; }
	}
}