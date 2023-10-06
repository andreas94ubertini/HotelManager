using HotelManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManager.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {

        // GET: Admin
        [HttpGet]
        public ActionResult NewCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCustomer(Customer c)
        {
            Db.NewCustomer(c.Name, c.Surname, c.Cf, c.City, c.Pr, c.Email, c.Tel, c.Cell);
            return RedirectToAction("CustomerList");
        }
        [HttpGet]
        public ActionResult ModifyCustomer(int id)
        {
            Customer c = Db.GetCustomerById(id);
            TempData["Index"] = id;
            return View(c);
        }
        [HttpPost]
        public ActionResult ModifyCustomer(Customer c)
        {
            int id = Convert.ToInt32(TempData["Index"]);
            Db.ModifyCustomer(id, c.Name, c.Surname, c.Cf, c.City, c.Pr, c.Email, c.Tel, c.Cell);
            return RedirectToAction("CustomerList");
        }
        [HttpGet]
        public ActionResult ModifyReservation(int id)
        {
            List<SelectListItem> listDetails = new List<SelectListItem>();
            SelectListItem item1 = new SelectListItem { Text = "Pensione Completa", Value = "Pensione Completa" };
            SelectListItem item2 = new SelectListItem { Text = "Mezza Pensione", Value = "Mezza Pensione" };
            SelectListItem item3 = new SelectListItem { Text = "Solo Colazione", Value = "Solo Colazione" };
            listDetails.Add(item1);
            listDetails.Add(item2);
            listDetails.Add(item3);
            ViewBag.ListDetails = listDetails;
            Reservation r = Db.GetReservationById(id);
            TempData["Index"] = id;
            return View(r);
        }
        [HttpPost]
        public ActionResult ModifyReservation(Reservation r)
        {
            List<SelectListItem> listDetails = new List<SelectListItem>();
            SelectListItem item1 = new SelectListItem { Text = "Pensione Completa", Value = "Pensione Completa" };
            SelectListItem item2 = new SelectListItem { Text = "Mezza Pensione", Value = "Mezza Pensione" };
            SelectListItem item3 = new SelectListItem { Text = "Solo Colazione", Value = "Solo Colazione" };
            listDetails.Add(item1);
            listDetails.Add(item2);
            listDetails.Add(item3);
            ViewBag.ListDetails = listDetails;
            int id = Convert.ToInt32(TempData["Index"]);
            Db.ModifyReservation(id, r.Start, r.EndRes, r.Deposit, r.Price, r.Details);
            return RedirectToAction("ReservationList");
        }
        public ActionResult CustomerList()
        {
            List<Customer> c = Db.GetAllCustomers();
            return View(c);
        }
        public ActionResult ReservationList()
        {
            List<Reservation> r = Db.GetAllReservation();
            return View(r);
        }
        [HttpGet]
        public ActionResult MakeReservation()
        {
            List<SelectListItem> listCustomer = new List<SelectListItem>();
            List<SelectListItem> listRooms = new List<SelectListItem>();
            List<SelectListItem> listDetails = new List<SelectListItem>();
            SelectListItem item1 = new SelectListItem { Text = "Pensione Completa", Value = "Pensione Completa" };
            SelectListItem item2 = new SelectListItem { Text = "Mezza Pensione", Value = "Mezza Pensione" };
            SelectListItem item3 = new SelectListItem { Text = "Solo Colazione", Value = "Solo Colazione" };
            listDetails.Add(item1);
            listDetails.Add(item2);
            listDetails.Add(item3);
            ViewBag.ListDetails = listDetails;
            List<Customer> allCustomers = Db.GetAllCustomers();
            foreach (Customer c in allCustomers)
            {
                SelectListItem item = new SelectListItem { Text = $"{c.Name} {c.Surname}", Value = $"{c.IdCustomer}" };
                listCustomer.Add(item);
            }
            List<Room> allRooms = Db.GetAllRooms();
            foreach (Room r in allRooms)
            {
                SelectListItem item = new SelectListItem { Text = $"Stanza N: {r.RoomNumber}", Value = $"{r.IdRoom}" };
                listRooms.Add(item);
            }
            ViewBag.ListCustomer = listCustomer;
            ViewBag.Listrooms = listRooms;
            return View();
        }
        [HttpPost]
        public ActionResult MakeReservation(Reservation r)
        {
            List<SelectListItem> listCustomer = new List<SelectListItem>();
            List<SelectListItem> listRooms = new List<SelectListItem>();
            List<Customer> allCustomers = Db.GetAllCustomers();
            List<SelectListItem> listDetails = new List<SelectListItem>();
            SelectListItem item1 = new SelectListItem { Text = "Pensione Completa", Value = "Pensione Completa" };
            SelectListItem item2 = new SelectListItem { Text = "Mezza Pensione", Value = "Mezza Pensione" };
            SelectListItem item3 = new SelectListItem { Text = "Solo Colazione", Value = "Solo Colazione" };
            listDetails.Add(item1);
            listDetails.Add(item2);
            listDetails.Add(item3);
            ViewBag.ListDetails = listDetails;
            foreach (Customer c in allCustomers)
            {
                SelectListItem item = new SelectListItem { Text = $"{c.Name} {c.Surname}", Value = $"{c.IdCustomer}" };
                listCustomer.Add(item);
            }
            List<Room> allRooms = Db.GetAllRooms();
            foreach (Room ro in allRooms)
            {
                SelectListItem item = new SelectListItem { Text = $"Stanza N: {ro.RoomNumber}", Value = $"{ro.IdRoom}" };
                listRooms.Add(item);
            }
            ViewBag.Listrooms = listRooms;
            ViewBag.ListCustomer = listCustomer;
            DateTime ResDate = DateTime.Now;
            Db.MakeReservation(ResDate, r.Start, r.EndRes, r.Deposit, r.Price, r.Details, r.IdCustomer, r.IdRooms);
            return RedirectToAction("AddServices");
        }
        [HttpGet]
        public ActionResult AddServices()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddServices(Services s)
        {
            Reservation r = Db.GetLastReservation();
            Db.InsertOpts(s.RoomBr, s.MiniBar, s.Internet, s.AddBed, s.Cradle, r.IdReservation);
            TempData["IdReservation"] = r.IdReservation;
            return RedirectToAction("CheckOut");
        }
        public ActionResult CheckOut()
        {
            int id = Convert.ToInt32(TempData["IdReservation"]);
            CheckOut c = Db.GetCheckOutInfo(id);
            return View(c);
        }
        public ActionResult DetailsReservation(int id)
        {
            CheckOut c = Db.GetCheckOutInfo(id);
            return View(c);
        }
        public ActionResult QueryArea()
        {
            return View();
        }
        public JsonResult GetReservationByCf(string cf)
        {
            List<QueryCf> q = Db.GetReservationByCf(cf);
            return Json(q, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPensioneCompleta()
        {
            List<Reservation> r = Db.GetQueryRes();
            return Json(r, JsonRequestBehavior.AllowGet);
        }
    }
}