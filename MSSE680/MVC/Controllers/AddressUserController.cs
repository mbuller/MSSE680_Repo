using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Business;
using logonTest.Filters;
using WebMatrix.WebData;

namespace logonTest.Controllers
{
    [InitializeSimpleMembership]
    [Authorize(Roles="User")]
    public class AddressUserController : Controller
    {
        private bullerEntities db = new bullerEntities();
        private AddressMgr addressMgr = new AddressMgr();
        private PersonMgr personMgr = new PersonMgr();
        //
        // GET: /Address/

        public ActionResult Index()
        {
            //return View(db.Addresses.ToList());
            //return View(addressMgr.RetrieveAllAddresses().ToList());
            
            Address address = addressMgr.RetrieveAddress("Person_PersonId", (int?)WebSecurity.CurrentUserId);
            if (address == null)
            {
                //     return View();
                // else
                Address address2 = new Address(WebSecurity.CurrentUserId);
                addressMgr.CreateAddress(address2);
                
            }
            return View(addressMgr.RetrieveAddress("Person_PersonId", (int?)WebSecurity.CurrentUserId));
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
                address.Person_PersonId = WebSecurity.CurrentUserId;
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