using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSE680.DAL;
using MSSE680.Service;

namespace MSSE680.Business
{
    public class TransactionMgr : Manager
    {

        public void CreateTransaction(Transaction transaction)
        {
            ITransactionSvc transactionSvc = (ITransactionSvc)GetService("TransactionSvcRepoImpl");
            transactionSvc.CreateTransaction(transaction);
        }

        public void RemoveTransaction(Transaction transaction)
        {
            ITransactionSvc transactionSvc = (ITransactionSvc)GetService("TransactionSvcRepoImpl");
            transactionSvc.RemoveTransaction(transaction);

        }

        public void ModifyTransaction(Transaction transaction)
        {
            ITransactionSvc transactionSvc = (ITransactionSvc)GetService("TransactionSvcRepoImpl");
            transactionSvc.ModifyTransaction(transaction);
        }

        public Transaction RetrieveTransaction(String DBColumnName, String StringValue)
        {
            ITransactionSvc transactionSvc = (ITransactionSvc)GetService("TransactionSvcRepoImpl");
            return transactionSvc.RetrieveTransaction(DBColumnName, StringValue);
        }
        public Transaction RetrieveTransaction(String DBColumnName, int IntValue)
        {
            ITransactionSvc transactionSvc = (ITransactionSvc)GetService("TransactionSvcRepoImpl");
            return transactionSvc.RetrieveTransaction(DBColumnName, IntValue);
        }
        public Transaction RetrieveTransaction(String DBColumnName, int? NullableIntValue)
        {
            ITransactionSvc transactionSvc = (ITransactionSvc)GetService("TransactionSvcRepoImpl");
            return transactionSvc.RetrieveTransaction(DBColumnName, NullableIntValue);
        }
        public ICollection<Transaction> RetrieveAllTransactions()
        {
            ITransactionSvc transactionSvc = (ITransactionSvc)GetService("TransactionSvcRepoImpl");
            return transactionSvc.RetrieveAllTransactions();
        }

        void AddCreditCardToTransaction(CreditCard CreditCard, Transaction Transaction)
        {
            ITransactionSvc transactionSvc = (ITransactionSvc)GetService("TransactionSvcRepoImpl");
            transactionSvc.AddCreditCardToTransaction(CreditCard, Transaction);
        }
        void RemoveCreditCardFromTransaction(CreditCard CreditCard, Transaction Transaction)
        {
            ITransactionSvc transactionSvc = (ITransactionSvc)GetService("TransactionSvcRepoImpl");
            transactionSvc.RemoveCreditCardFromTransaction(CreditCard, Transaction);
        }

    }
}
 