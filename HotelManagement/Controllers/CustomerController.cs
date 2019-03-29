using HotelManagement.Models;
using HotelManagement.Models.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Controllers
{
    public class CustomerController : Controller
    {

		HotelEntities bd = new HotelEntities();

		// GET: Customer
		public ActionResult CustomerRegistration()
        {
            return View();
        }


		[HttpPost]
		public JsonResult CustomerRegistration(CustomerViewModel model)
		{
			string message = model.FirstName+ " has been added";
			Customerz cs = new Customerz();
			cs.Company = model.Company;
			cs.Email = model.Email;
			cs.FirstName = model.FirstName;
			cs.LastName = model.LastName;
			cs.Password = model.Password;


			foreach (var cust in bd.Customerz)
			{

				if (cust.Email == model.Email)
				{
					message = cust.FirstName+" already Exist, please Log in";
					return Json(message, JsonRequestBehavior.AllowGet);
				}

			}

			bd.Customerz.Add(cs);
			bd.SaveChanges();

			return Json(message, JsonRequestBehavior.AllowGet);
		}


		public ActionResult Login() {

			return View();
		}

		[HttpPost]
		public JsonResult Login(CustomerViewModel model)
		{
			string result = "fail";
			var customer= bd.Customerz.SingleOrDefault(x=>x.Email==model.Email && x.Password==model.Password);

			if (customer != null) {

				Session["CustomerID"] = customer.CustomerID;
				Session["FirstName"] = customer.FirstName;

				result = "exist";

			}

			var re= Json(result, JsonRequestBehavior.AllowGet);
			return Json(result,JsonRequestBehavior.AllowGet);
		}

		
		public ActionResult Reservation()
		{


			return View();
		}

		public ActionResult LogOut()
		{
			Session.Clear();
			Session.Abandon();

			return RedirectToAction("Login");
		}

		public ActionResult GetCustomers()
		{

			var list = bd.Customerz.ToList();
			return View(list);
		}



		[HttpPost]
		public JsonResult DeleteCustomer(int custID)
		{

			var customer= bd.Customerz.Find(custID);
			bd.Customerz.Remove(customer);
			bd.SaveChanges();

			return Json(customer.FirstName, JsonRequestBehavior.AllowGet);
		}

		//[HttpPost]
		public string DeleteCustomer()
		{

			return "";
		}



	}
}