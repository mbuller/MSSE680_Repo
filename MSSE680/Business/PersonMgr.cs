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
        public IAddressSvc addressSvc;
        

       public PersonMgr()
        {
            personSvc = (IPersonSvc)GetService("PersonSvcRepoImpl");
            accountSvc = (IAccountSvc)GetService("AccountSvcRepoImpl");
            creditCardSvc = (ICreditCardSvc)GetService("CreditCardSvcRepoImpl");
            addressSvc = (IAddressSvc)GetService("AddressSvcRepoImpl");
        }


        public void CreatePerson(Person person)
        {
            // IPersonSvc personSvc = (IPersonSvc)GetService("PersonSvcRepoImpl");
            
            //check if the person has a Address_AddressId set
            if (person.Address_AddressId != null)
            {
                Address address = addressSvc.RetrieveAddress("AddressId", (int)person.Address_AddressId);
                if (address == null )
                {
                    person.Address_AddressId = null;
                    personSvc.CreatePerson(person);
                }
                //check to make sure that the CreditCard type is  "1" before setting accounts CreditCard_CreditCardId to this credit card
                else if (address != null)
                {
                    
                    personSvc.CreatePerson(person);
                    address.Person_PersonId = person.PersonId;
                    addressSvc.ModifyAddress(address);
                }
                //if it is not, then set CreditCard_CreditCardId to a null value and then create account... 
                //this really should throw an error stating that the value being passed in has invalid CreditCard_CreditCardId
                else
                {
                    throw new System.InvalidOperationException("PersonMgr error when creting person");
                   // account.CreditCard_CreditCardId =null;
                    //accountSvc.CreateAccount(account);
                }
            }
            else
            {
                personSvc.CreatePerson(person);
            }


            
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
            //personSvc.ModifyPerson(person);

            //check if the person has a Address_AddressId set
            if (person.Address_AddressId != null)
            {
                Address address = addressSvc.RetrieveAddress("AddressId", (int)person.Address_AddressId);
                if (address == null)
                {
                    person.Address_AddressId = null;
                    personSvc.ModifyPerson(person);
                }
                //check to make sure that the CreditCard type is  "1" before setting accounts CreditCard_CreditCardId to this credit card
                else if (address != null)
                {

                    personSvc.ModifyPerson(person);
                    address.Person_PersonId = person.PersonId;
                    addressSvc.ModifyAddress(address);
                }
                //if it is not, then set CreditCard_CreditCardId to a null value and then create account... 
                //this really should throw an error stating that the value being passed in has invalid CreditCard_CreditCardId
                else
                {
                    throw new System.InvalidOperationException("PersonMgr error when creting person");
                    // account.CreditCard_CreditCardId =null;
                    //accountSvc.CreateAccount(account);
                }
            }
            else
            {
                personSvc.ModifyPerson(person);
            }
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
