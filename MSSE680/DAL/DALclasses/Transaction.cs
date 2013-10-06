using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
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
         * decimal Amount
         * byte TransactionDay
         * byte TransactionMonth
         * byte TransactionYear
         * String BusinessName
         */
        public Transaction(
                    decimal Amount,
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
         * decimal Amount
         * byte TransactionDay
         * byte TransactionMonth
         * byte TransactionYear
         * String BusinessName
         * CredictCard creditCard
         */
        public Transaction(
                    decimal Amount,
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
            this.CreditCard_CreditCardId = creditCard.CreditCardId;
        }

        /**
         * int TransactionId
         * decimal Amount
         * byte TransactionDay
         * byte TransactionMonth
         * byte TransactionYear
         * String BusinessName
         */
        public Transaction(
                    int TransactionId,
                    decimal Amount,
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
         * decimal Amount
         * byte TransactionDay
         * byte TransactionMonth
         * byte TransactionYear
         * String BusinessName
         */
        public Transaction(
                    int TransactionId,
                    decimal Amount,
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
            this.CreditCard_CreditCardId = creditCard.CreditCardId;
        }


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
