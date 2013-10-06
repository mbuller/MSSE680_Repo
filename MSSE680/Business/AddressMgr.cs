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

        public AddressMgr()
        {
            addressSvc = (IAddressSvc)GetService("AddressSvcRepoImpl");
        }

        public void CreateAddress(Address address)
        {
        //    IAddressSvc addressSvc = (IAddressSvc)GetService("AddressSvcRepoImpl");
            addressSvc.CreateAddress(address);
        }

        public void RemoveAddress(Address address)
        {
        //    IAddressSvc addressSvc = (IAddressSvc)GetService("AddressSvcRepoImpl");
            addressSvc.RemoveAddress(address);

        }

        public void ModifyAddress(Address address)
        {
        //    IAddressSvc addressSvc = (IAddressSvc)GetService("AddressSvcRepoImpl");
            addressSvc.ModifyAddress(address);
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
