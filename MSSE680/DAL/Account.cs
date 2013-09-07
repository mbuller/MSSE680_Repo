//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MSSE680.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account
    {
        /**
         * Default constructor
         * 
         */
        public Account()
        {
            this.CreditCards = new HashSet<CreditCard>();
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
        }

        /**
         * Setters getters for Account class
         */    
        public int AccountId { get; set; }
        public Nullable<int> CreditCard_CreditCardId { get; set; }
        public Nullable<int> AccountUser_PersonId { get; set; }
    
        public virtual CreditCard CreditCard { get; set; }
        public virtual Person AccountUser { get; set; }
        public virtual ICollection<CreditCard> CreditCards { get; set; }

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
}