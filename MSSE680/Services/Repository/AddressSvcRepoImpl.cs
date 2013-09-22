using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSE680.Service;
using MSSE680.DAL;

namespace MSSE680.Service
{
    public partial class AddressSvcRepoImpl : IAddressSvc
    {
        public DataRepository<Address> AddressRepo;

        public AddressSvcRepoImpl()
        {
            AddressRepo = new DataRepository<Address>();
        }
        public void CreateAddress(Address Address)
        {
            AddressRepo.Insert(Address);
        }
        
        public void RemoveAddress(Address Address)
        {
            AddressRepo.Delete(Address);
        }

        public void ModifyAddress(Address Address)
        {
            AddressRepo.Update(Address);
        }
        public Address RetrieveAddress(String DBColumnName, String StringValue) 
        {

            return AddressRepo.GetBySpecificKey(DBColumnName, StringValue).FirstOrDefault<Address>();
        }
        public Address RetrieveAddress(String DBColumnName, int IntValue)
        {

            return AddressRepo.GetBySpecificKey(DBColumnName, IntValue).FirstOrDefault<Address>();
        }
        public Address RetrieveAddress(String DBColumnName, int? NullableIntValue)
        {

            return AddressRepo.GetBySpecificKey(DBColumnName, NullableIntValue).FirstOrDefault<Address>();
        }
        
        public ICollection<Address> RetrieveAllAddresses()
        {
            return AddressRepo.GetAll().ToList<Address>();
        }
    }
}