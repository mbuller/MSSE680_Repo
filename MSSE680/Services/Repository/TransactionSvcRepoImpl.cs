using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSE680.Service;
using MSSE680.DAL;

namespace MSSE680.Service
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
    }
}
