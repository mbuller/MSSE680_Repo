using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSE680.DAL;
using MSSE680.Service;


namespace MSSE680.Business
{
    public class AddressMgr : Manager
    {
        public AddressMgr(){ }

        public void CreateAddress(Address address)
        {
            IAddressSvc addressSvc = (IAddressSvc)GetService("AddressSvcRepoImpl");
            addressSvc.CreateAddress(address);
        }

        public void RemoveAddress(Address address)
        {
            IAddressSvc addressSvc = (IAddressSvc)GetService("AddressSvcRepoImpl");
            addressSvc.RemoveAddress(address);

        }

        public void ModifyAddress(Address address)
        {
            IAddressSvc addressSvc = (IAddressSvc)GetService("AddressSvcRepoImpl");
            addressSvc.ModifyAddress(address);
        }

        public Address RetrieveAddress(String DBColumnName, String StringValue)
        {
            IAddressSvc addressSvc = (IAddressSvc)GetService("AddressSvcRepoImpl");
            return addressSvc.RetrieveAddress(DBColumnName, StringValue);
        }
        public Address RetrieveAddress(String DBColumnName, int IntValue)
        {
            IAddressSvc addressSvc = (IAddressSvc)GetService("AddressSvcRepoImpl");
            return addressSvc.RetrieveAddress(DBColumnName, IntValue);
        }
        public Address RetrieveAddress(String DBColumnName, int? NullableIntValue)
        {
            IAddressSvc addressSvc = (IAddressSvc)GetService("AddressSvcRepoImpl");
            return addressSvc.RetrieveAddress(DBColumnName, NullableIntValue);
        }
        public ICollection<Address> RetrieveAllAddresses()
        {
            IAddressSvc addressSvc = (IAddressSvc)GetService("AddressSvcRepoImpl");
            return addressSvc.RetrieveAllAddresses();
        }
    }
}
