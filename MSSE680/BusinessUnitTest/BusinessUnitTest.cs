using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Service;
using Business;

namespace BusinessUnitTest
{

    [TestClass]
    public class AdressMgrTest
    {
        /// <summary>
        /// Create Address using Address Mgr
        /// </summary>
        [TestMethod]
        public void TestAddressMgrCreate()
        {
            Address Address1 = new Address("MgrCityCreate", "MgrStreetCreate", "KS", 55555);

            new AddressMgr().CreateAddress(Address1);
        }

        /// <summary>
        /// Remove Address using Address Mgr
        /// </summary>
        [TestMethod]
        public void TestAddressMgrRemove()
        {
            Address Address1 = new Address("ServiceCityRemove", "ServiceStreetRemove", "KS", 55555);

            new AddressMgr().CreateAddress(Address1);

            new AddressMgr().RemoveAddress(Address1);

        }

        /// <summary>
        /// Modify Address using Address Mgr
        /// </summary>
        [TestMethod]
        public void TestAddressMgrModify()
        {
            Address Address1 = new Address("MgrCityModify", "MgrStreetModify", "KS", 55555);

            new AddressMgr().CreateAddress(Address1);

            Address1.City = "MgrCityModify" + Address1.AddressId;
            Address1.Street = "MgrSteetModify" + Address1.AddressId;
            
             new AddressMgr().ModifyAddress(Address1);
        }

        /// <summary>
        /// Retrieve Address using Address Mgr
        /// </summary>
        [TestMethod]
        public void TestAddressMgrRetrieve()
        {
            Address Address1 = new Address("MgrCityRetrieve", "MgrStreetRetrieve", "KS", 55555);

             new AddressMgr().CreateAddress(Address1);
           
            Address Address2 = new AddressMgr().RetrieveAddress("City", "MgrCityRetrieve");

           Assert.IsTrue(Address2.validate());
        }


        /// <summary>
        /// Retrieve All Addresses using Address Mgr
        /// </summary>
        [TestMethod]
        public void testAddressMgrRetrieveAll()
        {
            Address Address1 = new Address("MgrCityRetrieveAll", "MgrStreetRetrieveAll", "KS", 55555);

            new AddressMgr().CreateAddress(Address1);


            List<Address> myList = new AddressMgr().RetrieveAllAddresses().ToList<Address>();
            Assert.IsTrue(myList.Count > 0);
        }

    }

    [TestClass]
    public class PersonMgrTest
    {
        /// <summary>
        /// Create Person using Person Mgr
        /// </summary>
        [TestMethod]
        public void TestPersonMgrCreate()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;

            Address Address1 = new Address("PersonServiceCityCreate", "PersonServiceStreetCreate", "KS", 55555);
            Person Person1 = new Person((byte)25, "PersonServiceFirstNameCreate_" + personIdVal, "PersonServiceLastNameCreate_" + personIdVal, "PersonServiceUserNameCreate_" + personIdVal, Address1);

            new PersonMgr().CreatePerson(Person1);
        }

        /// <summary>
        /// Remove Person using Person Mgr
        /// </summary>
        [TestMethod]
        public void TestPersonMgrRemove()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;

            Address Address1 = new Address("PersonServiceCityRemove", "PersonServiceStreetRemove", "KS", 55555);
            Person Person1 = new Person((byte)25, "PersonServiceFirstNameRemove_" + personIdVal, "PersonServiceLastNameRemove_" + personIdVal, "PersonServiceUserNameRemove_" + personIdVal, Address1);
            new PersonMgr().CreatePerson(Person1);

            new PersonMgr().RemovePerson(Person1);

        }

        /// <summary>
        /// Modify Person using Person Mgr
        /// </summary>
        [TestMethod]
        public void TestPersonMgrModify()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;

            Address Address1 = new Address("PersonServiceCityModify", "PersonServiceStreetModify", "KS", 55555);
            Person Person1 = new Person((byte)25, "PersonServiceFirstNameModify_" + personIdVal, "PersonServiceLastNameModify_" + personIdVal, "PersonServiceUserNameModify_" + personIdVal, Address1);

            new PersonMgr().CreatePerson(Person1);

            Person1.FirstName = "PersonServiceFirstNameModify_" + personIdVal + Person1.PersonId;
            Person1.LastName = "PersonServiceLastNameModify_" + personIdVal + Person1.PersonId;
            Person1.UserName = "PersonServiceUserNameModify_" + personIdVal + Person1.PersonId;

            new PersonMgr().ModifyPerson(Person1);
        }

        /// <summary>
        /// Retrieve Person using Person Mgr
        /// </summary>
        [TestMethod]
        public void TestPersonMgrRetrieve()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;

            Address Address1 = new Address("PersonServiceCityRetrieve", "PersonServiceStreetRetrieve", "KS", 55555);
            Person Person1 = new Person((byte)25, "PersonServiceFirstNameRetrieve_" + personIdVal, "PersonServiceLastNameRetrieve_" + personIdVal, "PersonServiceUserNameRetrieve_" + personIdVal, Address1);

            new PersonMgr().CreatePerson(Person1);

            Person Person2 = new PersonMgr().RetrievePerson("FirstName", "PersonServiceFirstNameRetrieve_" + personIdVal);

            Assert.IsTrue(Person2.validate());
        }


        /// <summary>
        /// Retrieve All People using Person Mgr
        /// </summary>
        [TestMethod]
        public void testPersonMgrRetrieveAll()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;

            Address Address1 = new Address("PersonServiceCityRetrieveAll", "PersonServiceStreetRetrieveAll", "KS", 55555);
            Person Person1 = new Person((byte)25, "PersonServiceFirstNameRetrieveAll_" + personIdVal, "PersonServiceLastNameRetrieveAll_" + personIdVal, "PersonServiceUserNameRetrieveAll_" + personIdVal, Address1);

            new PersonMgr().CreatePerson(Person1);


            List<Person> myList = new PersonMgr().RetrieveAllPeople().ToList<Person>();
            Assert.IsTrue(myList.Count > 0);
        }
    }

    [TestClass]
    public class CreditCardMgrTest
    {
        /// <summary>
        /// Create CreditCard using CreditCard Mgr
        /// </summary>
        [TestMethod]
        public void TestCreditCardMgrCreate()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("CreditCardServiceCityCreate", "CreditCardServiceStreetCreate", "KS", 55555);
            Person Person1 = new Person((byte)25, "CreditCardServiceFirstNameCreate_" + personIdVal, "CreditCardServiceLastNameCreate_" + personIdVal, "CreditCardServiceUserNameCreate_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 5555, 700, 1, (byte)2, (byte)3);

            new CreditCardMgr().CreateCreditCard(CreditCard1);
        }

        /// <summary>
        /// Remove CreditCard using CreditCard Mgr
        /// </summary>
        [TestMethod]
        public void TestCreditCardMgrRemove()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("CreditCardServiceCityRemove", "CreditCardServiceStreetRemove", "KS", 55555);
            Person Person1 = new Person((byte)25, "CreditCardServiceFirstNameRemove_" + personIdVal, "CreditCardServiceLastNameRemove_" + personIdVal, "CreditCardServiceUserNameRemove_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 5555, 700, 1, (byte)2, (byte)3);

            new CreditCardMgr().CreateCreditCard(CreditCard1);

            new CreditCardMgr().RemoveCreditCard(CreditCard1);

        }

        /// <summary>
        /// Modify CreditCard using CreditCard Mgr
        /// </summary>
        [TestMethod]
        public void TestCreditCardMgrModify()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("CreditCardServiceCityModify", "CreditCardServiceStreetModify", "KS", 55555);
            Person Person1 = new Person((byte)25, "CreditCardServiceFirstNameModify_" + personIdVal, "CreditCardServiceLastNameModify_" + personIdVal, "CreditCardServiceUserNameModify_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 5555, 700, 1, (byte)2, (byte)3);

            new CreditCardMgr().CreateCreditCard(CreditCard1);

            CreditCard1.CreditCardNumber = 999000000000L + CreditCardIdVal;

            new CreditCardMgr().ModifyCreditCard(CreditCard1);
        }

        /// <summary>
        /// Retrieve CreditCard using CreditCard Mgr
        /// </summary>
        [TestMethod]
        public void TestCreditCardMgrRetrieve()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("CreditCardServiceCityRetrieve", "CreditCardServiceStreetRetrieve", "KS", 55555);
            Person Person1 = new Person((byte)25, "CreditCardServiceFirstNameRetrieve_" + personIdVal, "CreditCardServiceLastNameRetrieve_" + personIdVal, "CreditCardServiceUserNameRetrieve_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 5555, 700, 1, (byte)2, (byte)3);

            new CreditCardMgr().CreateCreditCard(CreditCard1);

            CreditCard CreditCard2 = new CreditCardMgr().RetrieveCreditCard("Limit", (int?) 5555);

            Assert.IsTrue(CreditCard2 != null);
        }


        /// <summary>
        /// Retrieve All CreditCards using CreditCard Mgr
        /// </summary>
        [TestMethod]
        public void testCreditCardMgrRetrieveAll()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("CreditCardServiceCityRetrieveAll", "CreditCardServiceStreetRetrieveAll", "KS", 55555);
            Person Person1 = new Person((byte)25, "CreditCardServiceFirstNameRetrieveAll_" + personIdVal, "CreditCardServiceLastNameRetrieveAll_" + personIdVal, "CreditCardServiceUserNameRetrieveAll_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 5555, 700, 1, (byte)2, (byte)3);

            new CreditCardMgr().CreateCreditCard(CreditCard1);


            List<CreditCard> myList = new CreditCardMgr().RetrieveAllCreditCards().ToList<CreditCard>();
            Assert.IsTrue(myList.Count > 0);
        }
    }

    [TestClass]
    public class AccountMgrTest
    {
        /// <summary>
        /// Create Account using Account Mgr
        /// </summary>
        [TestMethod]
        public void TestAccountMgrCreate()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("AccountServiceCityCreate", "AccountServiceStreetCreate", "KS", 55555);
            Person Person1 = new Person((byte)25, "AccountServiceFirstNameCreate_" + personIdVal, "AccountServiceLastNameCreate_" + personIdVal, "AccountServiceUserNameCreate_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 10000, 100, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 1000, 100);

            new AccountMgr().CreateAccount(Account1);
        }

        /// <summary>
        /// Remove Account using Account Mgr
        /// </summary>
        [TestMethod]
        public void TestAccountMgrRemove()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("AccountServiceCityRemove", "AccountServiceStreetRemove", "KS", 55555);
            Person Person1 = new Person((byte)25, "AccountServiceFirstNameRemove_" + personIdVal, "AccountServiceLastNameRemove_" + personIdVal, "AccountServiceUserNameRemove_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 20000, 200, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 2000, 200);

            new AccountMgr().CreateAccount(Account1);

            new AccountMgr().RemoveAccount(Account1);

        }

        /// <summary>
        /// Modify Account using Account Mgr
        /// </summary>
        [TestMethod]
        public void TestAccountMgrModify()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("AccountServiceCityModify", "AccountServiceStreetModify", "KS", 55555);
            Person Person1 = new Person((byte)25, "AccountServiceFirstNameModify_" + personIdVal, "AccountServiceLastNameModify_" + personIdVal, "AccountServiceUserNameModify_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 30000, 300, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 3000, 300);

            new AccountMgr().CreateAccount(Account1);

            Account1.Limit = 10 + Account1.AccountId;

            new AccountMgr().ModifyAccount(Account1);
        }

        /// <summary>
        /// Retrieve Account using Account Mgr
        /// </summary>
        [TestMethod]
        public void TestAccountMgrRetrieve()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("AccountServiceCityRetrieve", "AccountServiceStreetRetrieve", "KS", 55555);
            Person Person1 = new Person((byte)25, "AccountServiceFirstNameRetrieve_" + personIdVal, "AccountServiceLastNameRetrieve_" + personIdVal, "AccountServiceUserNameRetrieve_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 444444, (decimal)400.44, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 4000, 400);

            new AccountMgr().CreateAccount(Account1);

            Account Account2 = new AccountMgr().RetrieveAccount("Limit", 4000);

            //Assert.IsTrue(Account2.validate());
        }


        /// <summary>
        /// Retrieve All Accounts using Account Mgr
        /// </summary>
        [TestMethod]
        public void testAccountMgrRetrieveAll()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("AccountServiceCityRetrieveAll", "AccountServiceStreetRetrieveAll", "KS", 55555);
            Person Person1 = new Person((byte)25, "AccountServiceFirstNameRetrieveAll_" + personIdVal, "AccountServiceLastNameRetrieveAll_" + personIdVal, "AccountServiceUserNameRetrieveAll_" + personIdVal, Address1);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 55555, 500, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 5000, 500);

            new AccountMgr().CreateAccount(Account1);


            List<Account> myList = new AccountMgr().RetrieveAllAccounts().ToList<Account>();
            Assert.IsTrue(myList.Count > 0);
        }
    }

    [TestClass]
    public class TransactionMgrTest
    {
        /// <summary>
        /// Create Transaction using Transaction Mgr
        /// </summary>
        [TestMethod]
        public void TestTransactionMgrCreate()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("TrxMgrCityCreate", "TrxMgrStreetCreate", "KS", 55555);
            Person Person1 = new Person((byte)25, "TrxMgrFirstNameCreate_" + personIdVal, "TrxMgrLastNameCreate_" + personIdVal, "TrxMgrUserNameCreate_" + personIdVal, Address1);
            Account Account1 = new Account(Person1, 1000, 100);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 10000, 100, 1, (byte)2, (byte)3, Person1, Account1);
            Transaction Transaction1 = new Transaction(100, 1, 1, 11, "TrxMgrBusinessCreate", CreditCard1);

            new TransactionMgr().CreateTransaction(Transaction1);
        }

        /// <summary>
        /// Remove Transaction using Transaction Mgr
        /// </summary>
        [TestMethod]
        public void TestTransactionMgrRemove()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("TrxMgrCityRemove", "TrxMgrStreetRemove", "KS", 55555);
            Person Person1 = new Person((byte)25, "TrxMgrFirstNameRemove_" + personIdVal, "TrxMgrLastNameRemove_" + personIdVal, "TrxMgrUserNameRemove_" + personIdVal, Address1);
            Account Account1 = new Account(Person1, 2000, 200);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 20000, 200, 1, (byte)2, (byte)3, Person1, Account1);

            Transaction Transaction1 = new Transaction(200, 2, 2, 22, "TrxMgrBusinessRemove", CreditCard1);

            new TransactionMgr().CreateTransaction(Transaction1);

            new TransactionMgr().RemoveTransaction(Transaction1);

        }

        /// <summary>
        /// Modify Transaction using Transaction Mgr
        /// </summary>
        [TestMethod]
        public void TestTransactionMgrModify()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("TrxMgrCityModify", "TrxMgrStreetModify", "KS", 55555);
            Person Person1 = new Person((byte)25, "TrxMgrFirstNameModify_" + personIdVal, "TrxMgrLastNameModify_" + personIdVal, "TrxMgrUserNameModify_" + personIdVal, Address1);
            Account Account1 = new Account(Person1, 3000, 300);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 30000, 300, 1, (byte)2, (byte)3, Person1, Account1);
            Transaction Transaction1 = new Transaction(300, 3, 3, 33, "TrxMgrBusinessModify", CreditCard1);

            new TransactionMgr().CreateTransaction(Transaction1);

            Transaction1.Amount = 999;

            new TransactionMgr().ModifyTransaction(Transaction1);
        }

        /// <summary>
        /// Retrieve Transaction using Transaction Mgr
        /// </summary>
        [TestMethod]
        public void TestTransactionMgrRetrieve()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("TrxMgrCityRetrieve", "TrxMgrStreetRetrieve", "KS", 55555);
            Person Person1 = new Person((byte)25, "TrxMgrFirstNameRetrieve_" + personIdVal, "TrxMgrLastNameRetrieve_" + personIdVal, "TrxMgrUserNameRetrieve_" + personIdVal, Address1);
            Account Account1 = new Account(Person1, 4000, 400);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 444444, (decimal)400.44, 1, (byte)2, (byte)3, Person1, Account1);
            Transaction Transaction1 = new Transaction(400, 4, 4, 44, "TrxMgrBusinessRetrieve", CreditCard1);

            new TransactionMgr().CreateTransaction(Transaction1);

            Transaction Transaction2 = new TransactionMgr().RetrieveTransaction("BusinessName", "TrxMgrBusinessRetrieve");

            Assert.IsTrue(Transaction2.validate());
        }


        /// <summary>
        /// Retrieve All Transactions using Transaction Mgr
        /// </summary>
        [TestMethod]
        public void testTransactionMgrRetrieveAll()
        {
            bullerEntities db = new bullerEntities();

            var personIdVal = (db.People.Max(id => (int?)id.PersonId) >= 0) ? (db.People.Max(id => id.PersonId) + 1) : 1;
            var CreditCardIdVal = (db.CreditCards.Max(id => (int?)id.CreditCardId) >= 0) ? (db.CreditCards.Max(id => id.CreditCardId) + 1) : 1;

            Address Address1 = new Address("TrxMgrCityRetrieveAll", "TrxMgrStreetRetrieveAll", "KS", 55555);
            Person Person1 = new Person((byte)25, "TrxMgrFirstNameRetrieveAll_" + personIdVal, "TrxMgrLastNameRetrieveAll_" + personIdVal, "TrxMgrUserNameRetrieveAll_" + personIdVal, Address1);
            Account Account1 = new Account(Person1, 5000, 500);
            CreditCard CreditCard1 = new CreditCard(900000000000L + CreditCardIdVal, 55555, 500, 1, (byte)2, (byte)3, Person1, Account1);
            Transaction Transaction1 = new Transaction(500, 5, 5, 55, "TrxMgrBusinessRetrieveAll", CreditCard1);

            new TransactionMgr().CreateTransaction(Transaction1);


            List<Transaction> myList = new TransactionMgr().RetrieveAllTransactions().ToList<Transaction>();
            Assert.IsTrue(myList.Count > 0);
        }
    }
}

