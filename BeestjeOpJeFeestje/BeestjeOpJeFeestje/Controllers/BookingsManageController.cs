using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeestjeOpJeFeestje.Core;
using BeestjeOpJeFeestje.Core.Interfaces;
using BeestjeOpJeFeestje.Infrastructure;
using BeestjeOpJeFeestje.Models;

namespace BeestjeOpJeFeestje.Controllers
{
    public class BookingsManageController : Controller
    {
        private IBookingRepository dbBooking;
        private IAccesoryRepository dbAccessory;
        private IAnimalRepository dbAnimal;
        private ICustomerRepository dbCustomer;

        public BookingsManageController(IBookingRepository db1, IAccesoryRepository db2, IAnimalRepository db3, ICustomerRepository db4)
        {
            this.dbBooking = db1;
            this.dbAccessory = db2;
            this.dbAnimal = db3;
            this.dbCustomer = db4;
        }

        // GET: BookingsManage
        public ActionResult Index(BookingViewModel bookVM)
        {
            bookVM.Bookings = dbBooking.GetBookings().Where(q => q.IsConfirmed != null).ToList();
            return View(bookVM);
        }

        // GET: BookingsManage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = dbBooking.GetBookings().ToList().SingleOrDefault(q => q.Id == id);
            //Customer customer = dbCustomer.GetCustomers().ToList().SingleOrDefault(q => q.Id == );
            if (booking == null)
            {
                return HttpNotFound();
            }
            var bookVM = new BookingViewModel();

            bookVM.Booking.Id = booking.Id;
            bookVM.Booking.Date = booking.Date;
            bookVM.Booking.Payment = booking.Payment;
            bookVM.Booking.Discount = booking.Discount;
            bookVM.Booking.IsConfirmed = booking.IsConfirmed;
            //bookVM.Animals = booking.Animals.ToList();
            //bookVM.Customer.Name = customer.Name;

            return View(bookVM);
        }

        // GET: BookingsManage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = dbBooking.GetBookings().ToList().SingleOrDefault(q => q.Id == id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            var bookVM = new BookingViewModel();

            bookVM.Booking.Id = booking.Id;
            bookVM.Booking.Date = booking.Date;
            bookVM.Booking.Payment = booking.Payment;
            bookVM.Booking.Discount = booking.Discount;
            bookVM.Booking.IsConfirmed = booking.IsConfirmed;

            return View(bookVM);
        }

        // POST: BookingsManage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dbBooking.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
            base.Dispose(disposing);
        }
    }
}
