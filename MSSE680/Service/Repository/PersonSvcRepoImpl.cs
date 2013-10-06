using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using DAL;

namespace Service
{
    public partial class PersonSvcRepoImpl : IPersonSvc
    {
        public DataRepository<Person> PersonRepo;

        public PersonSvcRepoImpl()
        {
            PersonRepo = new DataRepository<Person>();
        }

        public void CreatePerson(Person Person)
        {
            PersonRepo.Insert(Person);
        }
        public void RemovePerson(Person Person)
        {
            PersonRepo.Delete(Person);
        }
        public void ModifyPerson(Person Person)
        {
            PersonRepo.Update(Person);
        }

        public Person RetrievePerson(String DBColumnName, String StringValue)
        {
            return PersonRepo.GetBySpecificKey(DBColumnName, StringValue).FirstOrDefault<Person>();
        }

        public Person RetrievePerson(String DBColumnName, int IntValue)
        {
            return PersonRepo.GetBySpecificKey(DBColumnName, IntValue).FirstOrDefault<Person>();
        }

        public Person RetrievePerson(String DBColumnName, int? NullableIntValue)
        {
            return PersonRepo.GetBySpecificKey(DBColumnName, NullableIntValue).FirstOrDefault<Person>();
        }

        public ICollection<Person> RetrieveAllPeople()
        {
            return PersonRepo.GetAll().ToList<Person>();
        }

        public void AddAddressToPerson(Address Address, Person Person)
        {
            Person.Address_AddressId = Address.AddressId;
            ModifyPerson(Person);
        }
        public void RemoveAddressFromPerson(Address Address, Person Person)
        {
            Person.Address_AddressId = null;
            ModifyPerson(Person);
        }
        public void DisposePerson()
        {
            PersonRepo.Dispose();
        }
    }
}
