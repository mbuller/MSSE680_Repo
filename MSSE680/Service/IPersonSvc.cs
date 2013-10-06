using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Service
{
    public interface IPersonSvc : IService
    {
        void CreatePerson(Person Person);
        void RemovePerson(Person Person);
        void ModifyPerson(Person Person);
        Person RetrievePerson(String DBColumnName, String StringValue);
        Person RetrievePerson(String DBColumnName, int IntValue);
        Person RetrievePerson(String DBColumnName, int? NullableIntValue);
        ICollection<Person> RetrieveAllPeople();

        void AddAddressToPerson(Address Address, Person Person);
        void RemoveAddressFromPerson(Address Address, Person Person);

        void DisposePerson();
    }
}
