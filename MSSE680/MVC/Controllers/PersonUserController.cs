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
    [Authorize(Roles = "User")]
    public class PersonUserController : Controller
    {
        private bullerEntities db = new bullerEntities();
        private PersonMgr personMgr = new PersonMgr();
        private AddressMgr addressMgr = new AddressMgr();

        //
        // GET: /Person/

        public ActionResult Index()
        {
            //var people = db.People.Include(p => p.Address);
            //return View(people.ToList());
            //return View(personMgr.RetrieveAllPeople().ToList());
            return View(personMgr.RetrievePerson("PersonId", WebSecurity.CurrentUserId));
        }

        //
        // GET: /Person/Details/5

        public ActionResult Details(int id = 0)
        {
            //Person person = db.People.Find(id);
            Person person = personMgr.RetrievePerson("PersonId", id);
    
            return View(person);
        }

        //
        // GET: /Person/Create

        public ActionResult Create()
        {
            //ViewBag.Address_AddressId = new SelectList(db.Addresses, "AddressId", "AddressId");
            ViewBag.Address_AddressId = new SelectList(addressMgr.RetrieveAllAddresses(), "AddressId", "AddressId");
            return View();
        }

        //
        // POST: /Person/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                //db.People.Add(person);
                //db.SaveChanges();
                personMgr.CreatePerson(person);
                return RedirectToAction("Index");
            }

            //ViewBag.Address_AddressId = new SelectList(db.Addresses, "AddressId", "AddressId", person.Address_AddressId);
            ViewBag.Address_AddressId = new SelectList(addressMgr.RetrieveAllAddresses(), "AddressId", "AddressId", person.Address_AddressId);
            
            return View(person);
        }

        //
        // GET: /Person/Edit/5

        public ActionResult Edit(int id = 0)
        {
            //Person person = db.People.Find(id);
            Person person = personMgr.RetrievePerson("PersonId", WebSecurity.CurrentUserId);
            if (person == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Address_AddressId = new SelectList(db.Addresses, "AddressId", "AddressId", person.Address_AddressId);
            ViewBag.Address_AddressId = new SelectList(addressMgr.RetrieveAllAddresses(), "AddressId", "AddressId", person.Address_AddressId);
            return View(person);
        }

        //
        // POST: /Person/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(person).State = EntityState.Modified;
                //db.SaveChanges();
                personMgr.ModifyPerson(person);
                return RedirectToAction("Index");
            }
            //ViewBag.Address_AddressId = new SelectList(db.Addresses, "AddressId", "AddressId", person.Address_AddressId);
            ViewBag.Address_AddressId = new SelectList(addressMgr.RetrieveAllAddresses(), "AddressId", "AddressId", person.Address_AddressId);
            return View(person);
        }

        //
        // GET: /Person/Delete/5

        public ActionResult Delete(int id = 0)
        {
            //Person person = db.People.Find(id);
            Person person = personMgr.RetrievePerson("PersonId", id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        //
        // POST: /Person/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Person person = db.People.Find(id);
            //db.People.Remove(person);
            //db.SaveChanges();
            Person person = personMgr.RetrievePerson("PersonId", id);
            personMgr.RemovePerson(person);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //db.Dispose();
            personMgr.DisposePerson();
            base.Dispose(disposing);
        }
    }
}