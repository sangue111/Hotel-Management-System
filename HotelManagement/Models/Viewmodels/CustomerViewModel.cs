using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Models.Viewmodels
{
	public class CustomerViewModel
	{
		public string Email { get; set; }
		public string Company { get; set; }
		public Nullable<decimal> Discount { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}