using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Business;

namespace MvcApplication2.Controllers
{
    public class AddressController : Controller
    {
        private bullerEntities db = new bullerEntities();
        private AddressMgr addressMgr = new AddressMgr();
        //
        // GET: /Address/

        public ActionResult Index()
        {
            //return View(db.Addresses.ToList());
            return View(addressMgr.RetrieveAllAddresses().ToList());
        }

        //
        // GET: /Address/Details/5

        public ActionResult Details(int id = 0)
        {
           // Address address = db.Addresses.Find(id);
            Address address = addressMgr.RetrieveAddress("AddressId", id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        //
        // GET: /Address/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Address/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Address address)
        {
            if (ModelState.IsValid)
            {
                //db.Addresses.Add(address);
                //db.SaveChanges();
                addressMgr.CreateAddress(address);
                return RedirectToAction("Index");
            }

            return View(address);
        }

        //
        // GET: /Address/Edit/5

        public ActionResult Edit(int id = 0)
        {
            //Address address = db.Addresses.Find(id);
            Address address = addressMgr.RetrieveAddress("AddressId", id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        //
        // POST: /Address/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Address address)
        {
            if (ModelState.IsValid)
            {
               // db.Entry(address).State = EntityState.Modified;
               // db.SaveChanges();
                addressMgr.ModifyAddress(address);
                return RedirectToAction("Index");
            }
            return View(address);
        }

        //
        // GET: /Address/Delete/5

        public ActionResult Delete(int id = 0)
        {
            //Address address = db.Addresses.Find(id);
            Address address = addressMgr.RetrieveAddress("AddressId", id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        //
        // POST: /Address/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Address address = db.Addresses.Find(id);
            //db.Addresses.Remove(address);
            //db.SaveChanges();
            Address address = addressMgr.RetrieveAddress("AddressId", id);
            addressMgr.RemoveAddress(address);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //db.Dispose();
            addressMgr.DisposeAddress();
            base.Dispose(disposing);
        }
    }
}