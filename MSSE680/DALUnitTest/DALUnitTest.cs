using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using DAL;
using System.Data.SqlClient;

namespace DALUnitTest
{

    [TestClass]
    public class AddressTest
    {
        /// <summary>
        /// test valid Address using validate
        /// </summary>
        [TestMethod]
        public void testAddressValidateTrue()
        {
            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);

           // Assert.IsTrue(Address1.validate(), "testAddressValidateTrue Passed");
        }

        /// <summary>
        /// test invalid Address using validate
        /// </summary>
        [TestMethod]
        public void testAddressValidateFalse()
        {
            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 0);

            Assert.IsFalse(Address1.validate(), "testAddressValidateFalse Passed");
        }

        /// <summary>
        /// Add Address using entities
        /// </summary>
        [TestMethod]
        public void testAddressAdd()
        {

            bullerEntities db = new bullerEntities();
            Address Address1 = new Address("TestCityAdd", "TestStreetAdd", "KS", 67213);
            db.Addresses.Add(Address1);
            db.SaveChanges();
        }

        /// <summary>
        /// Delete Address using entities
        /// </summary>
        [TestMethod]
        public void testAddressDelete()
        {

            bullerEntities db = new bullerEntities();
            Address Address1 = new Address("TestCityDel", "TestStreetDel", "KS", 67213);
            db.Addresses.Add(Address1);
            db.SaveChanges();

            Address Address2 = (from a in db.Addresses where a.City == "TestCityDel" select a).Single();
            db.Addresses.Remove(Address2);
            db.SaveChanges();
        }

        /// <summary>
        /// Insert Address using repository
        /// </summary>
        [TestMethod]
        public void testAddressInsertUsingRepository()
        {
            var AddressRepo = new DataRepository<Address>();
            Address Address1 = new Address("TestAddressCityRepo1", "111 TestAddressStreetRepo1", "KS", 11111);
            AddressRepo.Insert(Address1);
        }

        /// <summary>
        /// Retrieve All Addresses using repository
        /// </summary>
        [TestMethod]
        public void testAddressRetrieveAllUsingRepository()
        {
            var AddressRepo = new DataRepository<Address>();
            Address Address1 = new Address("Wichita", "1111 Shocker Drive", "KS", 67111);
            AddressRepo.Insert(Address1);
            List<Address> myList = AddressRepo.GetAll().ToList<Address>();
            Assert.IsTrue(myList.Count > 0);
        }

        /// <summary>
        /// Retrieve Address using repository
        /// </summary>
        [TestMethod]
        public void testAddressRetrieveOneUsingRepository()
        {
            var AddressRepo = new DataRepository<Address>();
            Address Address1 = new Address("TestAddressCityRepo1", "111 TestAddressStreetRepo1", "KS", 11111);
            Address address1 = AddressRepo.GetBySpecificKey("City", "TestAddressCityRepo1").FirstOrDefault<Address>();
            Assert.IsTrue(address1.validate());
        }

        /// <summary>
        /// Delete Address using Repository
        /// </summary>
        [TestMethod]
        public void testAddressDeletetUsingRepository()
        {
            var AddressRepo = new DataRepository<Address>();
            Address Address1 = new Address("TestAddressCityRepoDel1", "111 TestAddressStreetRepoDel1", "KS", 11111);
            AddressRepo.Insert(Address1);

            AddressRepo.Delete(Address1);
        }

        /// <summary>
        /// Modify Address using Repository
        /// </summary>
        [TestMethod]
        public void testAddressModifyUsingRepository()
        {
            var AddressRepo = new DataRepository<Address>();
            Address Address1 = new Address("TestAddressCityRepoMod1", "111 TestAddressStreetRepoMod1", "KS", 11111);
            AddressRepo.Insert(Address1); 
            Address1.City = "modCity";
            AddressRepo.Update(Address1);
        }

    }

    [TestClass]
    public class PersonTest
    {
        /// <summary>
        /// Test valid Person using validate
        /// </summary>
        [TestMethod]
        public void testPersonValidateTrue()
        {
            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person(25, (byte)30, "Matthew", "Buller", "mbuller", Address1);

            Assert.IsTrue(Person1.validate(), "testPersonValidateTrue Passed");
        }

        /// <summary>
        /// test invalid Person using validate
        /// </summary>
        [TestMethod]
        public void testPersonValidateFalse()
        {
            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);

            Person Person1 = new Person(25, (byte)30, null, "Buller", "mbuller", Address1);


            Assert.IsFalse(Person1.validate(), "testPersonValidateTrue Passed");
        }

        /// <summary>
        /// Add Person using entities
        /// </summary>
        [TestMethod]
        public void testPersonAdd()
        {

            bullerEntities db = new bullerEntities();
            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            //            personIdVal = (personIdVal == null) ? personIdVal : 1;

            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person((byte)30, "Matthew", "Buller", "mbuller_" + personIdVal, Address1);
            db.People.Add(Person1);
            db.SaveChanges();
        }

        /// <summary>
        /// Delete Person using entities
        /// </summary>
        [TestMethod]
        public void testPersonDelete()
        {

            bullerEntities db = new bullerEntities();
            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;

            Person Person1 = new Person((byte)30, "MatthewDel", "Buller", "mbuller_" + personIdVal, Address1);
            db.People.Add(Person1);





            //Person Person2 = (from a in db.People where a.FirstName == "MatthewDel" select a).Single();
            db.People.Remove(Person1);
            db.SaveChanges();

        }
    

        /// <summary>
        /// Insert Person using repository
        /// </summary>
        [TestMethod]
        public void testPersonInsertUsingRepository()
        {
            bullerEntities db = new bullerEntities();
            
            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;

            var PersonRepo = new DataRepository<Person>();
            Address Address1 = new Address(2, "Wichita", "1111 Shocker Drive", "KS", 67111);
            Person Person1 = new Person((byte)30, "MatthewInsertRepo1", "BullerInsertRepo1", "mbullerInsertRepo1_" + personIdVal,  Address1);
            PersonRepo.Insert(Person1);

        }

        /// <summary>
        /// Retrieve Person using repository
        /// </summary>
        [TestMethod]
        public void testPersonRetrieveOneUsingRepository()
        {
            bullerEntities db = new bullerEntities();
           var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;

            var PersonRepo = new DataRepository<Person>();
            Address Address2 = new Address(2, "WichitaRepo", "2222 ShockerRepo Drive", "KS", 67222);
            Person Person2 = new Person((byte)30, "MatthewRetRepo2", "BullerRetRepo2", "mbullerRetRepo2_" + personIdVal, Address2);

            PersonRepo.Insert(Person2);

            Person Person1 = PersonRepo.GetBySpecificKey("FirstName", "MatthewRetRepo2").FirstOrDefault<Person>();
            Assert.IsTrue(Person1.validate());
        }

        /// <summary>
        /// Retrieve All Persons using repository
        /// </summary>
        [TestMethod]
        public void testPersonRetrieveAllUsingRepository()
        {
            bullerEntities db = new bullerEntities();
           var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;

            var PersonRepo = new DataRepository<Person>();
            Address Address1 = new Address(2, "Wichita", "1111 Shocker Drive", "KS", 67111);
            Person Person1 = new Person((byte)30, "MatthewRetAllRep1", "BullerInsertRetAllRepo1", "mbullerRetAllRepo1_" + personIdVal,  Address1);

            List<Person> myList = PersonRepo.GetAll().ToList<Person>();
            Assert.IsTrue(myList.Count > 0);
        }

        /// <summary>
        /// Delete Person using Repository
        /// </summary>
        [TestMethod]
        public void testPersonDeletetUsingRepository()
        {
            bullerEntities db = new bullerEntities();
            
            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;

            var PersonRepo = new DataRepository<Person>();
            Address Address1 = new Address(2, "Wichita", "1111 Shocker Drive", "KS", 67111);
            Person Person1 = new Person((byte)30, "MatthewRetAllRep1", "BullerInsertRetAllRepo1", "mbullerRetAllRepo1_" + personIdVal,  Address1);
            PersonRepo.Insert(Person1);

            PersonRepo.Delete(Person1);
        }

        /// <summary>
        /// Modify Person using Repository
        /// </summary>
        [TestMethod]
        public void testPersonModifyUsingRepository()
        {
            bullerEntities db = new bullerEntities();
           var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;

            var PersonRepo = new DataRepository<Person>();
            Address Address1 = new Address(2, "Wichita", "1111 Shocker Drive", "KS", 67111);
            Person Person1 = new Person((byte)30, "MatthewModRep1", "BullerModRepo1", "mbullerModRepo_" + personIdVal,  Address1);
            PersonRepo.Insert(Person1);

            Person1.FirstName = "ModifiedFirstName";
            PersonRepo.Update(Person1);
        }
    }

    [TestClass]
    public class CreditCardTest
    {
        /// <summary>
        /// Test valid CreditCard using validate
        /// </summary>
        [TestMethod]
        public void testCreditCardValidateTrue()
        {
            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person(25, (byte)30, "Matthew", "Buller", "mbuller", Address1);
            CreditCard CreditCard1 = new CreditCard(15, 900000000000L, 10000, 700, 1, (byte)2, (byte)3, Person1);

            Assert.IsTrue(CreditCard1 != null);
        }

        /// <summary>
        /// Test invalid CreditCard using validate
        /// </summary>
        [TestMethod]
        public void testCreditCardValidateFalse()
        {

            Person Person1 = new Person();

            CreditCard CreditCard1 = new CreditCard(5555, 123456790L, 7000, 650, (byte)1, (byte)1, (byte)1, Person1);

            Assert.IsFalse(CreditCard1 == null);
        }

        /// <summary>
        /// Add CreditCard using entities
        /// </summary>
        [TestMethod]
        public void testCreditCardAdd()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person((byte)30, "Matthew", "Buller", "mbuller_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 5555, 700, 1, (byte)2, (byte)3);
            db.CreditCards.Add(CreditCard1);
            db.SaveChanges();


        }

        /// <summary>
        /// Delete CreditCard using entities
        /// </summary>
        [TestMethod]
        public void testCreditCardDelete()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person((byte)30, "Matthew", "Buller", "mbuller_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 5555, 700, 1, (byte)2, (byte)3);
            db.CreditCards.Add(CreditCard1);
            db.SaveChanges();


            db.CreditCards.Remove(CreditCard1);
            db.SaveChanges();
        }

        /// <summary>
        /// Insert CreditCard using repository
        /// </summary>
        [TestMethod]
        public void testCreditCardInsertUsingRepository()
        {
            bullerEntities db = new bullerEntities();
            var CreditCardRepo = new DataRepository<CreditCard>();
            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person((byte)30, "Matthew", "Buller", "mbuller_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 5555, 700, 1, (byte)2, (byte)3);

            CreditCardRepo.Insert(CreditCard1);

        }

        /// <summary>
        /// Retrieve CreditCard using repository
        /// </summary>
        [TestMethod]
        public void testCreditCardRetrieveOneUsingRepository()
        {
            bullerEntities db = new bullerEntities();
            var CreditCardRepo = new DataRepository<CreditCard>();
            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person((byte)30, "Matthew", "Buller", "mbuller_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 5555, 700, 1, (byte)2, (byte)3);

            CreditCardRepo.Insert(CreditCard1);

            CreditCard CreditCard2 = CreditCardRepo.GetBySpecificKey("Limit", (int?)5555).FirstOrDefault<CreditCard>();
            Assert.IsTrue(CreditCard2 != null);
        }

        /// <summary>
        /// Retrieve All CreditCards using repository
        /// </summary>
        [TestMethod]
        public void testCreditCardRetrieveAllUsingRepository()
        {
            bullerEntities db = new bullerEntities();
            var CreditCardRepo = new DataRepository<CreditCard>();
            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person((byte)30, "Matthew", "Buller", "mbuller_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 5555, 700, 1, (byte)2, (byte)3);

            List<CreditCard> myList = CreditCardRepo.GetAll().ToList<CreditCard>();
            Assert.IsTrue(myList.Count > 0);
        }

        /// <summary>
        /// Delete CreditCard using Repository
        /// </summary>
        [TestMethod]
        public void testCreditCardDeletetUsingRepository()
        {

            bullerEntities db = new bullerEntities();
            var CreditCardRepo = new DataRepository<CreditCard>();
            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person((byte)30, "Matthew", "Buller", "mbuller_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 5555, 700, 1, (byte)2, (byte)3);

            CreditCardRepo.Insert(CreditCard1);

            CreditCardRepo.Delete(CreditCard1);
        }

        /// <summary>
        /// Modify CreditCard using Repository
        /// </summary>
        [TestMethod]
        public void testCreditCardModifyUsingRepository()
        {
            bullerEntities db = new bullerEntities();
            var CreditCardRepo = new DataRepository<CreditCard>();
            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person((byte)30, "Matthew", "Buller", "mbuller_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 5555, 700, 1, (byte)2, (byte)3);

            CreditCardRepo.Insert(CreditCard1);

            CreditCard1.Balance = 654;
            CreditCardRepo.Update(CreditCard1);
        }
    }

    [TestClass]
    public class AccountTest
    {
        /// <summary>
        /// Test valid Account using validate
        /// </summary>
        [TestMethod]
        public void testAccountValidateTrue()
        {

            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person(25, (byte)30, "Matthew", "Buller", "mbuller", Address1);
            CreditCard CreditCard1 = new CreditCard(15, 10000, 700, 1, (byte)2, (byte)3, Person1);

            Account Account1 = new Account(3, CreditCard1, Person1, 2000, 200);


            Assert.IsTrue(Account1 != null);
        }

        /// <summary>
        /// Test invalid Account using validate
        /// </summary>
        [TestMethod]
        public void testAccountValidateFalse()
        {
            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person(25, (byte)30, "Matthew", "Buller", "mbuller", Address1);
            CreditCard CreditCard1 = new CreditCard(15, 900000000000L, 10000, 700, 1, (byte)2, (byte)3, Person1);

            Account Account1 = new Account(-1, CreditCard1, Person1);

            Assert.IsFalse(Account1.validate(), "testAccountValidateFalse Passed");
        }

        /// <summary>
        /// Add Account using entities
        /// </summary>
        [TestMethod]
        public void testAccountAdd()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person((byte)30, "Matthew", "Buller", "mbuller_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 10000, 700, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 2000, 200);

            db.Accounts.Add(Account1);
            db.SaveChanges();
        }

        /// <summary>
        /// Delete Account using entities
        /// </summary>
        [TestMethod]
        public void testAccountDelete()
        {

            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person((byte)30, "Matthew", "Buller", "mbuller_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 10000, 700, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 3333, 200);
            db.Accounts.Add(Account1);
            db.SaveChanges();

            db.Accounts.Remove(Account1);
            db.SaveChanges();
        }

        /// <summary>
        /// Insert Account using repository
        /// </summary>
        [TestMethod]
        public void testAccountInsertUsingRepository()
        {
            bullerEntities db = new bullerEntities();
            
            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            var AccountRepo = new DataRepository<Account>();
            Address Address1 = new Address(2, "Wichita", "1111 Shocker Drive", "KS", 67111);
            Person Person1 = new Person((byte)30, "MatthewInsertRepo1", "BullerInsertRepo1", "mbullerInsertRepo1_" + personIdVal,  Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 10000, 700, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 2000, 200);
            AccountRepo.Insert(Account1);
        }

        /// <summary>
        /// Retrieve Account using repository
        /// </summary>
        [TestMethod]
        public void testAccountRetrieveOneUsingRepository()
        {
            bullerEntities db = new bullerEntities();
            
            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            var AccountRepo = new DataRepository<Account>();
            Address Address1 = new Address(2, "WichitaRetRepo", "2222 ShockerRetRepo Drive", "KS", 67222);
            Person Person1 = new Person((byte)30, "MatthewRetRepo2", "BullerRetRepo2", "mbullerRetRepo2_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 10000, 700, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 2000, 200);
            AccountRepo.Insert(Account1);

            Account Account2 = AccountRepo.GetBySpecificKey("Limit", 2000).FirstOrDefault<Account>();
            Assert.IsTrue(Account2.Limit == 2000);
        }

        /// <summary>
        /// Retrieve All Accounts using repository
        /// </summary>
        [TestMethod]
        public void testAccountRetrieveAllUsingRepository()
        {
            bullerEntities db = new bullerEntities();
            
            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            var AccountRepo = new DataRepository<Account>();
            Address Address1 = new Address(2, "Wichita", "1111 Shocker Drive", "KS", 67111);
            Person Person1 = new Person((byte)30, "MatthewRetAllRep1", "BullerInsertRetAllRepo1", "mbullerRetAllRepo1_" + personIdVal,  Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 10000, 700, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 2000, 200);
            AccountRepo.Insert(Account1);
            
            List<Account> myList = AccountRepo.GetAll().ToList<Account>();
            Assert.IsTrue(myList.Count > 0);
        }

        /// <summary>
        /// Delete Account using Repository
        /// </summary>
        [TestMethod]
        public void testAccountDeletetUsingRepository()
        {
            bullerEntities db = new bullerEntities();
            
            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            var AccountRepo = new DataRepository<Account>();
            Address Address1 = new Address(2, "Wichita", "1111 Shocker Drive", "KS", 67111);
            Person Person1 = new Person((byte)30, "MatthewRetAllRep1", "BullerInsertRetAllRepo1", "mbullerRetAllRepo1_" + personIdVal,  Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 10000, 700, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 6666, 666);
            AccountRepo.Insert(Account1);

            AccountRepo.Delete(Account1);
        }

        /// <summary>
        /// Modify Account using Repository
        /// </summary>
        [TestMethod]
        public void testAccountModifyUsingRepository()
        {
            bullerEntities db = new bullerEntities();
            
            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            var AccountRepo = new DataRepository<Account>();
            Address Address1 = new Address(2, "Wichita", "1111 Shocker Drive", "KS", 67111);
            Person Person1 = new Person((byte)30, "MatthewModRep1", "BullerModRepo1", "mbullerModRepo1_" + personIdVal,  Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 10000, 700, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 2000, 200);
            AccountRepo.Insert(Account1);

            Account1.Limit = 2222222;
            AccountRepo.Update(Account1);
        }         
    }
 
    [TestClass]
    public class TransactionTest
    {
        /// <summary>
        /// Test valid Transaction using validate
        /// </summary>
        [TestMethod]
        public void testTransactionValidateTrue()
        {
            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person(25, (byte)30, "Matthew", "Buller", "mbuller", Address1);
            CreditCard CreditCard1 = new CreditCard(15, 900000000000L, 10000, 700, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(3,CreditCard1,Person1,2000,200);

            Transaction Transaction1 = new Transaction(5, 200, 2, 3, 13, "ABC", CreditCard1);
            Assert.IsTrue(Transaction1 != null);
        }

        /// <summary>
        /// Test invalid Transaction using validate
        /// </summary>
        [TestMethod]
        public void testTransactionValidateFalse()
        {

            Transaction Transaction2 = new Transaction(4, 200, 0, 3, 13, "ABC");
            Assert.IsFalse(Transaction2.validate(), "testTransitionValidateFalse Passed");
        }

        /// <summary>
        /// Add Transaction using entities
        /// </summary>
        [TestMethod]
        public void testTransactionAdd()
        {

            bullerEntities db = new bullerEntities();
            var CreditCardRepo = new DataRepository<CreditCard>();
            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person((byte)30, "Matthew", "Buller", "mbuller_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 5555, 700, 1, (byte)2, (byte)3);
            Account Account1 = new Account(CreditCard1, Person1, 2000, 200);
            Transaction Transaction1 = new Transaction(200, 2, 3, 13, "ABC", CreditCard1);

            db.Transactions.Add(Transaction1);
            db.SaveChanges();
        }

        /// <summary>
        /// Delete Transaction using entities
        /// </summary>
        [TestMethod]
        public void testTransactionDelete()
        {
            bullerEntities db = new bullerEntities();

            var CreditCardRepo = new DataRepository<CreditCard>();
            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person((byte)30, "Matthew", "Buller", "mbuller_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 5555, 700, 1, (byte)2, (byte)3);
            Account Account1 = new Account(CreditCard1, Person1, 3333, 200);
            Transaction Transaction1 = new Transaction(200, 2, 3, 13, "DeleteMe", CreditCard1);
            db.Transactions.Add(Transaction1);
            db.SaveChanges();

            
            db.Transactions.Remove(Transaction1);
            db.SaveChanges();
        }
    
        /// <summary>
        /// Insert Transaction using repository
        /// </summary>
        [TestMethod]
        public void testTransactionInsertUsingRepository()
        {
            bullerEntities db = new bullerEntities();
            var TransactionRepo = new DataRepository<Transaction>();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person((byte)30, "Matthew", "Buller", "mbuller_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 5555, 700, 1, (byte)2, (byte)3);
            Account Account1 = new Account(CreditCard1, Person1, 2000, 200);
            Transaction Transaction1 = new Transaction(5, 200, 2, 3, 13, "ABC", CreditCard1);
            TransactionRepo.Insert(Transaction1);
        }

        /// <summary>
        /// Retrieve Transaction using repository
        /// </summary>
        [TestMethod]
        public void testTransactionRetrieveOneUsingRepository()
        {
            bullerEntities db = new bullerEntities();
            
            var TransactionRepo = new DataRepository<Transaction>();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person((byte)30, "Matthew", "Buller", "mbuller_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 5555, 700, 1, (byte)2, (byte)3);
            Account Account1 = new Account(CreditCard1, Person1, 2000, 200);
            Transaction Transaction1 = new Transaction(5, 200, 2, 3, 13, "FindMe", CreditCard1);
            TransactionRepo.Insert(Transaction1);


            Assert.IsTrue(Transaction1 != null);
        }

        /// <summary>
        /// Retrieve All Transactions using repository
        /// </summary>
        [TestMethod]
        public void testTransactionRetrieveAllUsingRepository()
        {
            bullerEntities db = new bullerEntities();
            
            var TransactionRepo = new DataRepository<Transaction>();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person((byte)30, "Matthew", "Buller", "mbuller_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 5555, 700, 1, (byte)2, (byte)3);
            Account Account1 = new Account(CreditCard1, Person1, 2000, 200);
            Transaction Transaction1 = new Transaction(5, 200, 2, 3, 13, "ABC", CreditCard1);
            TransactionRepo.Insert(Transaction1);

            List<Transaction> myList = TransactionRepo.GetAll().ToList<Transaction>();
            Assert.IsTrue(myList.Count > 0);
        }

        /// <summary>
        /// Delete Transaction using Repository
        /// </summary>
        [TestMethod]
        public void testTransactionDeletetUsingRepository()
        {
            bullerEntities db = new bullerEntities();
            
            var TransactionRepo = new DataRepository<Transaction>();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person((byte)30, "Matthew", "Buller", "mbuller_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 5555, 700, 1, (byte)2, (byte)3);
            Account Account1 = new Account(CreditCard1, Person1, 6666, 666);
            Transaction Transaction1 = new Transaction(5, 200, 2, 3, 13, "DeleteMeRepo", CreditCard1);
            TransactionRepo.Insert(Transaction1);

            TransactionRepo.Delete(Transaction1);
        }

        /// <summary>
        /// Modify Transaction using Repository
        /// </summary>
        [TestMethod]
        public void testTransactionModifyUsingRepository()
        {
            bullerEntities db = new bullerEntities();
            
            var TransactionRepo = new DataRepository<Transaction>();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person((byte)30, "Matthew", "Buller", "mbuller_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 5555, 700, 1, (byte)2, (byte)3);
            Account Account1 = new Account(CreditCard1, Person1, 2000, 200);
            Transaction Transaction1 = new Transaction(5, 200, 2, 3, 13, "ABC", CreditCard1);
            TransactionRepo.Insert(Transaction1);

            Transaction1.BusinessName = "ModifiedBusinessName";
            TransactionRepo.Update(Transaction1);
        }
    }
     
}
