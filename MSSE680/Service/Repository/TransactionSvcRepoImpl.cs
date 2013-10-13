using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using DAL;

namespace Service
{
    public partial class TransactionSvcRepoImpl : ITransactionSvc
    {
        public DataRepository<Transaction> TransactionRepo;

        public TransactionSvcRepoImpl()
        {
            TransactionRepo = new DataRepository<Transaction>();
        }
        public void CreateTransaction(Transaction Transaction)
        {
            TransactionRepo.Insert(Transaction);
        }
        public void RemoveTransaction(Transaction Transaction)
        {
            TransactionRepo.Delete(Transaction);
        }
        public void ModifyTransaction(Transaction Transaction)
        {
            TransactionRepo.Update(Transaction);
        }

        public Transaction RetrieveTransaction(String DBColumnName, String StringValue)
        {
            return TransactionRepo.GetBySpecificKey(DBColumnName, StringValue).FirstOrDefault<Transaction>();
        }

        public Transaction RetrieveTransaction(String DBColumnName, int IntValue)
        {
            return TransactionRepo.GetBySpecificKey(DBColumnName, IntValue).FirstOrDefault<Transaction>();
        }

        public Transaction RetrieveTransaction(String DBColumnName, int? NullableIntValue)
        {
            return TransactionRepo.GetBySpecificKey(DBColumnName, NullableIntValue).FirstOrDefault<Transaction>();
        }
        public ICollection<Transaction> RetrieveTransactions(String DBColumnName, int NullableIntValue)
        {
            return TransactionRepo.GetBySpecificKey(DBColumnName, NullableIntValue).ToList<Transaction>();
        }
        public ICollection<Transaction> RetrieveTransactions(String DBColumnName, int? NullableIntValue)
        {
            return TransactionRepo.GetBySpecificKey(DBColumnName, NullableIntValue).ToList<Transaction>();
        }

        public ICollection<Transaction> RetrieveAllTransactions()
        {
            return TransactionRepo.GetAll().ToList<Transaction>();
        }


        public void AddCreditCardToTransaction(CreditCard CreditCard, Transaction Transaction)
        {
            Transaction.CreditCard_CreditCardId = CreditCard.CreditCardId;
            ModifyTransaction(Transaction);
        }
        public void RemoveCreditCardFromTransaction(CreditCard CreditCard, Transaction Transaction)
        {
            Transaction.CreditCard_CreditCardId = null;
            ModifyTransaction(Transaction);
        }
        public void DisposeTransaction()
        {
            TransactionRepo.Dispose();
        }
    }
}
