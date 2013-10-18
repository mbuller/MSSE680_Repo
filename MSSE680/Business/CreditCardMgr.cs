using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Service;

namespace Business
{
    public class CreditCardMgr : Manager
    {
       public ICreditCardSvc creditCardSvc;
       public IAccountSvc accountSvc;
       public ITransactionSvc transactionSvc;

       public CreditCardMgr()
        {
            creditCardSvc = (ICreditCardSvc)GetService("CreditCardSvcRepoImpl");
            accountSvc = (IAccountSvc)GetService("AccountSvcRepoImpl");
            transactionSvc = (ITransactionSvc)GetService("TransactionSvcRepoImpl");
        }

       public void CreateCreditCard(int id)
       {
           CreditCard creditcard = new CreditCard(id);
           creditcard.CardType = 1;

           if (creditcard.Balance == null)
           {
               creditcard.Balance = 0;
           }

           if (creditcard.Limit == null)
           {
               creditcard.Limit = 0;
           }

           if (creditcard.ExpirationMonth == null)
           {
               creditcard.ExpirationMonth = 0;
           }

           if (creditcard.ExpirationYear == null)
           {
               creditcard.ExpirationYear = 0;
           }


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
       
       }

        public void CreateCreditCard(CreditCard creditCard)
        {
           //  ICreditCardSvc creditCardSvc = (ICreditCardSvc)GetService("CreditCardSvcRepoImpl");
            if (creditCard.CardType == null)
            {
                creditCard.CardType = 2;
            }

            if (creditCard.Balance == null)
            {
                creditCard.Balance = 0;
            }

            if (creditCard.Limit == null)
            {
                creditCard.Limit = 0;
            }

            if (creditCard.ExpirationMonth == null)
            {
                creditCard.ExpirationMonth = 0;
            }

            if (creditCard.ExpirationYear == null)
            {
                creditCard.ExpirationYear = 0;
            }

            if (creditCard.Account_AccountId != null)
            {
                if (creditCard.CardType == 1)
                {
                    creditCardSvc.CreateCreditCard(creditCard);
                    
                    Account account = accountSvc.RetrieveAccount("AccountId", (int)creditCard.Account_AccountId);
                    account.CreditCard_CreditCardId = creditCard.CreditCardId;
                    accountSvc.ModifyAccount(account);
                }
                else
                {
                   
                    creditCardSvc.CreateCreditCard(creditCard);
                }
            }
            else
            {
                Account account = accountSvc.RetrieveAccount("AccountUser_PersonId", creditCard.CreditCardUser_PersonId);
                if (account == null)
                {
                    creditCardSvc.CreateCreditCard(creditCard);
                }
                else
                {
                    creditCard.Account_AccountId = account.AccountId;
                    creditCardSvc.CreateCreditCard(creditCard);
                }
            }


        }

        public void RemoveCreditCard(CreditCard creditCard)
        {
           //  ICreditCardSvc creditCardSvc = (ICreditCardSvc)GetService("CreditCardSvcRepoImpl");
            List<Account> accountCollecton = accountSvc.RetrieveAccounts("CreditCard_CreditCardId", (int?)creditCard.CreditCardId).ToList<Account>();
            foreach (Account _account in accountCollecton)
            {
                _account.CreditCard_CreditCardId = null;
                accountSvc.ModifyAccount(_account);
            }

            List<Transaction> transactionCollecton = transactionSvc.RetrieveTransactions("CreditCard_CreditCardId", (int?)creditCard.CreditCardId).ToList<Transaction>();
            foreach (Transaction _transaction in transactionCollecton)
            {
                _transaction.CreditCard_CreditCardId = null;
                transactionSvc.ModifyTransaction(_transaction);
            }
            
            creditCardSvc.RemoveCreditCard(creditCard);

        }

        public void ModifyCreditCard(CreditCard creditCard)
        {
           //  ICreditCardSvc creditCardSvc = (ICreditCardSvc)GetService("CreditCardSvcRepoImpl");

            //check if Account_AccountId is not null
            if (creditCard.Account_AccountId != null)
            {
                if (creditCard.CardType == 1)
                {

                    //check to see if account already has a primary card
                    List<CreditCard> creditcardCollecton = creditCardSvc.RetrieveCreditCards("Account_AccountId", creditCard.Account_AccountId).ToList<CreditCard>();
                    foreach (CreditCard _creditcard in creditcardCollecton)
                    {
                        if (_creditcard.CardType == 1)
                        {
                            if (_creditcard.CreditCardId != creditCard.CreditCardId)
                            {
                                throw new System.InvalidOperationException("There is already a credit card with cardType 1 for this account");
                            }
                        }
                        
                    }
                    //CreditCard newCC = creditCardSvc.RetrieveCreditCard("CreditCardId", creditCard.CreditCardId);
                    //newCC = creditCard;
                    int location = creditcardCollecton.FindIndex(c => c.CreditCardId == creditCard.CreditCardId);
                    //creditcardCollecton[location] = creditCard;
                    creditcardCollecton[location].Balance = creditCard.Balance;
                    creditcardCollecton[location].CardType = creditCard.CardType;
                    creditcardCollecton[location].ExpirationMonth = creditCard.ExpirationMonth;
                    creditcardCollecton[location].ExpirationYear = creditCard.ExpirationYear;
                    creditcardCollecton[location].CreditCardUser_PersonId = creditCard.CreditCardUser_PersonId;
                    creditcardCollecton[location].Account_AccountId = creditCard.Account_AccountId;
                    //creditcardCollecton = null;
                    creditCardSvc.ModifyCreditCard(creditcardCollecton[location]);
                    Account account = accountSvc.RetrieveAccount("AccountId", (int)creditCard.Account_AccountId);
                    account.CreditCard_CreditCardId = creditCard.CreditCardId;
                    accountSvc.ModifyAccount(account);
                }
                else
                {
                    creditCardSvc.ModifyCreditCard(creditCard);
                }
            }
            //Account_AccountId is null in creditCard so make sure any account referencing it has its Account_AccountId set to null
            else
            {
                creditCardSvc.ModifyCreditCard(creditCard);
                List<Account> accountCollecton = accountSvc.RetrieveAccounts("CreditCard_CreditCardId", (int?)creditCard.CreditCardId).ToList<Account>();
                foreach (Account _account in accountCollecton)
                {
                    _account.CreditCard_CreditCardId = null;
                    accountSvc.ModifyAccount(_account);
                }
                

            }
        }

        public CreditCard RetrieveCreditCard(String DBColumnName, String StringValue)
        {
           //  ICreditCardSvc creditCardSvc = (ICreditCardSvc)GetService("CreditCardSvcRepoImpl");
            return creditCardSvc.RetrieveCreditCard(DBColumnName, StringValue);
        }
        public CreditCard RetrieveCreditCard(String DBColumnName, int IntValue)
        {
           //  ICreditCardSvc creditCardSvc = (ICreditCardSvc)GetService("CreditCardSvcRepoImpl");
            return creditCardSvc.RetrieveCreditCard(DBColumnName, IntValue);
        }
        public CreditCard RetrieveCreditCard(String DBColumnName, int? NullableIntValue)
        {
           //  ICreditCardSvc creditCardSvc = (ICreditCardSvc)GetService("CreditCardSvcRepoImpl");
            return creditCardSvc.RetrieveCreditCard(DBColumnName, NullableIntValue);
        }

        public ICollection<CreditCard> RetrieveCreditCards(String DBColumnName, int IntValue)
        {
            //  ICreditCardSvc creditCardSvc = (ICreditCardSvc)GetService("CreditCardSvcRepoImpl");
            return creditCardSvc.RetrieveCreditCards(DBColumnName, IntValue);
        }
        public ICollection<CreditCard> RetrieveCreditCards(String DBColumnName, int? NullableIntValue)
        {
            //  ICreditCardSvc creditCardSvc = (ICreditCardSvc)GetService("CreditCardSvcRepoImpl");
            return creditCardSvc.RetrieveCreditCards(DBColumnName, NullableIntValue);
        }
        public ICollection<CreditCard> RetrieveAllCreditCards()
        {
           //  ICreditCardSvc creditCardSvc = (ICreditCardSvc)GetService("CreditCardSvcRepoImpl");
            return creditCardSvc.RetrieveAllCreditCards();
        }

        void AddAccountToCreditCard(Account Account, CreditCard CreditCard)
        {
           //  ICreditCardSvc creditCardSvc = (ICreditCardSvc)GetService("CreditCardSvcRepoImpl");
            creditCardSvc.AddAccountToCreditCard(Account, CreditCard);
        }
        void RemoveAccountFromCreditCard(Account Account, CreditCard CreditCard)
        {
           //  ICreditCardSvc creditCardSvc = (ICreditCardSvc)GetService("CreditCardSvcRepoImpl");
            creditCardSvc.RemoveAccountFromCreditCard(Account, CreditCard);
        }

        void AddPersonToCreditCard(Person Person, CreditCard CreditCard)
        {
           //  ICreditCardSvc creditCardSvc = (ICreditCardSvc)GetService("CreditCardSvcRepoImpl");
            creditCardSvc.AddPersonToCreditCard(Person, CreditCard);
        }

        void RemovePersonFromCreditCard(Person Person, CreditCard CreditCard)
        {
           //  ICreditCardSvc creditCardSvc = (ICreditCardSvc)GetService("CreditCardSvcRepoImpl");
            creditCardSvc.RemovePersonFromCreditCard(Person, CreditCard);
        }
        public void DisposeCreditCard()
        {

            creditCardSvc.DisposeCreditCard();
        }
    }
}
