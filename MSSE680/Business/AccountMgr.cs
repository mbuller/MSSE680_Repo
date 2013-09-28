using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSE680.DAL;
using MSSE680.Service;

namespace MSSE680.Business
{
    public class AccountMgr : Manager
    {

        public void CreateAccount(Account account)
        {
            IAccountSvc accountSvc = (IAccountSvc)GetService("AccountSvcRepoImpl");
            accountSvc.CreateAccount(account);
        }

        public void RemoveAccount(Account account)
        {
            IAccountSvc accountSvc = (IAccountSvc)GetService("AccountSvcRepoImpl");
            accountSvc.RemoveAccount(account);

        }
        
        public void ModifyAccount(Account account)
        {
            IAccountSvc accountSvc = (IAccountSvc)GetService("AccountSvcRepoImpl");
            accountSvc.ModifyAccount(account);
        }

        public Account RetrieveAccount(String DBColumnName, String StringValue)
        {
            IAccountSvc accountSvc = (IAccountSvc)GetService("AccountSvcRepoImpl");
            return accountSvc.RetrieveAccount(DBColumnName, StringValue);
        }
        public Account RetrieveAccount(String DBColumnName, int IntValue)
        {
            IAccountSvc accountSvc = (IAccountSvc)GetService("AccountSvcRepoImpl");
            return accountSvc.RetrieveAccount(DBColumnName, IntValue);
        }
        public Account RetrieveAccount(String DBColumnName, int? NullableIntValue)
        {
            IAccountSvc accountSvc = (IAccountSvc)GetService("AccountSvcRepoImpl");
            return accountSvc.RetrieveAccount(DBColumnName, NullableIntValue);
        }
        public ICollection<Account> RetrieveAllAccounts()
        {
            IAccountSvc accountSvc = (IAccountSvc)GetService("AccountSvcRepoImpl");
            return accountSvc.RetrieveAllAccounts();
        }

        void AddCreditCardToAccount(CreditCard CreditCard, Account Account)
        {
            IAccountSvc accountSvc = (IAccountSvc)GetService("AccountSvcRepoImpl");
            accountSvc.AddCreditCardToAccount(CreditCard, Account);
        }
        void RemoveCreditCardFromAccount(CreditCard CreditCard, Account Account)
        {
            IAccountSvc accountSvc = (IAccountSvc)GetService("AccountSvcRepoImpl");
            accountSvc.RemoveCreditCardFromAccount(CreditCard, Account);
        }

        void AddUserToAccount(Person Person, Account Account)
        {
            IAccountSvc accountSvc = (IAccountSvc)GetService("AccountSvcRepoImpl");
            accountSvc.AddUserToAccount(Person, Account);
        }

        void RemoveUserFromAccount(Person Person, Account Account)
        {
            IAccountSvc accountSvc = (IAccountSvc)GetService("AccountSvcRepoImpl");
            accountSvc.RemoveUserFromAccount(Person, Account);
        }

    }
}
