using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSSE680.DAL;

namespace DALUnitTest
{

    [TestClass]
    public class AddressTest
    {
        [TestMethod]
        public void testAddressValidateTrue()
        {
            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);

            Assert.IsTrue(Address1.validate(), "testAddressValidateTrue Passed");
        }

        [TestMethod]
        public void testAddressValidateFalse()
        {
            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 0);

            Assert.IsFalse(Address1.validate(), "testAddressValidateFalse Passed");
        }
    }

    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void testPersonValidateTrue()
        {
            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);

            Person Person1 = new Person(25, (byte)30, "Matthew", "Buller", "mabuller", "Password1", Address1);


            Assert.IsTrue(Person1.validate(), "testPersonValidateTrue Passed");
        }

        [TestMethod]
        public void testPersonValidateFalse()
        {
            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);

            Person Person1 = new Person(25, (byte)30, null, "Buller", "mabuller", "Password1", Address1);


            Assert.IsFalse(Person1.validate(), "testPersonValidateTrue Passed");
        }
    }

    [TestClass]
    public class CreditCardTest
    {
        [TestMethod]
        public void testCreditCardValidateTrue()
        {
            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);

            Person Person1 = new Person(25, (byte)30, "Matthew", "Buller", "mabuller", "Password1", Address1);

            CreditCard CreditCard1 = new CreditCard(7000, 123456790L, 7000, 650, (byte)1, (byte)1, (byte)1, Person1);

            Assert.IsTrue(CreditCard1.validate(), "testCreditCardValidateTrue Passed");
        }

        [TestMethod]
        public void testCreditCardValidateFalse()
        {

            Person Person1 = new Person();

            CreditCard CreditCard1 = new CreditCard(7000, 123456790L, 7000, 650, (byte)1, (byte)1, (byte)1, Person1);

            Assert.IsFalse(CreditCard1.validate(), "testCreditCardValidateFalse Passed");
        }
    }

    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void testAccountValidateTrue()
        {
            Address Address1 = new Address(2,"Wichita","5856 Shocker Drive","KS",67219);

            Person Person1 = new Person(25, (byte)30,"Matthew","Buller","mabuller","Password1",Address1);
                
            CreditCard CreditCard1 = new CreditCard(7000, 123456790L,7000,650,(byte)1,(byte)1,(byte)12,Person1);                
                
            Account Account1 = new Account(3,CreditCard1,Person1);

            Assert.IsTrue(Account1.validate(), "testAccountValidateTrue Passed");
        }

        [TestMethod]
        public void testAccountValidateFalse()
        {
            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);

            Person Person1 = new Person(25, (byte)30, "Matthew", "Buller", "mabuller", "Password1", Address1);

            CreditCard CreditCard1 = new CreditCard(7000, 123456790L, 7000, 650, (byte)1, (byte)1, (byte)12, Person1);

            Account Account1 = new Account(-1, CreditCard1, Person1);

            Assert.IsFalse(Account1.validate(), "testAccountValidateFalse Passed");
        }
    }

    [TestClass]
    public class TransitionTest
    {
        [TestMethod]
        public void testTransitionValidateTrue()
        {
            Address Address1 = new Address(2, "Wichita", "5856 Shocker Drive", "KS", 67219);

            Person Person1 = new Person(25, (byte)30, "Matthew", "Buller", "mabuller", "Password1", Address1);

            CreditCard CreditCard1 = new CreditCard(7000, 123456790L, 7000, 650, (byte)1, (byte)1, (byte)12, Person1);

            Account Account1 = new Account(3, CreditCard1, Person1);

            Transaction Transaction1 = new Transaction(5, 200, 2, 3, 13, "ABC", CreditCard1);
            Assert.IsTrue(Transaction1.validate(), "testTransitionValidateTrue Passed");
        }

        [TestMethod]
        public void testTransitionValidateFalse()
        {

            Transaction Transaction2 = new Transaction(4, 200, 0, 3, 13, "ABC");
            Assert.IsFalse(Transaction2.validate(), "testTransitionValidateFalse Passed");
        }
    }
}
