using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSE680.DAL;

namespace MSSE680.Service
{
    public interface IAddressSvc : IService
    {
        void CreateAddress(Address Address);
        void RemoveAddress(Address Address);
        void ModifyAddress(Address Address);
        Address RetrieveAddress(String DBColumnName, String StringValue);
        Address RetrieveAddress(String DBColumnName, int IntValue);
        Address RetrieveAddress(String DBColumnName, int? NullableIntValue);

        ICollection<Address> RetrieveAllAddresses();
    }
}
