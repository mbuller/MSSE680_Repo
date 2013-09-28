using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using MSSE680.DAL;
using MSSE680.Service;
using MSSE680.Business;

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
            Address Address1 = new Address("PersonServiceCityCreate", "PersonServiceStreetCreate", "KS", 55555);
            Person Person1 = new Person((byte)25, "PersonServiceFirstNameCreate", "PersonServiceLastNameCreate", "PersonServiceUserNameCreate", Address1);

            new PersonMgr().CreatePerson(Person1);
        }

        /// <summary>
        /// Remove Person using Person Mgr
        /// </summary>
        [TestMethod]
        public void TestPersonMgrRemove()
        {
            Address Address1 = new Address("PersonServiceCityRemove", "PersonServiceStreetRemove", "KS", 55555);
            Person Person1 = new Person((byte)25, "PersonServiceFirstNameRemove", "PersonServiceLastNameRemove", "PersonServiceUserNameRemove", Address1);
            new PersonMgr().CreatePerson(Person1);

            new PersonMgr().RemovePerson(Person1);

        }

        /// <summary>
        /// Modify Person using Person Mgr
        /// </summary>
        [TestMethod]
        public void TestPersonMgrModify()
        {
            Address Address1 = new Address("PersonServiceCityModify", "PersonServiceStreetModify", "KS", 55555);
            Person Person1 = new Person((byte)25, "PersonServiceFirstNameModify", "PersonServiceLastNameModify", "PersonServiceUserNameModify", Address1);

            new PersonMgr().CreatePerson(Person1);

            Person1.FirstName = "PersonServiceFirstNameModify" + Person1.PersonId;
            Person1.LastName = "PersonServiceLastNameModify" + Person1.PersonId;
            Person1.UserName = "PersonServiceUserNameModify" + Person1.PersonId;

            new PersonMgr().ModifyPerson(Person1);
        }

        /// <summary>
        /// Retrieve Person using Person Mgr
        /// </summary>
        [TestMethod]
        public void TestPersonMgrRetrieve()
        {
            Address Address1 = new Address("PersonServiceCityRetrieve", "PersonServiceStreetRetrieve", "KS", 55555);
            Person Person1 = new Person((byte)25, "PersonServiceFirstNameRetrieve", "PersonServiceLastNameRetrieve", "PersonServiceUserNameRetrieve", Address1);

            new PersonMgr().CreatePerson(Person1);

            Person Person2 = new PersonMgr().RetrievePerson("FirstName", "PersonServiceFirstNameRetrieve");

            Assert.IsTrue(Person2.validate());
        }


        /// <summary>
        /// Retrieve All People using Person Mgr
        /// </summary>
        [TestMethod]
        public void testPersonMgrRetrieveAll()
        {
            Address Address1 = new Address("PersonServiceCityRetrieveAll", "PersonServiceStreetRetrieveAll", "KS", 55555);
            Person Person1 = new Person((byte)25, "PersonServiceFirstNameRetrieveAll", "PersonServiceLastNameRetrieveAll", "PersonServiceUserNameRetrieveAll", Address1);

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
            Address Address1 = new Address("CreditCardServiceCityCreate", "CreditCardServiceStreetCreate", "KS", 55555);
            Person Person1 = new Person((byte)25, "CreditCardServiceFirstNameCreate", "CreditCardServiceLastNameCreate", "CreditCardServiceUserNameCreate", Address1);
            CreditCard CreditCard1 = new CreditCard(711111111L, 7100, 710, 1, (byte)1, (byte)1, Person1);

            new CreditCardMgr().CreateCreditCard(CreditCard1);
        }

        /// <summary>
        /// Remove CreditCard using CreditCard Mgr
        /// </summary>
        [TestMethod]
        public void TestCreditCardMgrRemove()
        {
            Address Address1 = new Address("CreditCardServiceCityRemove", "CreditCardServiceStreetRemove", "KS", 55555);
            Person Person1 = new Person((byte)25, "CreditCardServiceFirstNameRemove", "CreditCardServiceLastNameRemove", "CreditCardServiceUserNameRemove", Address1);
            CreditCard CreditCard1 = new CreditCard(7222222222L, 7200, 720, 2, (byte)2, (byte)2, Person1);

            new CreditCardMgr().CreateCreditCard(CreditCard1);

            new CreditCardMgr().RemoveCreditCard(CreditCard1);

        }

        /// <summary>
        /// Modify CreditCard using CreditCard Mgr
        /// </summary>
        [TestMethod]
        public void TestCreditCardMgrModify()
        {
            Address Address1 = new Address("CreditCardServiceCityModify", "CreditCardServiceStreetModify", "KS", 55555);
            Person Person1 = new Person((byte)25, "CreditCardServiceFirstNameModify", "CreditCardServiceLastNameModify", "CreditCardServiceUserNameModify", Address1);
            CreditCard CreditCard1 = new CreditCard(7333333333L, 7300, 730, 3, (byte)3, (byte)3, Person1);

            new CreditCardMgr().CreateCreditCard(CreditCard1);

            CreditCard1.CreditCardNumber = 888999000L + CreditCard1.CreditCardId;

            new CreditCardMgr().ModifyCreditCard(CreditCard1);
        }

        /// <summary>
        /// Retrieve CreditCard using CreditCard Mgr
        /// </summary>
        [TestMethod]
        public void TestCreditCardMgrRetrieve()
        {
            Address Address1 = new Address("CreditCardServiceCityRetrieve", "CreditCardServiceStreetRetrieve", "KS", 55555);
            Person Person1 = new Person((byte)25, "CreditCardServiceFirstNameRetrieve", "CreditCardServiceLastNameRetrieve", "CreditCardServiceUserNameRetrieve", Address1);
            CreditCard CreditCard1 = new CreditCard(7444444444L, 7400, 740, 4, (byte)4, (byte)4, Person1);

            new CreditCardMgr().CreateCreditCard(CreditCard1);

            CreditCard CreditCard2 = new CreditCardMgr().RetrieveCreditCard("Limit", 7400);

            Assert.IsTrue(CreditCard2.validate());
        }


        /// <summary>
        /// Retrieve All CreditCards using CreditCard Mgr
        /// </summary>
        [TestMethod]
        public void testCreditCardMgrRetrieveAll()
        {
            Address Address1 = new Address("CreditCardServiceCityRetrieveAll", "CreditCardServiceStreetRetrieveAll", "KS", 55555);
            Person Person1 = new Person((byte)25, "CreditCardServiceFirstNameRetrieveAll", "CreditCardServiceLastNameRetrieveAll", "CreditCardServiceUserNameRetrieveAll", Address1);
            CreditCard CreditCard1 = new CreditCard(7444444444L, 7400, 740, 4, (byte)4, (byte)4, Person1);

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
            Address Address1 = new Address("AccountServiceCityCreate", "AccountServiceStreetCreate", "KS", 55555);
            Person Person1 = new Person((byte)25, "AccountServiceFirstNameCreate", "AccountServiceLastNameCreate", "AccountServiceUserNameCreate", Address1);
            CreditCard CreditCard1 = new CreditCard(11111111L, 10000, 100, 1, (byte)2, (byte)3, Person1);
            Account Account1 = new Account(CreditCard1, Person1, 1000, 100);

            new AccountMgr().CreateAccount(Account1);
        }

        /// <summary>
        /// Remove Account using Account Mgr
        /// </summary>
        [TestMethod]
        public void TestAccountMgrRemove()
        {
            Address Address1 = new Address("AccountServiceCityRemove", "AccountServiceStreetRemove", "KS", 55555);
            Person Person1 = new Person((byte)25, "AccountServiceFirstNameRemove", "AccountServiceLastNameRemove", "AccountServiceUserNameRemove", Address1);
            CreditCard CreditCard1 = new CreditCard(222222222L, 20000, 200, 1, (byte)2, (byte)3, Person1);
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
            Address Address1 = new Address("AccountServiceCityModify", "AccountServiceStreetModify", "KS", 55555);
            Person Person1 = new Person((byte)25, "AccountServiceFirstNameModify", "AccountServiceLastNameModify", "AccountServiceUserNameModify", Address1);
            CreditCard CreditCard1 = new CreditCard(333333333L, 30000, 300, 1, (byte)2, (byte)3, Person1);
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
            Address Address1 = new Address("AccountServiceCityRetrieve", "AccountServiceStreetRetrieve", "KS", 55555);
            Person Person1 = new Person((byte)25, "AccountServiceFirstNameRetrieve", "AccountServiceLastNameRetrieve", "AccountServiceUserNameRetrieve", Address1);
            CreditCard CreditCard1 = new CreditCard(444444444L, 444444, 400.44, 1, (byte)2, (byte)3, Person1);
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
            Address Address1 = new Address("AccountServiceCityRetrieveAll", "AccountServiceStreetRetrieveAll", "KS", 55555);
            Person Person1 = new Person((byte)25, "AccountServiceFirstNameRetrieveAll", "AccountServiceLastNameRetrieveAll", "AccountServiceUserNameRetrieveAll", Address1);
            CreditCard CreditCard1 = new CreditCard(555555555L, 55555, 500, 1, (byte)2, (byte)3, Person1);
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
            Address Address1 = new Address("TransactionServiceCityCreate", "TransactionServiceStreetCreate", "KS", 55555);
            Person Person1 = new Person((byte)25, "TransactionServiceFirstNameCreate", "TransactionServiceLastNameCreate", "TransactionServiceUserNameCreate", Address1);
            Account Account1 = new Account(Person1, 1000, 100);
            CreditCard CreditCard1 = new CreditCard(11111111L, 10000, 100, 1, (byte)2, (byte)3, Person1, Account1);
            Transaction Transaction1 = new Transaction(100, 1, 1, 11, "TransactionServiceBusinessCreate", CreditCard1);

            new TransactionMgr().CreateTransaction(Transaction1);
        }

        /// <summary>
        /// Remove Transaction using Transaction Mgr
        /// </summary>
        [TestMethod]
        public void TestTransactionMgrRemove()
        {
            Address Address1 = new Address("TransactionServiceCityRemove", "TransactionServiceStreetRemove", "KS", 55555);
            Person Person1 = new Person((byte)25, "TransactionServiceFirstNameRemove", "TransactionServiceLastNameRemove", "TransactionServiceUserNameRemove", Address1);
            Account Account1 = new Account(Person1, 2000, 200);
            CreditCard CreditCard1 = new CreditCard(222222222L, 20000, 200, 1, (byte)2, (byte)3, Person1, Account1);

            Transaction Transaction1 = new Transaction(200, 2, 2, 22, "TransactionServiceBusinessRemove", CreditCard1);

            new TransactionMgr().CreateTransaction(Transaction1);

            new TransactionMgr().RemoveTransaction(Transaction1);

        }

        /// <summary>
        /// Modify Transaction using Transaction Mgr
        /// </summary>
        [TestMethod]
        public void TestTransactionMgrModify()
        {
            Address Address1 = new Address("TransactionServiceCityModify", "TransactionServiceStreetModify", "KS", 55555);
            Person Person1 = new Person((byte)25, "TransactionServiceFirstNameModify", "TransactionServiceLastNameModify", "TransactionServiceUserNameModify", Address1);
            Account Account1 = new Account(Person1, 3000, 300);
            CreditCard CreditCard1 = new CreditCard(333333333L, 30000, 300, 1, (byte)2, (byte)3, Person1, Account1);
            Transaction Transaction1 = new Transaction(300, 3, 3, 33, "TransactionServiceBusinessModify", CreditCard1);

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
            Address Address1 = new Address("TransactionServiceCityRetrieve", "TransactionServiceStreetRetrieve", "KS", 55555);
            Person Person1 = new Person((byte)25, "TransactionServiceFirstNameRetrieve", "TransactionServiceLastNameRetrieve", "TransactionServiceUserNameRetrieve", Address1);
            Account Account1 = new Account(Person1, 4000, 400);
            CreditCard CreditCard1 = new CreditCard(444444444L, 444444, 400.44, 1, (byte)2, (byte)3, Person1, Account1);
            Transaction Transaction1 = new Transaction(400, 4, 4, 44, "TransactionServiceBusinessRetrieve", CreditCard1);

            new TransactionMgr().CreateTransaction(Transaction1);

            Transaction Transaction2 = new TransactionMgr().RetrieveTransaction("BusinessName", "TransactionServiceBusinessRetrieve");

            Assert.IsTrue(Transaction2.validate());
        }


        /// <summary>
        /// Retrieve All Transactions using Transaction Mgr
        /// </summary>
        [TestMethod]
        public void testTransactionMgrRetrieveAll()
        {
            Address Address1 = new Address("TransactionServiceCityRetrieveAll", "TransactionServiceStreetRetrieveAll", "KS", 55555);
            Person Person1 = new Person((byte)25, "TransactionServiceFirstNameRetrieveAll", "TransactionServiceLastNameRetrieveAll", "TransactionServiceUserNameRetrieveAll", Address1);
            Account Account1 = new Account(Person1, 5000, 500);
            CreditCard CreditCard1 = new CreditCard(555555555L, 55555, 500, 1, (byte)2, (byte)3, Person1, Account1);
            Transaction Transaction1 = new Transaction(500, 5, 5, 55, "TransactionServiceBusinessRetrieveAll", CreditCard1);

            new TransactionMgr().CreateTransaction(Transaction1);


            List<Transaction> myList = new TransactionMgr().RetrieveAllTransactions().ToList<Transaction>();
            Assert.IsTrue(myList.Count > 0);
        }
    }
}

