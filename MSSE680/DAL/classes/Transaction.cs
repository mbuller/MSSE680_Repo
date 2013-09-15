using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSE680.DAL
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
