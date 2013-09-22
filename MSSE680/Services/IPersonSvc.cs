using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSE680.DAL;

namespace MSSE680.Service
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
        void RemoveAddressToPerson(Address Address, Person Person);
    }
}
