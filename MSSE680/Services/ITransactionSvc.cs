using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSE680.DAL;

namespace MSSE680.Service
{
    public interface ITransactionSvc : IService
    {

        void CreateTransaction(Transaction Transaction);
        void RemoveTransaction(Transaction Transaction);
        void ModifyTransaction(Transaction Transaction);
        Transaction RetrieveTransaction(String DBColumnName, String StringValue);
        Transaction RetrieveTransaction(String DBColumnName, int IntValue);
        Transaction RetrieveTransaction(String DBColumnName, int? NullableIntValue);
        ICollection<Transaction> RetrieveAllTransactions();

        void AddCreditCardToTransaction(CreditCard CreditCard, Transaction Transaction);
        void RemoveCreditCardToTransaction(CreditCard CreditCard, Transaction Transaction);
    }
}
