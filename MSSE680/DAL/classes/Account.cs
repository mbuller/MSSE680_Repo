using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSE680.DAL
{
    public partial class Account
    {

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
        * int AccountNumber
        * AccountUser AccountUser
        * CreditCard CreditCard
        */
        public Account(
                   int AccountId,
                   CreditCard CreditCard,
                   Person AccountUser,
                   int Limit,
                   double Balance)
        {
            this.AccountId = AccountId;
            this.CreditCard = CreditCard;
            this.AccountUser = AccountUser;
            this.Limit = Limit;
            this.Balance = Balance;
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
                   double Balance)
        {
            this.CreditCard = CreditCard;
            this.AccountUser = AccountUser;
            this.Limit = Limit;
            this.Balance = Balance;
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
}
