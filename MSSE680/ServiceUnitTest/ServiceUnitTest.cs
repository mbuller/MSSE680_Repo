using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Service;

namespace ServiceUnitTest
{
    [TestClass]
    public class IAdressSvcTest
    {
        /// <summary>
        /// Create Address using Address Repository Service
        /// </summary>
        [TestMethod]
        public void TestAddressRepoSvcCreate()
        {
            Address Address1 = new Address("ServiceCityCreate", "ServiceStreetCreate", "KS", 55555);

            SvcFactory GetFactory = SvcFactory.GetInstance();
            IAddressSvc AddressSvc = (IAddressSvc)GetFactory.GetService("AddressSvcRepoImpl");
            AddressSvc.CreateAddress(Address1);
        }

        /// <summary>
        /// Remove Address using Address Repository Service
        /// </summary>
        [TestMethod]
        public void TestAddressRepoSvcRemove()
        {
            Address Address1 = new Address("ServiceCityRemove", "ServiceStreetRemove", "KS", 55555);

            var GetFactory = SvcFactory.GetInstance();
            IAddressSvc AddressSvc = (IAddressSvc)GetFactory.GetService("AddressSvcRepoImpl");
            AddressSvc.CreateAddress(Address1);

            AddressSvc.RemoveAddress(Address1);

        }

        /// <summary>
        /// Modify Address using Address Repository Service
        /// </summary>
        [TestMethod]
        public void TestAddressRepoSvcModify()
        {
            Address Address1 = new Address("ServiceCityModify", "ServiceStreetModify", "KS", 55555);

            var GetFactory = SvcFactory.GetInstance();
            IAddressSvc AddressSvc = (IAddressSvc)GetFactory.GetService("AddressSvcRepoImpl");
            AddressSvc.CreateAddress(Address1);

            Address1.City = "ServiceCityModify" + Address1.AddressId;
            Address1.Street = "ServiceSteetModify" + Address1.AddressId;

            AddressSvc.ModifyAddress(Address1);
        }

        /// <summary>
        /// Retrieve Address using Address Repository Service
        /// </summary>
        [TestMethod]
        public void TestAddressRepoSvcRetrieve()
        {
            Address Address1 = new Address("ServiceCityRetrieve", "ServiceStreetRetrieve", "KS", 55555);

            var GetFactory = SvcFactory.GetInstance();
            IAddressSvc AddressSvc = (IAddressSvc)GetFactory.GetService("AddressSvcRepoImpl");
            AddressSvc.CreateAddress(Address1);

            Address Address2 = AddressSvc.RetrieveAddress("City", "ServiceCityRetrieve");

            Assert.IsTrue(Address2.validate());
        }


        /// <summary>
        /// Retrieve All Addresses using Address Repository Service
        /// </summary>
        [TestMethod]
        public void testAddressSvcRepoRetrieveAll()
        {
            Address Address1 = new Address("ServiceCityRetrieveAll", "ServiceStreetRetrieveAll", "KS", 55555);

            var AddressRepo = new DataRepository<Address>();
            var GetFactory = SvcFactory.GetInstance();
            IAddressSvc AddressSvc = (IAddressSvc)GetFactory.GetService("AddressSvcRepoImpl");
            AddressSvc.CreateAddress(Address1);


            List<Address> myList = AddressSvc.RetrieveAllAddresses().ToList<Address>();
            Assert.IsTrue(myList.Count > 0);
        }

    }

    [TestClass]
    public class IPersonSvcTest
    {
        /// <summary>
        /// Create Person using Person Repository Service
        /// </summary>
        [TestMethod]
        public void TestPersonRepoSvcCreate()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;

            Address Address1 = new Address("PersonServiceCityCreate", "PersonServiceStreetCreate", "KS", 55555);
            Person Person1 = new Person((byte)25, "PersonServiceFirstNameCreate_" + personIdVal, "PersonServiceLastNameCreate_" + personIdVal, "PersonServiceUserNameCreate_" + personIdVal, Address1);

            var GetFactory = SvcFactory.GetInstance();
            IPersonSvc PersonSvc = (IPersonSvc)GetFactory.GetService("PersonSvcRepoImpl");
            PersonSvc.CreatePerson(Person1);
        }

        /// <summary>
        /// Remove Person using Person Repository Service
        /// </summary>
        [TestMethod]
        public void TestPersonRepoSvcRemove()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;

            Address Address1 = new Address("PersonServiceCityRemove", "PersonServiceStreetRemove", "KS", 55555);
            Person Person1 = new Person((byte)25, "PersonServiceFirstNameRemove_" + personIdVal, "PersonServiceLastNameRemove_" + personIdVal, "PersonServiceUserNameRemove_" + personIdVal, Address1);
            var GetFactory = SvcFactory.GetInstance();
            IPersonSvc PersonSvc = (IPersonSvc)GetFactory.GetService("PersonSvcRepoImpl");
            PersonSvc.CreatePerson(Person1);

            PersonSvc.RemovePerson(Person1);

        }

        /// <summary>
        /// Modify Person using Person Repository Service
        /// </summary>
        [TestMethod]
        public void TestPersonRepoSvcModify()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;

            Address Address1 = new Address("PersonServiceCityModify", "PersonServiceStreetModify", "KS", 55555);
            Person Person1 = new Person((byte)25, "PersonServiceFirstNameModify_" + personIdVal, "PersonServiceLastNameModify_" + personIdVal, "PersonServiceUserNameModify_" + personIdVal, Address1);

            var GetFactory = SvcFactory.GetInstance();
            IPersonSvc PersonSvc = (IPersonSvc)GetFactory.GetService("PersonSvcRepoImpl");
            PersonSvc.CreatePerson(Person1);

            Person1.FirstName = "PersonServiceFirstNameModify_" + personIdVal + Person1.PersonId;
            Person1.LastName = "PersonServiceLastNameModify_" + personIdVal + Person1.PersonId;
            Person1.UserName = "PersonServiceUserNameModify_" + personIdVal + Person1.PersonId;

            PersonSvc.ModifyPerson(Person1);
        }

        /// <summary>
        /// Retrieve Person using Person Repository Service
        /// </summary>
        [TestMethod]
        public void TestPersonRepoSvcRetrieve()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;

            Address Address1 = new Address("PersonServiceCityRetrieve", "PersonServiceStreetRetrieve", "KS", 55555);
            Person Person1 = new Person((byte)25, "PersonServiceFirstNameRetrieve_" + personIdVal, "PersonServiceLastNameRetrieve_" + personIdVal, "PersonServiceUserNameRetrieve_" + personIdVal, Address1);

            var GetFactory = SvcFactory.GetInstance();
            IPersonSvc PersonSvc = (IPersonSvc)GetFactory.GetService("PersonSvcRepoImpl");
            PersonSvc.CreatePerson(Person1);

            Person Person2 = PersonSvc.RetrievePerson("FirstName", "PersonServiceFirstNameRetrieve_" + personIdVal);

            Assert.IsTrue(Person2.validate());
        }


        /// <summary>
        /// Retrieve All People using Person Repository Service
        /// </summary>
        [TestMethod]
        public void testPersonSvcRepoRetrieveAll()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;

            Address Address1 = new Address("PersonServiceCityRetrieveAll", "PersonServiceStreetRetrieveAll", "KS", 55555);
            Person Person1 = new Person((byte)25, "PersonServiceFirstNameRetrieve_" + personIdVal, "PersonServiceLastNameRetrieve_" + personIdVal, "PersonServiceUserNameRetrieve_" + personIdVal, Address1);

            var PersonRepo = new DataRepository<Person>();
            var GetFactory = SvcFactory.GetInstance();
            IPersonSvc PersonSvc = (IPersonSvc)GetFactory.GetService("PersonSvcRepoImpl");
            PersonSvc.CreatePerson(Person1);


            List<Person> myList = PersonSvc.RetrieveAllPeople().ToList<Person>();
            Assert.IsTrue(myList.Count > 0);
        }
    }

    [TestClass]
    public class ICreditCardSvcTest
    {
        /// <summary>
        /// Create CreditCard using CreditCard Repository Service
        /// </summary>
        [TestMethod]
        public void TestCreditCardRepoSvcCreate()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("CreditCardServiceCityCreate", "CreditCardServiceStreetCreate", "KS", 55555);
            Person Person1 = new Person((byte)25, "CreditCardServiceFirstNameCreate_" + personIdVal, "CreditCardServiceLastNameCreate_" + personIdVal, "CreditCardServiceUserNameCreate_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 5555, 700, 1, (byte)2, (byte)3);

            var GetFactory = SvcFactory.GetInstance();
            ICreditCardSvc CreditCardSvc = (ICreditCardSvc)GetFactory.GetService("CreditCardSvcRepoImpl");
            CreditCardSvc.CreateCreditCard(CreditCard1);
        }

        /// <summary>
        /// Remove CreditCard using CreditCard Repository Service
        /// </summary>
        [TestMethod]
        public void TestCreditCardRepoSvcRemove()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("CreditCardServiceCityRemove", "CreditCardServiceStreetRemove", "KS", 55555);
            Person Person1 = new Person((byte)25, "CreditCardServiceFirstNameRemove_" + personIdVal, "CreditCardServiceLastNameRemove_" + personIdVal, "CreditCardServiceUserNameRemove_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 5555, 700, 1, (byte)2, (byte)3);

            var GetFactory = SvcFactory.GetInstance();
            ICreditCardSvc CreditCardSvc = (ICreditCardSvc)GetFactory.GetService("CreditCardSvcRepoImpl");
            CreditCardSvc.CreateCreditCard(CreditCard1);

            CreditCardSvc.RemoveCreditCard(CreditCard1);

        }

        /// <summary>
        /// Modify CreditCard using CreditCard Repository Service
        /// </summary>
        [TestMethod]
        public void TestCreditCardRepoSvcModify()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("CreditCardServiceCityModify", "CreditCardServiceStreetModify", "KS", 55555);
            Person Person1 = new Person((byte)25, "CreditCardServiceFirstNameModify_" + personIdVal, "CreditCardServiceLastNameModify_" + personIdVal, "CreditCardServiceUserNameModify_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 5555, 700, 1, (byte)2, (byte)3);

            var GetFactory = SvcFactory.GetInstance();
            ICreditCardSvc CreditCardSvc = (ICreditCardSvc)GetFactory.GetService("CreditCardSvcRepoImpl");
            CreditCardSvc.CreateCreditCard(CreditCard1);

            CreditCard1.CreditCardNumber = 999000000000L + CreditCardIdVal;

            CreditCardSvc.ModifyCreditCard(CreditCard1);
        }

        /// <summary>
        /// Retrieve CreditCard using CreditCard Repository Service
        /// </summary>
        [TestMethod]
        public void TestCreditCardRepoSvcRetrieve()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("CreditCardServiceCityRetrieve", "CreditCardServiceStreetRetrieve", "KS", 55555);
            Person Person1 = new Person((byte)25, "CreditCardServiceFirstNameRetrieve_" + personIdVal, "CreditCardServiceLastNameRetrieve_" + personIdVal, "CreditCardServiceUserNameRetrieve_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 5555, 700, 1, (byte)2, (byte)3);

            var GetFactory = SvcFactory.GetInstance();
            ICreditCardSvc CreditCardSvc = (ICreditCardSvc)GetFactory.GetService("CreditCardSvcRepoImpl");
            CreditCardSvc.CreateCreditCard(CreditCard1);

            CreditCard CreditCard2 = CreditCardSvc.RetrieveCreditCard("Limit", (int?)5555);

            Assert.IsTrue(CreditCard2 != null);
        }


        /// <summary>
        /// Retrieve All CreditCards using CreditCard Repository Service
        /// </summary>
        [TestMethod]
        public void testCreditCardSvcRepoRetrieveAll()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("CreditCardServiceCityRetrieveAll", "CreditCardServiceStreetRetrieveAll", "KS", 55555);
            Person Person1 = new Person((byte)25, "CreditCardServiceFirstNameRetrieve_" + personIdVal, "CreditCardServiceLastNameRetrieve_" + personIdVal, "CreditCardServiceUserNameRetrieve_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 5555, 700, 1, (byte)2, (byte)3);

            var CreditCardRepo = new DataRepository<CreditCard>();
            var GetFactory = SvcFactory.GetInstance();
            ICreditCardSvc CreditCardSvc = (ICreditCardSvc)GetFactory.GetService("CreditCardSvcRepoImpl");
            CreditCardSvc.CreateCreditCard(CreditCard1);


            List<CreditCard> myList = CreditCardSvc.RetrieveAllCreditCards().ToList<CreditCard>();
            Assert.IsTrue(myList.Count > 0);
        }
    }

    [TestClass]
    public class IAccountSvcTest
    {
        /// <summary>
        /// Create Account using Account Repository Service
        /// </summary>
        [TestMethod]
        public void TestAccountRepoSvcCreate()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("AccountServiceCityCreate", "AccountServiceStreetCreate", "KS", 55555);
            Person Person1 = new Person((byte)25, "AccountServiceFirstNameCreate_" + personIdVal, "AccountServiceLastNameCreate_" + personIdVal, "AccountServiceUserNameCreate_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 10000, 100, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 1000, 100);

            var GetFactory = SvcFactory.GetInstance();
            IAccountSvc AccountSvc = (IAccountSvc)GetFactory.GetService("AccountSvcRepoImpl");
            AccountSvc.CreateAccount(Account1);
        }

        /// <summary>
        /// Remove Account using Account Repository Service
        /// </summary>
        [TestMethod]
        public void TestAccountRepoSvcRemove()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("AccountServiceCityRemove", "AccountServiceStreetRemove", "KS", 55555);
            Person Person1 = new Person((byte)25, "AccountServiceFirstNameRemove_" + personIdVal, "AccountServiceLastNameRemove_" + personIdVal, "AccountServiceUserNameRemove_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 20000, 200, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 2000, 200);

            var GetFactory = SvcFactory.GetInstance();
            IAccountSvc AccountSvc = (IAccountSvc)GetFactory.GetService("AccountSvcRepoImpl");
            AccountSvc.CreateAccount(Account1);

            AccountSvc.RemoveAccount(Account1);

        }

        /// <summary>
        /// Modify Account using Account Repository Service
        /// </summary>
        [TestMethod]
        public void TestAccountRepoSvcModify()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("AccountServiceCityModify", "AccountServiceStreetModify", "KS", 55555);
            Person Person1 = new Person((byte)25, "AccountServiceFirstNameModify_" + personIdVal, "AccountServiceLastNameModify_" + personIdVal, "AccountServiceUserNameModify_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 30000, 300, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 3000, 300);

            var GetFactory = SvcFactory.GetInstance();
            IAccountSvc AccountSvc = (IAccountSvc)GetFactory.GetService("AccountSvcRepoImpl");
            AccountSvc.CreateAccount(Account1);

            Account1.Limit = 10 + Account1.AccountId;

            AccountSvc.ModifyAccount(Account1);
        }

        /// <summary>
        /// Retrieve Account using Account Repository Service
        /// </summary>
        [TestMethod]
        public void TestAccountRepoSvcRetrieve()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("AccountServiceCityRetrieve", "AccountServiceStreetRetrieve", "KS", 55555);
            Person Person1 = new Person((byte)25, "AccountServiceFirstNameRetrieve_" + personIdVal, "AccountServiceLastNameRetrieve_" + personIdVal, "AccountServiceUserNameRetrieve_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 5555, 700, 1, (byte)2, (byte)3);
            Account Account1 = new Account(CreditCard1, Person1, 4000, 400);

            var GetFactory = SvcFactory.GetInstance();
            IAccountSvc AccountSvc = (IAccountSvc)GetFactory.GetService("AccountSvcRepoImpl");
            AccountSvc.CreateAccount(Account1);

            Account Account2 = AccountSvc.RetrieveAccount("Limit", 4000);

            Assert.IsTrue(Account2 != null);
        }


        /// <summary>
        /// Retrieve All Accounts using Account Repository Service
        /// </summary>
        [TestMethod]
        public void testAccountSvcRepoRetrieveAll()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("AccountServiceCityRetrieveAll", "AccountServiceStreetRetrieveAll", "KS", 55555);
            Person Person1 = new Person((byte)25, "AccountServiceFirstNameRetrieve_" + personIdVal, "AccountServiceLastNameRetrieve_" + personIdVal, "AccountServiceUserNameRetrieve_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 55555, 500, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 5000, 500);

            var AccountRepo = new DataRepository<Account>();
            var GetFactory = SvcFactory.GetInstance();
            IAccountSvc AccountSvc = (IAccountSvc)GetFactory.GetService("AccountSvcRepoImpl");
            AccountSvc.CreateAccount(Account1);


            List<Account> myList = AccountSvc.RetrieveAllAccounts().ToList<Account>();
            Assert.IsTrue(myList.Count > 0);
        }
    }

    [TestClass]
    public class ITransactionSvcTest
    {
        /// <summary>
        /// Create Transaction using Transaction Repository Service
        /// </summary>
        [TestMethod]
        public void TestTransactionRepoSvcCreate()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("TrxSvcCityCreate", "TrxSvcStreetCreate", "KS", 55555);
            Person Person1 = new Person((byte)25, "TrxSvcFirstNameCreate_" + personIdVal, "TrxSvcLastNameCreate_" + personIdVal, "TrxSvcUserNameCreate_" + personIdVal, Address1);
            Account Account1 = new Account(Person1, 1000, 100);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 10000, 100, 1, (byte)2, (byte)3, Person1, Account1);
            
            Transaction Transaction1 = new Transaction(100, 1, 1, 11, "TrxSvcBusinessCreate", CreditCard1);

            var GetFactory = SvcFactory.GetInstance();
            ITransactionSvc TransactionSvc = (ITransactionSvc)GetFactory.GetService("TransactionSvcRepoImpl");
            TransactionSvc.CreateTransaction(Transaction1);
        }

        /// <summary>
        /// Remove Transaction using Transaction Repository Service
        /// </summary>
        [TestMethod]
        public void TestTransactionRepoSvcRemove()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("TrxSvcCityRemove", "TrxSvcStreetRemove", "KS", 55555);
            Person Person1 = new Person((byte)25, "TrxSvcFirstNameRemove_" + personIdVal, "TrxSvcLastNameRemove_" + personIdVal, "TrxSvcUserNameRemove_" + personIdVal, Address1);
            Account Account1 = new Account(Person1, 2000, 200);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 20000, 200, 1, (byte)2, (byte)3, Person1, Account1);

            Transaction Transaction1 = new Transaction(200, 2, 2, 22, "TrServiceBusinessRemove", CreditCard1);

            var GetFactory = SvcFactory.GetInstance();
            ITransactionSvc TransactionSvc = (ITransactionSvc)GetFactory.GetService("TransactionSvcRepoImpl");
            TransactionSvc.CreateTransaction(Transaction1);

            TransactionSvc.RemoveTransaction(Transaction1);

        }

        /// <summary>
        /// Modify Transaction using Transaction Repository Service
        /// </summary>
        [TestMethod]
        public void TestTransactionRepoSvcModify()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("TrxSvcCityModify", "TrxSvcStreetModify", "KS", 55555);
            Person Person1 = new Person((byte)25, "TrxSvcFirstNameModify_" + personIdVal, "TrxSvcLastNameModify_" + personIdVal, "TrxSvcUserNameModify_" + personIdVal, Address1);
            Account Account1 = new Account(Person1, 3000, 300);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 30000, 300, 1, (byte)2, (byte)3, Person1, Account1);
            Transaction Transaction1 = new Transaction(300, 3, 3, 33, "TrxSvcBusinessModify", CreditCard1);

            var GetFactory = SvcFactory.GetInstance();
            ITransactionSvc TransactionSvc = (ITransactionSvc)GetFactory.GetService("TransactionSvcRepoImpl");
            TransactionSvc.CreateTransaction(Transaction1);

            Transaction1.Amount = 999;

            TransactionSvc.ModifyTransaction(Transaction1);
        }

        /// <summary>
        /// Retrieve Transaction using Transaction Repository Service
        /// </summary>
        [TestMethod]
        public void TestTransactionRepoSvcRetrieve()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("TrxSvcCityRetrieve", "TrxSvcStreetRetrieve", "KS", 55555);
            Person Person1 = new Person((byte)25, "TrxSvcFirstNameRetrieve_" + personIdVal, "TrxSvcLastNameRetrieve_" + personIdVal, "TrxSvcUserNameRetrieve_" + personIdVal, Address1);
            Account Account1 = new Account(Person1, 4000, 400);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 444444, (decimal)400.44, 1, (byte)2, (byte)3, Person1, Account1);
            Transaction Transaction1 = new Transaction(400, 4, 4, 44, "TrxSvcBusinessRetrieve", CreditCard1);

            var GetFactory = SvcFactory.GetInstance();
            ITransactionSvc TransactionSvc = (ITransactionSvc)GetFactory.GetService("TransactionSvcRepoImpl");
            TransactionSvc.CreateTransaction(Transaction1);

            Transaction Transaction2 = TransactionSvc.RetrieveTransaction("BusinessName", "TrxSvcBusinessRetrieve");

            Assert.IsTrue(Transaction2.validate());
        }


        /// <summary>
        /// Retrieve All Transactions using Transaction Repository Service
        /// </summary>
        [TestMethod]
        public void testTransactionSvcRepoRetrieveAll()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("TrxSvcCityRetrieveAll", "TrxSvcStreetRetrieveAll", "KS", 55555);
            Person Person1 = new Person((byte)25, "TrxSvcFirstNameRetrieve_" + personIdVal, "TrxSvcLastNameRetrieve_" + personIdVal, "TrxSvcUserNameRetrieve_" + personIdVal, Address1);
            Account Account1 = new Account(Person1, 5000, 500);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 55555, 500, 1, (byte)2, (byte)3, Person1, Account1);
            Transaction Transaction1 = new Transaction(500, 5, 5, 55, "TrxSvcBusinessRetrieveAll", CreditCard1);

            var TransactionRepo = new DataRepository<Transaction>();
            var GetFactory = SvcFactory.GetInstance();
            ITransactionSvc TransactionSvc = (ITransactionSvc)GetFactory.GetService("TransactionSvcRepoImpl");
            TransactionSvc.CreateTransaction(Transaction1);


            List<Transaction> myList = TransactionSvc.RetrieveAllTransactions().ToList<Transaction>();
            Assert.IsTrue(myList.Count > 0);
        }
    }

}

    