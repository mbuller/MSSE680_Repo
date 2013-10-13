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
    [Authorize(Roles = "User")]
    public class TransactionUserController : Controller
    {
        private bullerEntities db = new bullerEntities();
        private PersonMgr personMgr = new PersonMgr();
        private AddressMgr addressMgr = new AddressMgr();
        private CreditCardMgr ccMgr = new CreditCardMgr();
        private AccountMgr accountMgr = new AccountMgr();
        private TransactionMgr transactionMgr = new TransactionMgr();

        //
        // GET: /Transaction/

        public ActionResult Index()
        {
            //var transactions = db.Transactions.Include(t => t.CreditCard);
            //return View(transactions.ToList());
            return View(transactionMgr.RetrieveAllTransactions().ToList());
        }

        //
        // GET: /Transaction/Details/5

        public ActionResult Details(int id = 0)
        {
            //Transaction transaction = db.Transactions.Find(id);
            Transaction transaction = transactionMgr.RetrieveTransaction("TransactionId", id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        //
        // GET: /Transaction/Create

        public ActionResult Create()
        {
            //ViewBag.CreditCard_CreditCardId = new SelectList(db.CreditCards, "CreditCardId", "CreditCardId");
            ViewBag.CreditCard_CreditCardId = new SelectList(ccMgr.RetrieveAllCreditCards(), "CreditCardId", "CreditCardId");
            return View();
        }

        //
        // POST: /Transaction/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                //db.Transactions.Add(transaction);
                //db.SaveChanges();
                transactionMgr.CreateTransaction(transaction);
                return RedirectToAction("Index");
            }

            //ViewBag.CreditCard_CreditCardId = new SelectList(db.CreditCards, "CreditCardId", "CreditCardId", transaction.CreditCard_CreditCardId);
            ViewBag.CreditCard_CreditCardId = new SelectList(ccMgr.RetrieveAllCreditCards(), "CreditCardId", "CreditCardId", transaction.CreditCard_CreditCardId);
            return View(transaction);
        }

        //
        // GET: /Transaction/Edit/5

        public ActionResult Edit(int id = 0)
        {
            //Transaction transaction = db.Transactions.Find(id);
            Transaction transaction = transactionMgr.RetrieveTransaction("TransactionId", id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CreditCard_CreditCardId = new SelectList(db.CreditCards, "CreditCardId", "CreditCardId", transaction.CreditCard_CreditCardId);
            ViewBag.CreditCard_CreditCardId = new SelectList(ccMgr.RetrieveAllCreditCards(), "CreditCardId", "CreditCardId", transaction.CreditCard_CreditCardId);
            return View(transaction);
        }

        //
        // POST: /Transaction/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(transaction).State = EntityState.Modified;
                //db.SaveChanges();
                transactionMgr.ModifyTransaction(transaction);
                return RedirectToAction("Index");
            }
            //ViewBag.CreditCard_CreditCardId = new SelectList(db.CreditCards, "CreditCardId", "CreditCardId", transaction.CreditCard_CreditCardId);
            ViewBag.CreditCard_CreditCardId = new SelectList(ccMgr.RetrieveAllCreditCards(), "CreditCardId", "CreditCardId", transaction.CreditCard_CreditCardId);
            return View(transaction);
        }

        //
        // GET: /Transaction/Delete/5

        public ActionResult Delete(int id = 0)
        {
            //Transaction transaction = db.Transactions.Find(id);
            Transaction transaction = transactionMgr.RetrieveTransaction("TransactionId", id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        //
        // POST: /Transaction/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Transaction transaction = db.Transactions.Find(id);
            //db.Transactions.Remove(transaction);
            //db.SaveChanges();
            Transaction trasaction = transactionMgr.RetrieveTransaction("TransactionId", id);
            transactionMgr.RemoveTransaction(trasaction);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            transactionMgr.DisposeTransaction();
            //db.Dispose();
            base.Dispose(disposing);
        }
    }
}