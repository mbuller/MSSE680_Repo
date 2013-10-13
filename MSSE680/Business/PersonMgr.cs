using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Service;

namespace Business
{
    public class PersonMgr : Manager
    {
        public IPersonSvc personSvc;
        public IAccountSvc accountSvc;
        public ICreditCardSvc creditCardSvc;
        

       public PersonMgr()
        {
            personSvc = (IPersonSvc)GetService("PersonSvcRepoImpl");
            accountSvc = (IAccountSvc)GetService("AccountSvcRepoImpl");
            creditCardSvc = (ICreditCardSvc)GetService("CreditCardSvcRepoImpl");
        }


        public void CreatePerson(Person person)
        {
            // IPersonSvc personSvc = (IPersonSvc)GetService("PersonSvcRepoImpl");
            personSvc.CreatePerson(person);
        }

        public void RemovePerson(Person person)
        {
            // IPersonSvc personSvc = (IPersonSvc)GetService("PersonSvcRepoImpl");
            List<Account> accountCollecton = accountSvc.RetrieveAccounts("AccountUser_PersonId", (int?)person.PersonId).ToList<Account>();
            foreach (Account _account in accountCollecton)
            {
                _account.AccountUser_PersonId = null;
                accountSvc.ModifyAccount(_account);
            }
            List<CreditCard> creditcardCollecton = creditCardSvc.RetrieveCreditCards("CreditCardUser_PersonId", (int?)person.PersonId).ToList<CreditCard>();
            foreach (CreditCard _creditcard in creditcardCollecton)
            {
                _creditcard.CreditCardUser_PersonId = null;
                creditCardSvc.ModifyCreditCard(_creditcard);
            }
            
            personSvc.RemovePerson(person);



        }

        public void ModifyPerson(Person person)
        {
            // IPersonSvc personSvc = (IPersonSvc)GetService("PersonSvcRepoImpl");
            personSvc.ModifyPerson(person);
        }

        public Person RetrievePerson(String DBColumnName, String StringValue)
        {
            // IPersonSvc personSvc = (IPersonSvc)GetService("PersonSvcRepoImpl");
            return personSvc.RetrievePerson(DBColumnName, StringValue);
        }
        public Person RetrievePerson(String DBColumnName, int IntValue)
        {
            // IPersonSvc personSvc = (IPersonSvc)GetService("PersonSvcRepoImpl");
            return personSvc.RetrievePerson(DBColumnName, IntValue);
        }
        public Person RetrievePerson(String DBColumnName, int? NullableIntValue)
        {
            // IPersonSvc personSvc = (IPersonSvc)GetService("PersonSvcRepoImpl");
            return personSvc.RetrievePerson(DBColumnName, NullableIntValue);
        }
        public ICollection<Person> RetrieveAllPeople()
        {
            // IPersonSvc personSvc = (IPersonSvc)GetService("PersonSvcRepoImpl");
            return personSvc.RetrieveAllPeople();
        }

        void AddAddressToPerson(Address Address, Person Person)
        {
            // IPersonSvc personSvc = (IPersonSvc)GetService("PersonSvcRepoImpl");
            personSvc.AddAddressToPerson(Address, Person);
        }

        void RemoveAddressFromPerson(Address Address, Person Person)
        {
            // IPersonSvc personSvc = (IPersonSvc)GetService("PersonSvcRepoImpl");
            personSvc.RemoveAddressFromPerson(Address, Person);
        }

        public void DisposePerson()
        {

            personSvc.DisposePerson();
        }
    }
}
