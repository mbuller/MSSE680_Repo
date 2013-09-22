using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSE680.DAL;

namespace MSSE680.Service
{
    public interface IAccountSvc : IService
    {

        void CreateAccount(Account Account);
        void RemoveAccount(Account Account);
        void ModifyAccount(Account Account);
        Account RetrieveAccount(String DBColumnName, String StringValue);
        Account RetrieveAccount(String DBColumnName, int IntValue);
        Account RetrieveAccount(String DBColumnName, int? NullableIntValue);
        ICollection<Account> RetrieveAllAccounts();

        void AddCreditCardToAccount(CreditCard CreditCard, Account Account);
        void RemoveCreditCardFromAccount(CreditCard CreditCard, Account Account);

        void AddUserToAccount(Person Person, Account Account);
        void RemoveUserFromAccount(Person Person, Account Account);
    }
}
