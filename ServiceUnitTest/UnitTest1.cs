using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using MSSE680.DAL;
using MSSE680.Service;

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

            var GetFactory = new SvcFactory();
            IAddressSvc AddressSvc = (IAddressSvc)GetFactory.getService("AddressSvcRepoImpl");
            AddressSvc.CreateAddress(Address1);
        }

        /// <summary>
        /// Remove Address using Address Repository Service
        /// </summary>
        [TestMethod]
        public void TestAddressRepoSvcRemove()
        {
            Address Address1 = new Address("ServiceCityRemove", "ServiceStreetRemove", "KS", 55555);

            var GetFactory = new SvcFactory();
            IAddressSvc AddressSvc = (IAddressSvc)GetFactory.getService("AddressSvcRepoImpl");
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

            var GetFactory = new SvcFactory();
            IAddressSvc AddressSvc = (IAddressSvc)GetFactory.getService("AddressSvcRepoImpl");
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

            var GetFactory = new SvcFactory();
            IAddressSvc AddressSvc = (IAddressSvc)GetFactory.getService("AddressSvcRepoImpl");
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
            var GetFactory = new SvcFactory();
            IAddressSvc AddressSvc = (IAddressSvc)GetFactory.getService("AddressSvcRepoImpl");
            AddressSvc.CreateAddress(Address1);


            List<Address> myList = AddressSvc.RetrieveAllAddresses().ToList<Address>();
            Assert.IsTrue(myList.Count > 0);
        }

        /*   [TestMethod]
           public void TestSvcAddPersonToAddress()
           {
               System.Diagnostics.Debug.WriteLine("\n\nTest this :-)\n\n");
               Address Address1 = new Address("ServiceCityPersonAddress", "ServiceStreetPersonAddress", "KS", 55555);
               Person Person1 = new Person((byte)30, "ServiceFirstNamePersonAddress", "SreviceLastPresonAddress", "ServiceUserNamePersonAddress", "ServicePasswordPersonAddress", (byte)1);
           

           

               var GetFactory = new SvcFactory();
               IAddressSvc AddressSvc = (IAddressSvc)GetFactory.getService("AddressSvcRepoImpl");
               IPersonSvc PersonSvc = (IPersonSvc)GetFactory.getService("PersonSvcRepoImpl");
               /*
               AddressSvc.CreateAddress(Address1);
               PersonSvc.CreatePerson(Person1);

               Address Address2 = AddressSvc.RetrieveAddress("City", "ServiceCityPersonAddress");
               Person Person2 = PersonSvc.RetrievePerson("FirstName", "ServiceFirstNamePersonAddress");
            
               //AddressSvc.AddPersonToAddress(Person2, Address2);
               PersonSvc.AddAddressToPerson(Address2, Person2);


               //testing
               Address Address3 = new Address("ServiceCityPersonAddress", "ServiceStreetPersonAddress", "KS", 55555);
               Person Person4 = new Person((byte)30, "ServiceFirstNamePersonAddress", "SreviceLastPresonAddress", "ServiceUserNamePersonAddress", "ServicePasswordPersonAddress", (byte)1);
               CreditCard CreditCard1 = new CreditCard(1111111111L, 1, 1, 1, (byte)2, (byte)3, Person4);
               CreditCard CreditCard2 = new CreditCard(2222222222L, 2, 2, 2, (byte)2, (byte)3, Person4);
               CreditCard CreditCard3 = new CreditCard(3333333333L, 3, 3, 3, (byte)2, (byte)3, Person4);
               CreditCard CreditCard4 = new CreditCard(4444444444L, 4, 4, 4, (byte)2, (byte)3, Person4);
               Account Account1 = new Account(CreditCard1, Person1, 2000, 200);
            
               Account1.CreditCard = CreditCard1;
               Account1.CreditCards = new List<CreditCard>();
               Account1.CreditCards.Add(CreditCard2);
               Account1.CreditCards.Add(CreditCard3);
               Account1.CreditCards.Add(CreditCard4);

           
               IAccountSvc AccountSvc = (IAccountSvc)GetFactory.getService("AccountSvcRepoImpl");
               AccountSvc.CreateAccount(Account1);

               // ModifyAddress(Address);
            
           }
       */
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
            Address Address1 = new Address("PersonServiceCityCreate", "PersonServiceStreetCreate", "KS", 55555);
            Person Person1 = new Person((byte)25, "PersonServiceFirstNameCreate", "PersonServiceLastNameCreate", "PersonServiceUserNameCreate", Address1);

            var GetFactory = new SvcFactory();
            IPersonSvc PersonSvc = (IPersonSvc)GetFactory.getService("PersonSvcRepoImpl");
            PersonSvc.CreatePerson(Person1);
        }

        /// <summary>
        /// Remove Person using Person Repository Service
        /// </summary>
        [TestMethod]
        public void TestPersonRepoSvcRemove()
        {
            Address Address1 = new Address("PersonServiceCityRemove", "PersonServiceStreetRemove", "KS", 55555);
            Person Person1 = new Person((byte)25, "PersonServiceFirstNameRemove", "PersonServiceLastNameRemove", "PersonServiceUserNameRemove", Address1);
            var GetFactory = new SvcFactory();
            IPersonSvc PersonSvc = (IPersonSvc)GetFactory.getService("PersonSvcRepoImpl");
            PersonSvc.CreatePerson(Person1);

            PersonSvc.RemovePerson(Person1);

        }

        /// <summary>
        /// Modify Person using Person Repository Service
        /// </summary>
        [TestMethod]
        public void TestPersonRepoSvcModify()
        {
            Address Address1 = new Address("PersonServiceCityModify", "PersonServiceStreetModify", "KS", 55555);
            Person Person1 = new Person((byte)25, "PersonServiceFirstNameModify", "PersonServiceLastNameModify", "PersonServiceUserNameModify", Address1);

            var GetFactory = new SvcFactory();
            IPersonSvc PersonSvc = (IPersonSvc)GetFactory.getService("PersonSvcRepoImpl");
            PersonSvc.CreatePerson(Person1);

            Person1.FirstName = "PersonServiceFirstNameModify" + Person1.PersonId;
            Person1.LastName = "PersonServiceLastNameModify" + Person1.PersonId;
            Person1.UserName = "PersonServiceUserNameModify" + Person1.PersonId;

            PersonSvc.ModifyPerson(Person1);
        }

        /// <summary>
        /// Retrieve Person using Person Repository Service
        /// </summary>
        [TestMethod]
        public void TestPersonRepoSvcRetrieve()
        {
            Address Address1 = new Address("PersonServiceCityRetrieve", "PersonServiceStreetRetrieve", "KS", 55555);
            Person Person1 = new Person((byte)25, "PersonServiceFirstNameRetrieve", "PersonServiceLastNameRetrieve", "PersonServiceUserNameRetrieve", Address1);

            var GetFactory = new SvcFactory();
            IPersonSvc PersonSvc = (IPersonSvc)GetFactory.getService("PersonSvcRepoImpl");
            PersonSvc.CreatePerson(Person1);

            Person Person2 = PersonSvc.RetrievePerson("FirstName", "PersonServiceFirstNameRetrieve");

            Assert.IsTrue(Person2.validate());
        }


        /// <summary>
        /// Retrieve All People using Person Repository Service
        /// </summary>
        [TestMethod]
        public void testPersonSvcRepoRetrieveAll()
        {
            Address Address1 = new Address("PersonServiceCityRetrieveAll", "PersonServiceStreetRetrieveAll", "KS", 55555);
            Person Person1 = new Person((byte)25, "PersonServiceFirstNameRetrieveAll", "PersonServiceLastNameRetrieveAll", "PersonServiceUserNameRetrieveAll", Address1);

            var PersonRepo = new DataRepository<Person>();
            var GetFactory = new SvcFactory();
            IPersonSvc PersonSvc = (IPersonSvc)GetFactory.getService("PersonSvcRepoImpl");
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
            Address Address1 = new Address("CreditCardServiceCityCreate", "CreditCardServiceStreetCreate", "KS", 55555);
            Person Person1 = new Person((byte)25, "CreditCardServiceFirstNameCreate", "CreditCardServiceLastNameCreate", "CreditCardServiceUserNameCreate", Address1);
            CreditCard CreditCard1 = new CreditCard(711111111L, 7100, 710, 1, (byte)1, (byte)1, Person1);

            var GetFactory = new SvcFactory();
            ICreditCardSvc CreditCardSvc = (ICreditCardSvc)GetFactory.getService("CreditCardSvcRepoImpl");
            CreditCardSvc.CreateCreditCard(CreditCard1);
        }

        /// <summary>
        /// Remove CreditCard using CreditCard Repository Service
        /// </summary>
        [TestMethod]
        public void TestCreditCardRepoSvcRemove()
        {
            Address Address1 = new Address("CreditCardServiceCityRemove", "CreditCardServiceStreetRemove", "KS", 55555);
            Person Person1 = new Person((byte)25, "CreditCardServiceFirstNameRemove", "CreditCardServiceLastNameRemove", "CreditCardServiceUserNameRemove", Address1);
            CreditCard CreditCard1 = new CreditCard(7222222222L, 7200, 720, 2, (byte)2, (byte)2, Person1);

            var GetFactory = new SvcFactory();
            ICreditCardSvc CreditCardSvc = (ICreditCardSvc)GetFactory.getService("CreditCardSvcRepoImpl");
            CreditCardSvc.CreateCreditCard(CreditCard1);

            CreditCardSvc.RemoveCreditCard(CreditCard1);

        }

        /// <summary>
        /// Modify CreditCard using CreditCard Repository Service
        /// </summary>
        [TestMethod]
        public void TestCreditCardRepoSvcModify()
        {
            Address Address1 = new Address("CreditCardServiceCityModify", "CreditCardServiceStreetModify", "KS", 55555);
            Person Person1 = new Person((byte)25, "CreditCardServiceFirstNameModify", "CreditCardServiceLastNameModify", "CreditCardServiceUserNameModify", Address1);
            CreditCard CreditCard1 = new CreditCard(7333333333L, 7300, 730, 3, (byte)3, (byte)3, Person1);

            var GetFactory = new SvcFactory();
            ICreditCardSvc CreditCardSvc = (ICreditCardSvc)GetFactory.getService("CreditCardSvcRepoImpl");
            CreditCardSvc.CreateCreditCard(CreditCard1);

            CreditCard1.CreditCardNumber = 888999000L + CreditCard1.CreditCardId;

            CreditCardSvc.ModifyCreditCard(CreditCard1);
        }

        /// <summary>
        /// Retrieve CreditCard using CreditCard Repository Service
        /// </summary>
        [TestMethod]
        public void TestCreditCardRepoSvcRetrieve()
        {
            Address Address1 = new Address("CreditCardServiceCityRetrieve", "CreditCardServiceStreetRetrieve", "KS", 55555);
            Person Person1 = new Person((byte)25, "CreditCardServiceFirstNameRetrieve", "CreditCardServiceLastNameRetrieve", "CreditCardServiceUserNameRetrieve", Address1);
            CreditCard CreditCard1 = new CreditCard(7444444444L, 7400, 740, 4, (byte)4, (byte)4, Person1);

            var GetFactory = new SvcFactory();
            ICreditCardSvc CreditCardSvc = (ICreditCardSvc)GetFactory.getService("CreditCardSvcRepoImpl");
            CreditCardSvc.CreateCreditCard(CreditCard1);

            CreditCard CreditCard2 = CreditCardSvc.RetrieveCreditCard("Limit", 7400);

            Assert.IsTrue(CreditCard2.validate());
        }


        /// <summary>
        /// Retrieve All CreditCards using CreditCard Repository Service
        /// </summary>
        [TestMethod]
        public void testCreditCardSvcRepoRetrieveAll()
        {
            Address Address1 = new Address("CreditCardServiceCityRetrieveAll", "CreditCardServiceStreetRetrieveAll", "KS", 55555);
            Person Person1 = new Person((byte)25, "CreditCardServiceFirstNameRetrieveAll", "CreditCardServiceLastNameRetrieveAll", "CreditCardServiceUserNameRetrieveAll", Address1);
            CreditCard CreditCard1 = new CreditCard(7444444444L, 7400, 740, 4, (byte)4, (byte)4, Person1);

            var CreditCardRepo = new DataRepository<CreditCard>();
            var GetFactory = new SvcFactory();
            ICreditCardSvc CreditCardSvc = (ICreditCardSvc)GetFactory.getService("CreditCardSvcRepoImpl");
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
            Address Address1 = new Address("AccountServiceCityCreate", "AccountServiceStreetCreate", "KS", 55555);
            Person Person1 = new Person((byte)25, "AccountServiceFirstNameCreate", "AccountServiceLastNameCreate", "AccountServiceUserNameCreate", Address1);
            CreditCard CreditCard1 = new CreditCard(11111111L, 10000, 100, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 1000, 100);

            var GetFactory = new SvcFactory();
            IAccountSvc AccountSvc = (IAccountSvc)GetFactory.getService("AccountSvcRepoImpl");
            AccountSvc.CreateAccount(Account1);
        }

        /// <summary>
        /// Remove Account using Account Repository Service
        /// </summary>
        [TestMethod]
        public void TestAccountRepoSvcRemove()
        {
            Address Address1 = new Address("AccountServiceCityRemove", "AccountServiceStreetRemove", "KS", 55555);
            Person Person1 = new Person((byte)25, "AccountServiceFirstNameRemove", "AccountServiceLastNameRemove", "AccountServiceUserNameRemove", Address1);
            CreditCard CreditCard1 = new CreditCard(222222222L, 20000, 200, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 2000, 200);

            var GetFactory = new SvcFactory();
            IAccountSvc AccountSvc = (IAccountSvc)GetFactory.getService("AccountSvcRepoImpl");
            AccountSvc.CreateAccount(Account1);

            AccountSvc.RemoveAccount(Account1);

        }

        /// <summary>
        /// Modify Account using Account Repository Service
        /// </summary>
        [TestMethod]
        public void TestAccountRepoSvcModify()
        {
            Address Address1 = new Address("AccountServiceCityModify", "AccountServiceStreetModify", "KS", 55555);
            Person Person1 = new Person((byte)25, "AccountServiceFirstNameModify", "AccountServiceLastNameModify", "AccountServiceUserNameModify", Address1);
            CreditCard CreditCard1 = new CreditCard(333333333L, 30000, 300, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 3000, 300);

            var GetFactory = new SvcFactory();
            IAccountSvc AccountSvc = (IAccountSvc)GetFactory.getService("AccountSvcRepoImpl");
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
            Address Address1 = new Address("AccountServiceCityRetrieve", "AccountServiceStreetRetrieve", "KS", 55555);
            Person Person1 = new Person((byte)25, "AccountServiceFirstNameRetrieve", "AccountServiceLastNameRetrieve", "AccountServiceUserNameRetrieve", Address1);
            CreditCard CreditCard1 = new CreditCard(444444444L, 444444, 400.44, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 4000, 400);

            var GetFactory = new SvcFactory();
            IAccountSvc AccountSvc = (IAccountSvc)GetFactory.getService("AccountSvcRepoImpl");
            AccountSvc.CreateAccount(Account1);

            Account Account2 = AccountSvc.RetrieveAccount("Limit", 4000);

            Assert.IsTrue(Account2.validate());
        }


        /// <summary>
        /// Retrieve All Accounts using Account Repository Service
        /// </summary>
        [TestMethod]
        public void testAccountSvcRepoRetrieveAll()
        {
            Address Address1 = new Address("AccountServiceCityRetrieveAll", "AccountServiceStreetRetrieveAll", "KS", 55555);
            Person Person1 = new Person((byte)25, "AccountServiceFirstNameRetrieveAll", "AccountServiceLastNameRetrieveAll", "AccountServiceUserNameRetrieveAll", Address1);
            CreditCard CreditCard1 = new CreditCard(555555555L, 55555, 500, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 5000, 500);

            var AccountRepo = new DataRepository<Account>();
            var GetFactory = new SvcFactory();
            IAccountSvc AccountSvc = (IAccountSvc)GetFactory.getService("AccountSvcRepoImpl");
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
            Address Address1 = new Address("TransactionServiceCityCreate", "TransactionServiceStreetCreate", "KS", 55555);
            Person Person1 = new Person((byte)25, "TransactionServiceFirstNameCreate", "TransactionServiceLastNameCreate", "TransactionServiceUserNameCreate", Address1);
            Account Account1 = new Account(Person1, 1000, 100);
            CreditCard CreditCard1 = new CreditCard(11111111L, 10000, 100, 1, (byte)2, (byte)3, Person1,Account1);
            
            Transaction Transaction1 = new Transaction(100, 1, 1, 11, "TransactionServiceBusinessCreate", CreditCard1);

            var GetFactory = new SvcFactory();
            ITransactionSvc TransactionSvc = (ITransactionSvc)GetFactory.getService("TransactionSvcRepoImpl");
            TransactionSvc.CreateTransaction(Transaction1);
        }

        /// <summary>
        /// Remove Transaction using Transaction Repository Service
        /// </summary>
        [TestMethod]
        public void TestTransactionRepoSvcRemove()
        {
            Address Address1 = new Address("TransactionServiceCityRemove", "TransactionServiceStreetRemove", "KS", 55555);
            Person Person1 = new Person((byte)25, "TransactionServiceFirstNameRemove", "TransactionServiceLastNameRemove", "TransactionServiceUserNameRemove", Address1);
            Account Account1 = new Account(Person1, 2000, 200);
            CreditCard CreditCard1 = new CreditCard(222222222L, 20000, 200, 1, (byte)2, (byte)3, Person1, Account1);

            Transaction Transaction1 = new Transaction(200, 2, 2, 22, "TransactionServiceBusinessRemove", CreditCard1);

            var GetFactory = new SvcFactory();
            ITransactionSvc TransactionSvc = (ITransactionSvc)GetFactory.getService("TransactionSvcRepoImpl");
            TransactionSvc.CreateTransaction(Transaction1);

            TransactionSvc.RemoveTransaction(Transaction1);

        }

        /// <summary>
        /// Modify Transaction using Transaction Repository Service
        /// </summary>
        [TestMethod]
        public void TestTransactionRepoSvcModify()
        {
            Address Address1 = new Address("TransactionServiceCityModify", "TransactionServiceStreetModify", "KS", 55555);
            Person Person1 = new Person((byte)25, "TransactionServiceFirstNameModify", "TransactionServiceLastNameModify", "TransactionServiceUserNameModify", Address1);
            Account Account1 = new Account(Person1, 3000, 300);
            CreditCard CreditCard1 = new CreditCard(333333333L, 30000, 300, 1, (byte)2, (byte)3, Person1, Account1);
            Transaction Transaction1 = new Transaction(300, 3, 3, 33, "TransactionServiceBusinessModify", CreditCard1);

            var GetFactory = new SvcFactory();
            ITransactionSvc TransactionSvc = (ITransactionSvc)GetFactory.getService("TransactionSvcRepoImpl");
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
            Address Address1 = new Address("TransactionServiceCityRetrieve", "TransactionServiceStreetRetrieve", "KS", 55555);
            Person Person1 = new Person((byte)25, "TransactionServiceFirstNameRetrieve", "TransactionServiceLastNameRetrieve", "TransactionServiceUserNameRetrieve", Address1);
            Account Account1 = new Account(Person1, 4000, 400);
            CreditCard CreditCard1 = new CreditCard(444444444L, 444444, 400.44, 1, (byte)2, (byte)3, Person1, Account1);
            Transaction Transaction1 = new Transaction(400, 4, 4, 44, "TransactionServiceBusinessRetrieve", CreditCard1);

            var GetFactory = new SvcFactory();
            ITransactionSvc TransactionSvc = (ITransactionSvc)GetFactory.getService("TransactionSvcRepoImpl");
            TransactionSvc.CreateTransaction(Transaction1);

            Transaction Transaction2 = TransactionSvc.RetrieveTransaction("BusinessName", "TransactionServiceBusinessRetrieve");

            Assert.IsTrue(Transaction2.validate());
        }


        /// <summary>
        /// Retrieve All Transactions using Transaction Repository Service
        /// </summary>
        [TestMethod]
        public void testTransactionSvcRepoRetrieveAll()
        {
            Address Address1 = new Address("TransactionServiceCityRetrieveAll", "TransactionServiceStreetRetrieveAll", "KS", 55555);
            Person Person1 = new Person((byte)25, "TransactionServiceFirstNameRetrieveAll", "TransactionServiceLastNameRetrieveAll", "TransactionServiceUserNameRetrieveAll", Address1);
            Account Account1 = new Account(Person1, 5000, 500);
            CreditCard CreditCard1 = new CreditCard(555555555L, 55555, 500, 1, (byte)2, (byte)3, Person1, Account1);
            Transaction Transaction1 = new Transaction(500, 5, 5, 55, "TransactionServiceBusinessRetrieveAll", CreditCard1);

            var TransactionRepo = new DataRepository<Transaction>();
            var GetFactory = new SvcFactory();
            ITransactionSvc TransactionSvc = (ITransactionSvc)GetFactory.getService("TransactionSvcRepoImpl");
            TransactionSvc.CreateTransaction(Transaction1);


            List<Transaction> myList = TransactionSvc.RetrieveAllTransactions().ToList<Transaction>();
            Assert.IsTrue(myList.Count > 0);
        }
    }

}
/*
 *     [TestClass]
    public class SvcTest
    {
        [TestMethod]
        public void TestRepoSvcCreateAccount()
        {
            Address Address1 = new Address(2, "Service3", "5856 Shocker Drive", "KS", 67219);
            Person Person1 = new Person(25, (byte)30, "Service", "Buller", "mbuller", "Password1", (byte)1, Address1);
            CreditCard CreditCard1 = new CreditCard(15, 123456789L, 10000, 700, 1, (byte)2, (byte)3, Person1);

            Account Account1 = new Account(3, CreditCard1, Person1, 2000, 200);

            var thisServ = new SvcFactory();
            IAccountSvc testingThis = (IAccountSvc)thisServ.getService("AccountSvcRepoImpl");
            testingThis.CreateAccount(Account1);
        }       
           
    }
    

 * 
 * 
 * void CreateAddress(Address Address);
        void RemoveAddress(Address Address);
        void ModifyAddress(Address Address);
    //    Address RetrieveAddress();

        void AddPersonToAddress(Person Person, Address Address);
        void RemovePersonFromAddress(Person Person, Address Address);*/