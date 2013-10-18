using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Service;


namespace Business
{
    public class AddressMgr : Manager
    {
        public IAddressSvc addressSvc;
        public IPersonSvc personSvc;

        public AddressMgr()
        {
            addressSvc = (IAddressSvc)GetService("AddressSvcRepoImpl");
            personSvc = (IPersonSvc)GetService("PersonSvcRepoImpl");
        }

        public void CreateAddress(Address address)
        {
        //    IAddressSvc addressSvc = (IAddressSvc)GetService("AddressSvcRepoImpl");
            //addressSvc.CreateAddress(address);
            //check if the account has a CreditCard_CreditCardId set
            if (address.Person_PersonId != null)
            {
                Person person = personSvc.RetrievePerson("PersonId", (int)address.Person_PersonId);
                if (person == null)
                {
                    address.Person_PersonId = null;
                    addressSvc.CreateAddress(address);
                }
                //check to make sure that the CreditCard type is  "1" before setting accounts CreditCard_CreditCardId to this credit card
                else if (person != null)
                {
                    addressSvc.CreateAddress(address);
                    person.Address_AddressId = address.AddressId;
                    personSvc.ModifyPerson(person);
                }
                //if it is not, then set CreditCard_CreditCardId to a null value and then create account... 
                //this really should throw an error stating that the value being passed in has invalid CreditCard_CreditCardId
                else
                {
                    throw new System.InvalidOperationException("AddressMgr error when creating address");
                    // account.CreditCard_CreditCardId =null;
                    //accountSvc.CreateAccount(account);
                }
            }
            else
            {
                addressSvc.CreateAddress(address);
            }

        }

        public void RemoveAddress(Address address)
        {
        //    IAddressSvc addressSvc = (IAddressSvc)GetService("AddressSvcRepoImpl");

            List<Person> peopleCollecton = personSvc.RetrievePeople("Address_AddressId", (int?)address.AddressId).ToList<Person>();
            foreach (Person _person in peopleCollecton)
            {
                _person.Address_AddressId = null;
                personSvc.ModifyPerson(_person);
            }
            
            addressSvc.RemoveAddress(address);

        }

        public void ModifyAddress(Address address)
        {
        //    IAddressSvc addressSvc = (IAddressSvc)GetService("AddressSvcRepoImpl");
            //addressSvc.ModifyAddress(address);

            if (address.Person_PersonId != null)
            {
                Person person = personSvc.RetrievePerson("PersonId", (int)address.Person_PersonId);
                if (person == null)
                {
                    address.Person_PersonId = null;
                    addressSvc.ModifyAddress(address);
                }
                //check to make sure that the CreditCard type is  "1" before setting accounts CreditCard_CreditCardId to this credit card
                else if (person != null)
                {
                    addressSvc.ModifyAddress(address);
                    person.Address_AddressId = address.AddressId;
                    personSvc.ModifyPerson(person);
                }
                //if it is not, then set CreditCard_CreditCardId to a null value and then create account... 
                //this really should throw an error stating that the value being passed in has invalid CreditCard_CreditCardId
                else
                {
                    throw new System.InvalidOperationException("AddressMgr error when creating address");
                    // account.CreditCard_CreditCardId =null;
                    //accountSvc.CreateAccount(account);
                }
            }
            else
            {
                addressSvc.ModifyAddress(address);
            }
        }

        public Address RetrieveAddress(String DBColumnName, String StringValue)
        {
        //    IAddressSvc addressSvc = (IAddressSvc)GetService("AddressSvcRepoImpl");
            return addressSvc.RetrieveAddress(DBColumnName, StringValue);
        }
        public Address RetrieveAddress(String DBColumnName, int IntValue)
        {
        //    IAddressSvc addressSvc = (IAddressSvc)GetService("AddressSvcRepoImpl");
            return addressSvc.RetrieveAddress(DBColumnName, IntValue);
        }
        public Address RetrieveAddress(String DBColumnName, int? NullableIntValue)
        {
        //    IAddressSvc addressSvc = (IAddressSvc)GetService("AddressSvcRepoImpl");
            return addressSvc.RetrieveAddress(DBColumnName, NullableIntValue);
        }
        public ICollection<Address> RetrieveAllAddresses()
        {
         //   IAddressSvc addressSvc = (IAddressSvc)GetService("AddressSvcRepoImpl");
            return addressSvc.RetrieveAllAddresses();
        }
        public void DisposeAddress()
        {
        //    IAddressSvc addressSvc = (IAddressSvc)GetService("AddressSvcRepoImpl");
            addressSvc.DisposeAddress();
        }
    }
}
