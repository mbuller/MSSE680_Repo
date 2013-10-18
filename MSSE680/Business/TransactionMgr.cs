using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Service;

namespace Business
{
    public class TransactionMgr : Manager
    {
         public ITransactionSvc transactionSvc;
         public ICreditCardSvc creditCardSvc;


        public TransactionMgr()
        {
            transactionSvc = (ITransactionSvc)GetService("TransactionSvcRepoImpl");
            creditCardSvc = (ICreditCardSvc)GetService("CreditCardSvcRepoImpl");
        }

        public void CreateTransaction(Transaction transaction)
        {
            // ITransactionSvc transactionSvc = (ITransactionSvc)GetService("TransactionSvcRepoImpl");
            transactionSvc.CreateTransaction(transaction);
        }

        public void RemoveTransaction(Transaction transaction)
        {
            // ITransactionSvc transactionSvc = (ITransactionSvc)GetService("TransactionSvcRepoImpl");
            transactionSvc.RemoveTransaction(transaction);

        }

        public void ModifyTransaction(Transaction transaction)
        {
            // ITransactionSvc transactionSvc = (ITransactionSvc)GetService("TransactionSvcRepoImpl");
            transactionSvc.ModifyTransaction(transaction);
        }

        public Transaction RetrieveTransaction(String DBColumnName, String StringValue)
        {
            // ITransactionSvc transactionSvc = (ITransactionSvc)GetService("TransactionSvcRepoImpl");
            return transactionSvc.RetrieveTransaction(DBColumnName, StringValue);
        }
        public Transaction RetrieveTransaction(String DBColumnName, int IntValue)
        {
            // ITransactionSvc transactionSvc = (ITransactionSvc)GetService("TransactionSvcRepoImpl");
            return transactionSvc.RetrieveTransaction(DBColumnName, IntValue);
        }
        public Transaction RetrieveTransaction(String DBColumnName, int? NullableIntValue)
        {
            // ITransactionSvc transactionSvc = (ITransactionSvc)GetService("TransactionSvcRepoImpl");
            return transactionSvc.RetrieveTransaction(DBColumnName, NullableIntValue);
        }
        public ICollection<Transaction> RetrieveAccountTransactions(String DBColumnName, int IntValue)
        {
            // ITransactionSvc transactionSvc = (ITransactionSvc)GetService("TransactionSvcRepoImpl");
            IEnumerable<CreditCard> CreditCards = creditCardSvc.RetrieveCreditCards(DBColumnName, IntValue);

            IList<Transaction> combined = new List<Transaction>();
            foreach (CreditCard cc in CreditCards)
            {
                IEnumerable<Transaction> txns = transactionSvc.RetrieveTransactions("CreditCard_CreditCardId", cc.CreditCardId);
                if (txns != null)
                {
                    foreach (Transaction txn in txns)
                    {
                        combined.Add(txn);
                    }
                }

            }

            return combined.ToList();
        }
        public ICollection<Transaction> RetrieveAccountTransactions(String DBColumnName, int? NullableIntValue)
        {
            // ITransactionSvc transactionSvc = (ITransactionSvc)GetService("TransactionSvcRepoImpl");
            //return transactionSvc.RetrieveAccountTransactions(DBColumnName, NullableIntValue);
            IEnumerable<CreditCard> CreditCards = creditCardSvc.RetrieveCreditCards(DBColumnName, NullableIntValue);

            IList<Transaction> combined = new List<Transaction>();
            foreach (CreditCard cc in CreditCards)
            {
                IEnumerable<Transaction> txns = transactionSvc.RetrieveTransactions("CreditCard_CreditCardId", (int?)cc.CreditCardId);
                if (txns != null)
                {
                    foreach (Transaction txn in txns)
                    {
                        combined.Add(txn);
                    }
                }

            }

            return combined.ToList();

        }
        public ICollection<Transaction> RetrieveAllTransactions()
        {
            // ITransactionSvc transactionSvc = (ITransactionSvc)GetService("TransactionSvcRepoImpl");
            return transactionSvc.RetrieveAllTransactions();
        }

        void AddCreditCardToTransaction(CreditCard CreditCard, Transaction Transaction)
        {
            // ITransactionSvc transactionSvc = (ITransactionSvc)GetService("TransactionSvcRepoImpl");
            transactionSvc.AddCreditCardToTransaction(CreditCard, Transaction);
        }
        void RemoveCreditCardFromTransaction(CreditCard CreditCard, Transaction Transaction)
        {
            // ITransactionSvc transactionSvc = (ITransactionSvc)GetService("TransactionSvcRepoImpl");
            transactionSvc.RemoveCreditCardFromTransaction(CreditCard, Transaction);
        }

        public void DisposeTransaction()
        {

            transactionSvc.DisposeTransaction();
        }

    }
}
 