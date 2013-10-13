using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Business;

namespace logonTest.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CreditCardAdminController : Controller
    {
        private bullerEntities db = new bullerEntities();
        private PersonMgr personMgr = new PersonMgr();
        private AddressMgr addressMgr = new AddressMgr();
        private CreditCardMgr ccMgr = new CreditCardMgr();
        private AccountMgr accountMgr = new AccountMgr();

        //
        // GET: /CreditCard/

        public ActionResult Index()
        {
            //var creditcards = db.CreditCards.Include(c => c.Account).Include(c => c.CreditCardUser);
            //return View(creditcards.ToList());
            return View(ccMgr.RetrieveAllCreditCards().ToList());
        }

        //
        // GET: /CreditCard/Details/5

        public ActionResult Details(int id = 0)
        {
            //CreditCard creditcard = db.CreditCards.Find(id);
            CreditCard creditcard = ccMgr.RetrieveCreditCard("CreditCardId", id);
            if (creditcard == null)
            {
                return HttpNotFound();
            }
            return View(creditcard);
        }

        //
        // GET: /CreditCard/Create

        public ActionResult Create()
        {
            //ViewBag.Account_AccountId = new SelectList(db.Accounts, "AccountId", "AccountId");
            //ViewBag.CreditCardUser_PersonId = new SelectList(db.People, "PersonId", "PersonId");
            ViewBag.Account_AccountId = new SelectList(accountMgr.RetrieveAllAccounts(), "AccountId", "AccountId");
            ViewBag.CreditCardUser_PersonId = new SelectList(personMgr.RetrieveAllPeople(), "PersonId", "PersonId");

            return View();
        }

        //
        // POST: /CreditCard/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreditCard creditcard)
        {
            if (ModelState.IsValid)
            {
                //db.CreditCards.Add(creditcard);
                //db.SaveChanges();
                ccMgr.CreateCreditCard(creditcard);
                return RedirectToAction("Index");
            }

            //ViewBag.Account_AccountId = new SelectList(db.Accounts, "AccountId", "AccountId", creditcard.Account_AccountId);
            //ViewBag.CreditCardUser_PersonId = new SelectList(db.People, "PersonId", "PersonId", creditcard.CreditCardUser_PersonId);
            ViewBag.Account_AccountId = new SelectList(accountMgr.RetrieveAllAccounts(), "AccountId", "AccountId",creditcard.Account_AccountId );
            ViewBag.CreditCardUser_PersonId = new SelectList(personMgr.RetrieveAllPeople(), "PersonId", "PersonId", creditcard.CreditCardUser_PersonId);

            
            return View(creditcard);
        }

        //
        // GET: /CreditCard/Edit/5

        public ActionResult Edit(int id = 0)
        {
            //CreditCard creditcard = db.CreditCards.Find(id);
            CreditCard creditcard = ccMgr.RetrieveCreditCard("CreditCardId", id);
            if (creditcard == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Account_AccountId = new SelectList(db.Accounts, "AccountId", "AccountId", creditcard.Account_AccountId);
            //ViewBag.CreditCardUser_PersonId = new SelectList(db.People, "PersonId", "PersonId", creditcard.CreditCardUser_PersonId);
            ViewBag.Account_AccountId = new SelectList(accountMgr.RetrieveAllAccounts(), "AccountId", "AccountId", creditcard.Account_AccountId);
            ViewBag.CreditCardUser_PersonId = new SelectList(personMgr.RetrieveAllPeople(), "PersonId", "PersonId", creditcard.CreditCardUser_PersonId);
            return View(creditcard);
        }

        //
        // POST: /CreditCard/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreditCard creditcard)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(creditcard).State = EntityState.Modified;
                //db.SaveChanges();
                ccMgr.ModifyCreditCard(creditcard);
                return RedirectToAction("Index");
            }
            //ViewBag.Account_AccountId = new SelectList(db.Accounts, "AccountId", "AccountId", creditcard.Account_AccountId);
            //ViewBag.CreditCardUser_PersonId = new SelectList(db.People, "PersonId", "PersonId", creditcard.CreditCardUser_PersonId);
            ViewBag.Account_AccountId = new SelectList(accountMgr.RetrieveAllAccounts(), "AccountId", "AccountId", creditcard.Account_AccountId);
            ViewBag.CreditCardUser_PersonId = new SelectList(personMgr.RetrieveAllPeople(), "PersonId", "PersonId", creditcard.CreditCardUser_PersonId);
            return View(creditcard);
        }

        //
        // GET: /CreditCard/Delete/5

        public ActionResult Delete(int id = 0)
        {
            //CreditCard creditcard = db.CreditCards.Find(id);
            CreditCard creditcard = ccMgr.RetrieveCreditCard("CreditCardId", id);
            if (creditcard == null)
            {
                return HttpNotFound();
            }
            return View(creditcard);
        }

        //
        // POST: /CreditCard/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //CreditCard creditcard = db.CreditCards.Find(id);
            //db.CreditCards.Remove(creditcard);
            //db.SaveChanges();
            CreditCard creditcard = ccMgr.RetrieveCreditCard("CreditCardId", id);
            ccMgr.RemoveCreditCard(creditcard);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //db.Dispose();
            ccMgr.DisposeCreditCard();
            base.Dispose(disposing);
        }
    }
}