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
    public class AccountController : Controller
    {
        private bullerEntities db = new bullerEntities();
        private PersonMgr personMgr = new PersonMgr();
        private AddressMgr addressMgr = new AddressMgr();
        private CreditCardMgr ccMgr = new CreditCardMgr();
        private AccountMgr accountMgr = new AccountMgr();

        //
        // GET: /Account/

        public ActionResult Index()
        {
            //var accounts = db.Accounts.Include(a => a.CreditCard).Include(a => a.AccountUser);
            //return View(accounts.ToList());
            return View(accountMgr.RetrieveAllAccounts().ToList());
        }

        //
        // GET: /Account/Details/5

        public ActionResult Details(int id = 0)
        {
            //Account account = db.Accounts.Find(id);
            Account account = accountMgr.RetrieveAccount("AccountId", id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        //
        // GET: /Account/Create

        public ActionResult Create()
        {
            //ViewBag.CreditCard_CreditCardId = new SelectList(db.CreditCards, "CreditCardId", "CreditCardId");
            //ViewBag.AccountUser_PersonId = new SelectList(db.People, "PersonId", "PersonId");
            ViewBag.CreditCard_CreditCardId = new SelectList(ccMgr.RetrieveAllCreditCards(), "CreditCardId", "CreditCardId");
            ViewBag.AccountUser_PersonId = new SelectList(personMgr.RetrieveAllPeople(), "PersonId", "PersonId");
            return View();
        }

        //
        // POST: /Account/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Account account)
        {
            if (ModelState.IsValid)
            {
                //db.Accounts.Add(account);
                //db.SaveChanges();
                accountMgr.CreateAccount(account);
                return RedirectToAction("Index");
            }

            //ViewBag.CreditCard_CreditCardId = new SelectList(db.CreditCards, "CreditCardId", "CreditCardId", account.CreditCard_CreditCardId);
            //ViewBag.AccountUser_PersonId = new SelectList(db.People, "PersonId", "PersonId", account.AccountUser_PersonId);
            ViewBag.CreditCard_CreditCardId = new SelectList(ccMgr.RetrieveAllCreditCards(), "CreditCardId", "CreditCardId", account.CreditCard_CreditCardId);
            ViewBag.AccountUser_PersonId = new SelectList(personMgr.RetrieveAllPeople(), "PersonId", "PersonId", account.AccountUser_PersonId);
            return View(account);
        }

        //
        // GET: /Account/Edit/5

        public ActionResult Edit(int id = 0)
        {
            //Account account = db.Accounts.Find(id);
            Account account = accountMgr.RetrieveAccount("AccountId", id);
            if (account == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CreditCard_CreditCardId = new SelectList(db.CreditCards, "CreditCardId", "CreditCardId", account.CreditCard_CreditCardId);
            //ViewBag.AccountUser_PersonId = new SelectList(db.People, "PersonId", "PersonId", account.AccountUser_PersonId);
            ViewBag.CreditCard_CreditCardId = new SelectList(ccMgr.RetrieveAllCreditCards(), "CreditCardId", "CreditCardId", account.CreditCard_CreditCardId);
            ViewBag.AccountUser_PersonId = new SelectList(personMgr.RetrieveAllPeople(), "PersonId", "PersonId", account.AccountUser_PersonId);
            
            return View(account);
        }

        //
        // POST: /Account/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Account account)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(account).State = EntityState.Modified;
                //db.SaveChanges();
                accountMgr.ModifyAccount(account);
                return RedirectToAction("Index");
            }
            //ViewBag.CreditCard_CreditCardId = new SelectList(db.CreditCards, "CreditCardId", "CreditCardId", account.CreditCard_CreditCardId);
            //ViewBag.AccountUser_PersonId = new SelectList(db.People, "PersonId", "PersonId", account.AccountUser_PersonId);
            ViewBag.CreditCard_CreditCardId = new SelectList(ccMgr.RetrieveAllCreditCards(), "CreditCardId", "CreditCardId", account.CreditCard_CreditCardId);
            ViewBag.AccountUser_PersonId = new SelectList(personMgr.RetrieveAllPeople(), "PersonId", "PersonId", account.AccountUser_PersonId);
            return View(account);
        }

        //
        // GET: /Account/Delete/5

        public ActionResult Delete(int id = 0)
        {
            //Account account = db.Accounts.Find(id);
            Account account = accountMgr.RetrieveAccount("AccountId", id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        //
        // POST: /Account/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Account account = db.Accounts.Find(id);
            //db.Accounts.Remove(account);
            //db.SaveChanges();
            Account account = accountMgr.RetrieveAccount("AccountId", id);
            accountMgr.RemoveAccount(account);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //db.Dispose();
            accountMgr.DisposeAccount();
            base.Dispose(disposing);
        }
    }
}