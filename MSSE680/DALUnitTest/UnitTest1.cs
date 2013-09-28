using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using MSSE680.DAL;
using MSSE680;

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

            Assert.IsTrue(Address1.validate(), "testAddressValidateTrue Passed");
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
            Person Person1 = new Person(25, (byte)30, "Matthew", "Buller", "mbuller", "Password1", (byte)1, Address1);

            Assert.IsTrue(Person1.validate(), "testPersonValidateTrue Passed");
        }

        /// <summary>
        /// test invalid Person using validate
        /// </summary>
        [TestMethod]
        public void testPersonValidateFalse()
        {
            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);

            Person Person1 = new Person(25, (byte)30, null, "Buller", "mbuller", "Password1", (byte)1, Address1);


            Assert.IsFalse(Person1.validate(), "testPersonValidateTrue Passed");
        }

        /// <summary>
        /// Add Person using entities
        /// </summary>
        [TestMethod]
        public void testPersonAdd()
        {

            bullerEntities db = new bullerEntities();
            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person((byte)30, "Matthew", "Buller", "mbuller", "Password1", (byte)1, Address1);
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
            Person Person1 = new Person((byte)30, "MatthewDel", "Buller", "mbuller", "Password1", (byte)1, Address1);
            db.People.Add(Person1);
            db.SaveChanges();

            Person Person2 = (from a in db.People where a.FirstName == "MatthewDel" select a).Single();
            db.People.Remove(Person2);
            db.SaveChanges();

        }

        /// <summary>
        /// Insert Person using repository
        /// </summary>
        [TestMethod]
        public void testPersonInsertUsingRepository()
        {
            var PersonRepo = new DataRepository<Person>();
            Address Address1 = new Address(2, "Wichita", "1111 Shocker Drive", "KS", 67111);
            Person Person1 = new Person((byte)30, "MatthewInsertRepo1", "BullerInsertRepo1", "mbullerInsertRepo1", "PasswordInsertRepo1", (byte)1, Address1);
            PersonRepo.Insert(Person1);

        }

        /// <summary>
        /// Retrieve Person using repository
        /// </summary>
        [TestMethod]
        public void testPersonRetrieveOneUsingRepository()
        {
            var PersonRepo = new DataRepository<Person>();
            Address Address2 = new Address(2, "WichitaRepo", "2222 ShockerRepo Drive", "KS", 67222);
            Person Person2 = new Person((byte)30, "MatthewRetRepo2", "BullerRetRepo2", "mbullerRetRepo2", "Password1RetRepo2", (byte)2, Address2);

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
            var PersonRepo = new DataRepository<Person>();
            Address Address1 = new Address(2, "Wichita", "1111 Shocker Drive", "KS", 67111);
            Person Person1 = new Person((byte)30, "MatthewRetAllRep1", "BullerInsertRetAllRepo1", "mbullerRetAllRepo1", "PasswordRetAllRepo1", (byte)1, Address1);

            List<Person> myList = PersonRepo.GetAll().ToList<Person>();
            Assert.IsTrue(myList.Count > 0);
        }

        /// <summary>
        /// Delete Person using Repository
        /// </summary>
        [TestMethod]
        public void testPersonDeletetUsingRepository()
        {
            var PersonRepo = new DataRepository<Person>();
            Address Address1 = new Address(2, "Wichita", "1111 Shocker Drive", "KS", 67111);
            Person Person1 = new Person((byte)30, "MatthewRetAllRep1", "BullerInsertRetAllRepo1", "mbullerRetAllRepo1", "PasswordRetAllRepo1", (byte)1, Address1);
            PersonRepo.Insert(Person1);

            PersonRepo.Delete(Person1);
        }

        /// <summary>
        /// Modify Person using Repository
        /// </summary>
        [TestMethod]
        public void testPersonModifyUsingRepository()
        {
            var PersonRepo = new DataRepository<Person>();
            Address Address1 = new Address(2, "Wichita", "1111 Shocker Drive", "KS", 67111);
            Person Person1 = new Person((byte)30, "MatthewModRep1", "BullerModRepo1", "mbullerModRepo1", "PasswordModRepo1", (byte)1, Address1);
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
            Person Person1 = new Person(25, (byte)30, "Matthew", "Buller", "mbuller", "Password1", (byte)1, Address1);
            CreditCard CreditCard1 = new CreditCard(15, 123456789L, 10000, 700, 1, (byte)2, (byte)3, Person1);

            Assert.IsTrue(CreditCard1.validate(), "testCreditCardValidateTrue Passed");
        }

        /// <summary>
        /// Test invalid CreditCard using validate
        /// </summary>
        [TestMethod]
        public void testCreditCardValidateFalse()
        {

            Person Person1 = new Person();

            CreditCard CreditCard1 = new CreditCard(5555, 123456790L, 7000, 650, (byte)1, (byte)1, (byte)1, Person1);

            Assert.IsFalse(CreditCard1.validate(), "testCreditCardValidateFalse Passed");
        }

        /// <summary>
        /// Add CreditCard using entities
        /// </summary>
        [TestMethod]
        public void testCreditCardAdd()
        {

            bullerEntities db = new bullerEntities();
            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person((byte)30, "Matthew", "Buller", "mbuller", "Password1", (byte)1, Address1);
            CreditCard CreditCard1 = new CreditCard(123456789L, 10000, 700, 1, (byte)2, (byte)3, Person1);

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
            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person((byte)30, "Matthew", "Buller", "mbuller", "Password1", (byte)1, Address1);
            CreditCard CreditCard3 = new CreditCard(123456789L, 5555, 700, 1, (byte)2, (byte)3, Person1);
            CreditCard CreditCard1 = new CreditCard(123456789L, 5555, 700, 1, (byte)2, (byte)3);
            db.CreditCards.Add(CreditCard1);
            db.SaveChanges();

            CreditCard CreditCard2 = (from c in db.CreditCards where c.Limit == 5555 select c).Single();
            db.CreditCards.Remove(CreditCard2);
            db.SaveChanges();
        }

        /// <summary>
        /// Insert CreditCard using repository
        /// </summary>
        [TestMethod]
        public void testCreditCardInsertUsingRepository()
        {
            var CreditCardRepo = new DataRepository<CreditCard>();
            Address Address1 = new Address(2, "Wichita", "1111 Shocker Drive", "KS", 67111);
            Person Person1 = new Person((byte)30, "MatthewInsertRepo1", "BullerInsertRepo1", "mbullerInsertRepo1", "PasswordInsertRepo1", (byte)1, Address1);
            CreditCard CreditCard1 = new CreditCard(123456789L, 10000, 700, 1, (byte)2, (byte)3, Person1);
            CreditCardRepo.Insert(CreditCard1);

        }

        /// <summary>
        /// Retrieve CreditCard using repository
        /// </summary>
        [TestMethod]
        public void testCreditCardRetrieveOneUsingRepository()
        {
            var CreditCardRepo = new DataRepository<CreditCard>();
            Address Address2 = new Address(2, "WichitaRepo", "2222 ShockerRepo Drive", "KS", 67222);
            Person Person2 = new Person((byte)30, "MatthewRetRepo2", "BullerRetRepo2", "mbullerRetRepo2", "Password1RetRepo2", (byte)2, Address2);
            CreditCard CreditCard2 = new CreditCard(123456789L, 10000, 700, 1, (byte)2, (byte)3, Person2);
            CreditCardRepo.Insert(CreditCard2);

            CreditCard CreditCard1 = CreditCardRepo.GetBySpecificKey("Limit", 10000).FirstOrDefault<CreditCard>();
            Assert.IsTrue(CreditCard1.validate());
        }

        /// <summary>
        /// Retrieve All CreditCards using repository
        /// </summary>
        [TestMethod]
        public void testCreditCardRetrieveAllUsingRepository()
        {
            var CreditCardRepo = new DataRepository<CreditCard>();
            Address Address1 = new Address(2, "Wichita", "1111 Shocker Drive", "KS", 67111);
            Person Person1 = new Person((byte)30, "MatthewRetAllRep1", "BullerInsertRetAllRepo1", "mbullerRetAllRepo1", "PasswordRetAllRepo1", (byte)1, Address1);
            CreditCard CreditCard1 = new CreditCard(123456789L, 10000, 700, 1, (byte)2, (byte)3, Person1);
            CreditCardRepo.Insert(CreditCard1);

            List<CreditCard> myList = CreditCardRepo.GetAll().ToList<CreditCard>();
            Assert.IsTrue(myList.Count > 0);
        }

        /// <summary>
        /// Delete CreditCard using Repository
        /// </summary>
        [TestMethod]
        public void testCreditCardDeletetUsingRepository()
        {
            var CreditCardRepo = new DataRepository<CreditCard>();
            Address Address1 = new Address(2, "Wichita", "1111 Shocker Drive", "KS", 67111);
            Person Person1 = new Person((byte)30, "MatthewRetAllRep1", "BullerInsertRetAllRepo1", "mbullerRetAllRepo1", "PasswordRetAllRepo1", (byte)1, Address1);
            CreditCard CreditCard1 = new CreditCard(6666666L, 66666, 666, 1, (byte)2, (byte)3, Person1);
            CreditCardRepo.Insert(CreditCard1);

            CreditCardRepo.Delete(CreditCard1);
        }

        /// <summary>
        /// Modify CreditCard using Repository
        /// </summary>
        [TestMethod]
        public void testCreditCardModifyUsingRepository()
        {
            var CreditCardRepo = new DataRepository<CreditCard>();
            Address Address1 = new Address(2, "Wichita", "1111 Shocker Drive", "KS", 67111);
            Person Person1 = new Person((byte)30, "MatthewModRep1", "BullerModRepo1", "mbullerModRepo1", "PasswordModRepo1", (byte)1, Address1);
            CreditCard CreditCard1 = new CreditCard(123456789L, 10000, 700, 1, (byte)2, (byte)3, Person1);
            CreditCardRepo.Insert(CreditCard1);

            CreditCard1.CreditCardNumber = 222222222L;
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
            Person Person1 = new Person(25, (byte)30, "Matthew", "Buller", "mbuller", "Password1", (byte)1, Address1);
            CreditCard CreditCard1 = new CreditCard(15, 123456789L, 10000, 700, 1, (byte)2, (byte)3, Person1);

            Account Account1 = new Account(3,CreditCard1,Person1,2000,200);
                

            Assert.IsTrue(Account1.validate(), "testAccountValidateTrue Passed");
        }

        /// <summary>
        /// Test invalid Account using validate
        /// </summary>
        [TestMethod]
        public void testAccountValidateFalse()
        {
            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person(25, (byte)30, "Matthew", "Buller", "mbuller", "Password1", (byte)1, Address1);
            CreditCard CreditCard1 = new CreditCard(15, 123456789L, 10000, 700, 1, (byte)2, (byte)3, Person1);

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
            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person((byte)30, "Matthew", "Buller", "mbuller", "Password1", (byte)1, Address1);
            CreditCard CreditCard1 = new CreditCard(123456789L, 10000, 700, 1, (byte)2, (byte)3, Person1);
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
                     Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
                   Person Person1 = new Person((byte)30, "Matthew", "Buller", "mbuller", "Password1", (byte)1, Address1);
                   CreditCard CreditCard1 = new CreditCard(123456789L, 10000, 700, 1, (byte)2, (byte)3, Person1);
                   Account Account1 = new Account(CreditCard1, Person1, 3333, 200);
                   db.Accounts.Add(Account1);
                   db.SaveChanges();
       
            Account Account2 = (from c in db.Accounts where c.Limit == 3333 select c).Single();
            db.Accounts.Remove(Account2);
          db.SaveChanges();
        }

        /// <summary>
        /// Insert Account using repository
        /// </summary>
        [TestMethod]
        public void testAccountInsertUsingRepository()
        {
            var AccountRepo = new DataRepository<Account>();
            Address Address1 = new Address(2, "Wichita", "1111 Shocker Drive", "KS", 67111);
            Person Person1 = new Person((byte)30, "MatthewInsertRepo1", "BullerInsertRepo1", "mbullerInsertRepo1", "PasswordInsertRepo1", (byte)1, Address1);
            CreditCard CreditCard1 = new CreditCard(123456789L, 10000, 700, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 2000, 200);
            AccountRepo.Insert(Account1);
        }

        /// <summary>
        /// Retrieve Account using repository
        /// </summary>
        [TestMethod]
        public void testAccountRetrieveOneUsingRepository()
        {
            var AccountRepo = new DataRepository<Account>();
            Address Address1 = new Address(2, "WichitaRetRepo", "2222 ShockerRetRepo Drive", "KS", 67222);
            Person Person1 = new Person((byte)30, "MatthewRetRepo2", "BullerRetRepo2", "mbullerRetRepo2", "Password1RetRepo2", (byte)2, Address1);
            CreditCard CreditCard1 = new CreditCard(123456789L, 10000, 700, 1, (byte)2, (byte)3, Person1);
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
            var AccountRepo = new DataRepository<Account>();
            Address Address1 = new Address(2, "Wichita", "1111 Shocker Drive", "KS", 67111);
            Person Person1 = new Person((byte)30, "MatthewRetAllRep1", "BullerInsertRetAllRepo1", "mbullerRetAllRepo1", "PasswordRetAllRepo1", (byte)1, Address1);
            CreditCard CreditCard1 = new CreditCard(123456789L, 10000, 700, 1, (byte)2, (byte)3, Person1);
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
            var AccountRepo = new DataRepository<Account>();
            Address Address1 = new Address(2, "Wichita", "1111 Shocker Drive", "KS", 67111);
            Person Person1 = new Person((byte)30, "MatthewRetAllRep1", "BullerInsertRetAllRepo1", "mbullerRetAllRepo1", "PasswordRetAllRepo1", (byte)1, Address1);
            CreditCard CreditCard1 = new CreditCard(123456789L, 10000, 700, 1, (byte)2, (byte)3, Person1);
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
            var AccountRepo = new DataRepository<Account>();
            Address Address1 = new Address(2, "Wichita", "1111 Shocker Drive", "KS", 67111);
            Person Person1 = new Person((byte)30, "MatthewModRep1", "BullerModRepo1", "mbullerModRepo1", "PasswordModRepo1", (byte)1, Address1);
            CreditCard CreditCard1 = new CreditCard(123456789L, 10000, 700, 1, (byte)2, (byte)3, Person1);
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
        /// Test valid Account using validate
        /// </summary>
        [TestMethod]
        public void testTransactionValidateTrue()
        {
            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person(25, (byte)30, "Matthew", "Buller", "mbuller", "Password1", (byte)1, Address1);
            CreditCard CreditCard1 = new CreditCard(15, 123456789L, 10000, 700, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(3,CreditCard1,Person1,2000,200);

            Transaction Transaction1 = new Transaction(5, 200, 2, 3, 13, "ABC", CreditCard1);
            Assert.IsTrue(Transaction1.validate(), "testTransitionValidateTrue Passed");
        }

        /// <summary>
        /// Test invalid Account using validate
        /// </summary>
        [TestMethod]
        public void testTransactionValidateFalse()
        {

            Transaction Transaction2 = new Transaction(4, 200, 0, 3, 13, "ABC");
            Assert.IsFalse(Transaction2.validate(), "testTransitionValidateFalse Passed");
        }

        /// <summary>
        /// Add Account using entities
        /// </summary>
        [TestMethod]
        public void testTransactionAdd()
        {

            bullerEntities db = new bullerEntities();
            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person((byte)30, "Matthew", "Buller", "mbuller", "Password1", (byte)1, Address1);
            CreditCard CreditCard1 = new CreditCard(123456789L, 10000, 700, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 2000, 200);
            Transaction Transaction1 = new Transaction(200, 2, 3, 13, "ABC", CreditCard1);

            db.Transactions.Add(Transaction1);
            db.SaveChanges();
        }

        /// <summary>
        /// Delete Account using entities
        /// </summary>
        [TestMethod]
        public void testTransactionDelete()
        {

            bullerEntities db = new bullerEntities();
            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person((byte)30, "Matthew", "Buller", "mbuller", "Password1", (byte)1, Address1);
            CreditCard CreditCard1 = new CreditCard(123456789L, 10000, 700, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 3333, 200);
            Transaction Transaction1 = new Transaction(200, 2, 3, 13, "DeleteMe", CreditCard1);
            db.Transactions.Add(Transaction1);
            db.SaveChanges();

            Transaction Transaction2 = (from c in db.Transactions where c.BusinessName == "DeleteMe" select c).Single();
            db.Transactions.Remove(Transaction2);
            db.SaveChanges();
        }

        /// <summary>
        /// Insert Account using repository
        /// </summary>
        [TestMethod]
        public void testTransactionInsertUsingRepository()
        {
            var TransactionRepo = new DataRepository<Transaction>();
            Address Address1 = new Address(2, "Wichita", "1111 Shocker Drive", "KS", 67111);
            Person Person1 = new Person((byte)30, "MatthewInsertRepo1", "BullerInsertRepo1", "mbullerInsertRepo1", "PasswordInsertRepo1", (byte)1, Address1);
            CreditCard CreditCard1 = new CreditCard(123456789L, 10000, 700, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 2000, 200);
            Transaction Transaction1 = new Transaction(5, 200, 2, 3, 13, "ABC", CreditCard1);
            TransactionRepo.Insert(Transaction1);
        }

        /// <summary>
        /// Retrieve Account using repository
        /// </summary>
        [TestMethod]
        public void testTransactionRetrieveOneUsingRepository()
        {
            var TransactionRepo = new DataRepository<Transaction>();
            Address Address1 = new Address(2, "WichitaRetRepo", "2222 ShockerRetRepo Drive", "KS", 67222);
            Person Person1 = new Person((byte)30, "MatthewRetRepo2", "BullerRetRepo2", "mbullerRetRepo2", "Password1RetRepo2", (byte)2, Address1);
            CreditCard CreditCard1 = new CreditCard(123456789L, 10000, 700, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 2000, 200);
            Transaction Transaction1 = new Transaction(5, 200, 2, 3, 13, "FindMe", CreditCard1);
            TransactionRepo.Insert(Transaction1);

            Transaction Transaction2 = TransactionRepo.GetBySpecificKey("BusinessName", "FindMe").FirstOrDefault<Transaction>();
            Assert.IsTrue(Transaction2.validate());
        }

        /// <summary>
        /// Retrieve All Accounts using repository
        /// </summary>
        [TestMethod]
        public void testTransactionRetrieveAllUsingRepository()
        {
            var TransactionRepo = new DataRepository<Transaction>();
            Address Address1 = new Address(2, "Wichita", "1111 Shocker Drive", "KS", 67111);
            Person Person1 = new Person((byte)30, "MatthewRetAllRep1", "BullerInsertRetAllRepo1", "mbullerRetAllRepo1", "PasswordRetAllRepo1", (byte)1, Address1);
            CreditCard CreditCard1 = new CreditCard(123456789L, 10000, 700, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 2000, 200);
            Transaction Transaction1 = new Transaction(5, 200, 2, 3, 13, "ABC", CreditCard1);
            TransactionRepo.Insert(Transaction1);

            List<Transaction> myList = TransactionRepo.GetAll().ToList<Transaction>();
            Assert.IsTrue(myList.Count > 0);
        }

        /// <summary>
        /// Delete Account using Repository
        /// </summary>
        [TestMethod]
        public void testTransactionDeletetUsingRepository()
        {
            var TransactionRepo = new DataRepository<Transaction>();
            Address Address1 = new Address(2, "Wichita", "1111 Shocker Drive", "KS", 67111);
            Person Person1 = new Person((byte)30, "MatthewRetAllRep1", "BullerInsertRetAllRepo1", "mbullerRetAllRepo1", "PasswordRetAllRepo1", (byte)1, Address1);
            CreditCard CreditCard1 = new CreditCard(123456789L, 10000, 700, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 6666, 666);
            Transaction Transaction1 = new Transaction(5, 200, 2, 3, 13, "DeleteMeRepo", CreditCard1);
            TransactionRepo.Insert(Transaction1);

            TransactionRepo.Delete(Transaction1);
        }

        /// <summary>
        /// Modify Account using Repository
        /// </summary>
        [TestMethod]
        public void testTransactionModifyUsingRepository()
        {
            var TransactionRepo = new DataRepository<Transaction>();
            Address Address1 = new Address(2, "Wichita", "1111 Shocker Drive", "KS", 67111);
            Person Person1 = new Person((byte)30, "MatthewModRep1", "BullerModRepo1", "mbullerModRepo1", "PasswordModRepo1", (byte)1, Address1);
            CreditCard CreditCard1 = new CreditCard(123456789L, 10000, 700, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 2000, 200);
            Transaction Transaction1 = new Transaction(5, 200, 2, 3, 13, "ABC", CreditCard1);
            TransactionRepo.Insert(Transaction1);

            Transaction1.BusinessName = "ModifiedBusinessName";
            TransactionRepo.Update(Transaction1);
        }
    }
     
}
