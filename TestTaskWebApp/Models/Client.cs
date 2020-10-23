using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestTaskWebApp.Models
{
	public class Client
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		public long Id { get; set; }
		/// <summary>
		/// Имя
		/// </summary>
		[Required]
		public string Name { get; set; }
		/// <summary>
		/// Фамилия
		/// </summary>
		[Required]
		public string Surname { get; set; }
		/// <summary>
		/// Номер телефона
		/// </summary>
		[Required]
		public string PhoneNumber { get; set; }

		public void MapFromOther(Client other)
		{
			Name = other.Name;
			Surname = other.Surname;
			PhoneNumber = other.PhoneNumber;
		}
	}
}