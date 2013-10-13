using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using DAL;

namespace Service
{
    public partial class AccountSvcRepoImpl : IAccountSvc
    {
        public DataRepository<Account> AccountRepo;

        public AccountSvcRepoImpl()
        {
            AccountRepo = new DataRepository<Account>();
        }
        public void CreateAccount(Account Account)
        {
            AccountRepo.Insert(Account);
        }
        public void RemoveAccount(Account Account)
        {
            AccountRepo.Delete(Account);
        }
        public void ModifyAccount(Account Account)
        {
            AccountRepo.Update(Account);
        }

        public Account RetrieveAccount(String DBColumnName, String StringValue)
        {
            return AccountRepo.GetBySpecificKey(DBColumnName, StringValue).FirstOrDefault<Account>();
        }

        public Account RetrieveAccount(String DBColumnName, int IntValue)
        {
            return AccountRepo.GetBySpecificKey(DBColumnName, IntValue).FirstOrDefault<Account>();
        }

        public Account RetrieveAccount(String DBColumnName, int? NullableIntValue)
        {
            return AccountRepo.GetBySpecificKey(DBColumnName, NullableIntValue).FirstOrDefault<Account>();
        }

        public ICollection<Account> RetrieveAccounts(String DBColumnName, int NullableIntValue)
        {
            return AccountRepo.GetBySpecificKey(DBColumnName, NullableIntValue).ToList<Account>();
        }
        public ICollection<Account> RetrieveAccounts(String DBColumnName, int? NullableIntValue)
        {
            return AccountRepo.GetBySpecificKey(DBColumnName, NullableIntValue).ToList<Account>();
        }

        public ICollection<Account> RetrieveAllAccounts()
        {
            return AccountRepo.GetAll().ToList<Account>();
        }

        public void AddCreditCardToAccount(CreditCard CreditCard, Account Account)
        {
            Account.CreditCard_CreditCardId = CreditCard.CreditCardId;
            ModifyAccount(Account);
        }
 
        public void RemoveCreditCardFromAccount(CreditCard CreditCard, Account Account)
        {
            Account.CreditCard_CreditCardId = null;
            ModifyAccount(Account);
        }

        public void AddUserToAccount(Person Person, Account Account)
        {
            Account.AccountUser_PersonId = Person.PersonId;
            ModifyAccount(Account);
        }
        public void RemoveUserFromAccount(Person Person, Account Account)
        {
            Account.AccountUser_PersonId = null;
            ModifyAccount(Account);
        }
        public void DisposeAccount()
        {
            AccountRepo.Dispose();
        }
    }
}
