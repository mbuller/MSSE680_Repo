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

       public CreditCardMgr()
        {
            creditCardSvc = (ICreditCardSvc)GetService("CreditCardSvcRepoImpl");
        }

        public void CreateCreditCard(CreditCard creditCard)
        {
           //  ICreditCardSvc creditCardSvc = (ICreditCardSvc)GetService("CreditCardSvcRepoImpl");
            creditCardSvc.CreateCreditCard(creditCard);
        }

        public void RemoveCreditCard(CreditCard creditCard)
        {
           //  ICreditCardSvc creditCardSvc = (ICreditCardSvc)GetService("CreditCardSvcRepoImpl");
            creditCardSvc.RemoveCreditCard(creditCard);

        }

        public void ModifyCreditCard(CreditCard creditCard)
        {
           //  ICreditCardSvc creditCardSvc = (ICreditCardSvc)GetService("CreditCardSvcRepoImpl");
            creditCardSvc.ModifyCreditCard(creditCard);
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
