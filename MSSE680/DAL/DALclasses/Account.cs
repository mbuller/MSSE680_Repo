using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [MetadataTypeAttribute(typeof(AccountMetadata))]
    public partial class Account
    {

        public Account(
           int accountUser_PersonId)
        {
            this.AccountUser_PersonId = accountUser_PersonId;
        }

        /**
         * AccountUser AccountUser
         * CreditCard CreditCard
         */
        public Account(
                   CreditCard CreditCard,
                   Person AccountUser)
        {
            this.CreditCard = CreditCard;
            this.AccountUser = AccountUser;
            this.CreditCard_CreditCardId = CreditCard.CreditCardId;
            this.AccountUser_PersonId = AccountUser.PersonId;
        }

        /**
        * int AccountNumber
        * AccountUser AccountUser
        * CreditCard CreditCard
        */
        public Account(
                   int AccountId,
                   CreditCard CreditCard,
                   Person AccountUser)
        {
            this.AccountId = AccountId;
            this.CreditCard = CreditCard;
            this.AccountUser = AccountUser;
            this.CreditCard_CreditCardId = CreditCard.CreditCardId;
            this.AccountUser_PersonId = AccountUser.PersonId;
        }

        /**
        * int AccountNumber
        * AccountUser AccountUser
        * CreditCard CreditCard
        */
        public Account(
                   Person AccountUser,
                   int Limit,
                   decimal Balance)
        {
            this.AccountUser = AccountUser;
            this.Limit = Limit;
            this.Balance = Balance;
            this.AccountUser_PersonId = AccountUser.PersonId;
        }

        /**
        * int AccountNumber
        * AccountUser AccountUser
        * CreditCard CreditCard
        */
        public Account(
                   CreditCard CreditCard,
                   Person AccountUser,
                   int Limit,
                   decimal Balance)
        {
            this.CreditCard = CreditCard;
            this.AccountUser = AccountUser;
            this.Limit = Limit;
            this.Balance = Balance;
            this.CreditCard_CreditCardId = CreditCard.CreditCardId;
            this.AccountUser_PersonId = AccountUser.PersonId;
        }


        /**
        * int AccountNumber
        * AccountUser AccountUser
        * CreditCard CreditCard
        */
        public Account(
                   int AccountId,
                   CreditCard CreditCard,
                   Person AccountUser,
                   int Limit,
                   decimal Balance)
        {
            this.AccountId = AccountId;
            this.CreditCard = CreditCard;
            this.AccountUser = AccountUser;
            this.Limit = Limit;
            this.Balance = Balance;
            this.CreditCard_CreditCardId = CreditCard.CreditCardId;
            this.AccountUser_PersonId = AccountUser.PersonId;
        }



        /**
         * Validate if the instance variables are valid
         *
         *  bool - true if instance variables are valid, else false
         */
        public bool validate()
        {
            if (AccountId < 0)
            {
                return false;
            }
            if (AccountUser.validate() == false)
            {
                return false;
            }
            if (CreditCard.validate() == false)
            {
                return false;
            }

            return true;
        }
    }

    public class AccountMetadata
    {
         [DisplayName("Account ID ")]
        public int AccountId { get; set; }
        [DisplayName("CreditCard ID ")]
        public Nullable<int> CreditCard_CreditCardId { get; set; }
        [DisplayName("Person ID ")]
        public Nullable<int> AccountUser_PersonId { get; set; }
        [DisplayName("Limit ")]
        public int Limit { get; set; }
        [DisplayName("Balance ")]
        public decimal Balance { get; set; }
}
}
