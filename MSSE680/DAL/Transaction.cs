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

    public partial class Transaction
    {
        /**
         * Default constructor
         * 
         */
        public Transaction()
        {

        }

        /**
         * double Amount
         * byte TransactionDay
         * byte TransactionMonth
         * byte TransactionYear
         * String BusinessName
         */
        public Transaction(
                    double Amount,
                    byte TransactionDay,
                    byte TransactionMonth,
                    byte TransactionYear,
                    String BusinessName)
        {
            this.Amount = Amount;
            this.TransactionDay = TransactionDay;
            this.TransactionMonth = TransactionMonth;
            this.TransactionYear = TransactionYear;
            this.BusinessName = BusinessName;
            this.CreditCard = null;
        }
        
        /**
         * double Amount
         * byte TransactionDay
         * byte TransactionMonth
         * byte TransactionYear
         * String BusinessName
         * CredictCard creditCard
         */
        public Transaction(
                    double Amount,
                    byte TransactionDay,
                    byte TransactionMonth,
                    byte TransactionYear,
                    String BusinessName,
                    CreditCard creditCard)
        {
            this.Amount = Amount;
            this.TransactionDay = TransactionDay;
            this.TransactionMonth = TransactionMonth;
            this.TransactionYear = TransactionYear;
            this.BusinessName = BusinessName;
            this.CreditCard = creditCard;
        }

        /**
         * int TransactionId
         * double Amount
         * byte TransactionDay
         * byte TransactionMonth
         * byte TransactionYear
         * String BusinessName
         */
        public Transaction(
                    int TransactionId,
                    double Amount,
                    byte TransactionDay,
                    byte TransactionMonth,
                    byte TransactionYear,
                    String BusinessName)
        {
            this.TransactionId = TransactionId;
            this.Amount = Amount;
            this.TransactionDay = TransactionDay;
            this.TransactionMonth = TransactionMonth;
            this.TransactionYear = TransactionYear;
            this.BusinessName = BusinessName;
            this.CreditCard = null;
        }

        /**
         * int TransactionId
         * double Amount
         * byte TransactionDay
         * byte TransactionMonth
         * byte TransactionYear
         * String BusinessName
         */
        public Transaction(
                    int TransactionId,
                    double Amount,
                    byte TransactionDay,
                    byte TransactionMonth,
                    byte TransactionYear,
                    String BusinessName,
                    CreditCard creditCard)
        {
            this.TransactionId = TransactionId;
            this.Amount = Amount;
            this.TransactionDay = TransactionDay;
            this.TransactionMonth = TransactionMonth;
            this.TransactionYear = TransactionYear;
            this.BusinessName = BusinessName;
            this.CreditCard = creditCard;
        }

        /**
         * Setters getters for Transaction class
         */
        public int TransactionId { get; set; }
        public double Amount { get; set; }
        public byte TransactionDay { get; set; }
        public byte TransactionMonth { get; set; }
        public byte TransactionYear { get; set; }
        public string BusinessName { get; set; }
        public Nullable<int> CreditCard_CreditCardId { get; set; }

        public virtual CreditCard CreditCard { get; set; }


        /**
         * Validate if the instance variables are valid
         *
         * bool - true if instance variables are valid, else false
         */
        public bool validate()
        {
            if (TransactionId < 0)
            {
                return false;
            }
            if (Amount < 0)
            {
                return false;
            }
            if (TransactionDay == (byte)0)
            {
                return false;
            }
            if (TransactionMonth == (byte)0)
            {
                return false;
            }
            if (TransactionYear == (byte)0)
            {
                return false;
            }
            if (BusinessName == null)
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
