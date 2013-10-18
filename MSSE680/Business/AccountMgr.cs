using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Service;

namespace Business
{
    public class AccountMgr : Manager
    {
        public IAccountSvc accountSvc;
        public ICreditCardSvc creditCardSvc;

        public AccountMgr()
        {
            accountSvc = (IAccountSvc)GetService("AccountSvcRepoImpl");
            creditCardSvc = (ICreditCardSvc)GetService("CreditCardSvcRepoImpl");
        }

        public void CreateAccount(int id)
        {
            Account account = new Account(id);
            accountSvc.CreateAccount(account);
            /*
            Account account = accountSvc.RetrieveAccount("AccountUser_PersonId", (int?)id);
            if (account == null)
            {
                account = new Account(id);
                accountSvc.CreateAccount(account);
                Account account2 = accountSvc.RetrieveAccount("AccountUser_PersonId", (int?)id);
                creditcard.Account_AccountId = account2.AccountId;
                creditCardSvc.CreateCreditCard(creditcard);
                account2.CreditCard_CreditCardId = creditcard.CreditCardId;
                accountSvc.ModifyAccount(account2);
            }
            else
            {
                creditcard.Account_AccountId = account.AccountId;


                creditCardSvc.CreateCreditCard(creditcard);
                account.CreditCard_CreditCardId = creditcard.CreditCardId;
                accountSvc.ModifyAccount(account);
            }
       */
        }

        public void CreateAccount(Account account)
        {
       //     IAccountSvc accountSvc = (IAccountSvc)GetService("AccountSvcRepoImpl");
            
            //check if the account has a CreditCard_CreditCardId set
            if (account.CreditCard_CreditCardId != null)
            {
                CreditCard creditCard = creditCardSvc.RetrieveCreditCard("CreditCardId", (int)account.CreditCard_CreditCardId);
                if (creditCard == null || creditCard.CardType != 1)
                {
                    account.CreditCard_CreditCardId = null;
                    accountSvc.CreateAccount(account);
                }
                //check to make sure that the CreditCard type is  "1" before setting accounts CreditCard_CreditCardId to this credit card
                else if (creditCard.CardType == 1)
                {
                    accountSvc.CreateAccount(account);
                    creditCard.Account_AccountId = account.AccountId;
                    creditCardSvc.ModifyCreditCard(creditCard);
                }
                //if it is not, then set CreditCard_CreditCardId to a null value and then create account... 
                //this really should throw an error stating that the value being passed in has invalid CreditCard_CreditCardId
                else
                {
                    throw new System.InvalidOperationException("AccontMgr error when creting account");
                   // account.CreditCard_CreditCardId =null;
                    //accountSvc.CreateAccount(account);
                }
            }
            else
            {
                accountSvc.CreateAccount(account);
            }
        }

        public void RemoveAccount(Account account)
        {
     //       IAccountSvc accountSvc = (IAccountSvc)GetService("AccountSvcRepoImpl");
            List<CreditCard> creditcardCollecton = creditCardSvc.RetrieveCreditCards("Account_AccountId", (int?)account.AccountId).ToList<CreditCard>();
            foreach (CreditCard _creditcard in creditcardCollecton)
            {
                _creditcard.Account_AccountId = null;
                creditCardSvc.ModifyCreditCard(_creditcard);
            }
            
            accountSvc.RemoveAccount(account);

        }
        
        public void ModifyAccount(Account account)
        {
      //      IAccountSvc accountSvc = (IAccountSvc)GetService("AccountSvcRepoImpl");
     //        Account origAccount = accountSvc.RetrieveAccount("CreditCard_CreditCardId",account.CreditCard_CreditCardId);


             //check if the "modified" account has a CreditCard_CreditCardId set
            if (account.CreditCard_CreditCardId != null)
            {
                CreditCard creditCard = creditCardSvc.RetrieveCreditCard("CreditCardId", (int)account.CreditCard_CreditCardId);

                //check to make sure that the CreditCard type is  "1" before setting accounts CreditCard_CreditCardId to this credit card
                if (creditCard.CardType == 1)
                {
                    accountSvc.ModifyAccount(account);
                    creditCard.Account_AccountId = account.AccountId;
                    creditCardSvc.ModifyCreditCard(creditCard);
                }
                //if it is not, then set CreditCard_CreditCardId back to the orignal value and make the remaining modifcations... 
                //this really should throw an error stating that the value being passed in has invalid CreditCard_CreditCardId
                else
                {
                   // account.CreditCard_CreditCardId = account.CreditCard_CreditCardId;
                   // accountSvc.ModifyAccount(account);
                    throw new System.InvalidOperationException("Cannot set the Account creditCard ID to a credit card that's cardType is not 1.");
                }                    
            }
            //CreditCard_CreditCardId is null in account so make sure any credit card referencing it has its CreditCard_CreditCardId set to null
            else
            {
                accountSvc.ModifyAccount(account);
                List<CreditCard> creditcardCollecton = creditCardSvc.RetrieveCreditCards("Account_AccountId", (int?)account.AccountId).ToList<CreditCard>();
                foreach (CreditCard _creditcard in creditcardCollecton)
                {
                    _creditcard.Account_AccountId = null;
                    creditCardSvc.ModifyCreditCard(_creditcard);
                }
            }
        }

        public Account RetrieveAccount(String DBColumnName, String StringValue)
        {
       //     IAccountSvc accountSvc = (IAccountSvc)GetService("AccountSvcRepoImpl");
            return accountSvc.RetrieveAccount(DBColumnName, StringValue);
        }
        public Account RetrieveAccount(String DBColumnName, int IntValue)
        {
       //     IAccountSvc accountSvc = (IAccountSvc)GetService("AccountSvcRepoImpl");
            return accountSvc.RetrieveAccount(DBColumnName, IntValue);
        }
        public Account RetrieveAccount(String DBColumnName, int? NullableIntValue)
        {
        //    IAccountSvc accountSvc = (IAccountSvc)GetService("AccountSvcRepoImpl");
            return accountSvc.RetrieveAccount(DBColumnName, NullableIntValue);
        }
        public ICollection<Account> RetrieveAllAccounts()
        {
        //    IAccountSvc accountSvc = (IAccountSvc)GetService("AccountSvcRepoImpl");
            return accountSvc.RetrieveAllAccounts();
        }

        void AddCreditCardToAccount(CreditCard CreditCard, Account Account)
        {
        //    IAccountSvc accountSvc = (IAccountSvc)GetService("AccountSvcRepoImpl");
            accountSvc.AddCreditCardToAccount(CreditCard, Account);
        }
        void RemoveCreditCardFromAccount(CreditCard CreditCard, Account Account)
        {
      //      IAccountSvc accountSvc = (IAccountSvc)GetService("AccountSvcRepoImpl");
            accountSvc.RemoveCreditCardFromAccount(CreditCard, Account);
        }

        void AddUserToAccount(Person Person, Account Account)
        {
        //    IAccountSvc accountSvc = (IAccountSvc)GetService("AccountSvcRepoImpl");
            accountSvc.AddUserToAccount(Person, Account);
        }

        void RemoveUserFromAccount(Person Person, Account Account)
        {
         //   IAccountSvc accountSvc = (IAccountSvc)GetService("AccountSvcRepoImpl");
            accountSvc.RemoveUserFromAccount(Person, Account);
        }

        public void DisposeAccount()
        {

            accountSvc.DisposeAccount();
        }

    }
}
