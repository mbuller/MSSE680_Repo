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

        public void CreateCreditCard(CreditCard creditCard)
        {
           //  ICreditCardSvc creditCardSvc = (ICreditCardSvc)GetService("CreditCardSvcRepoImpl");



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
                creditCardSvc.CreateCreditCard(creditCard);
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
                            throw new System.InvalidOperationException("There is already a credit card with cardType 1 for this account");
                        }
                        
                    }
                    creditcardCollecton = null;
                    creditCardSvc.ModifyCreditCard(creditCard);
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
