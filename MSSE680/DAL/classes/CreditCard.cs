using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSE680.DAL
{
    public partial class CreditCard
    {

        /**
         * int Limit
         * double Balance
         * byte CardType = 0 //Physica card
         *               = 1 //Virtual Card
         *               = 2 //Physical AND Virtual Card
         * byte ExpirationMonth
         * byte ExperationYear
         * Person CreditCardUser
         */
        public CreditCard(
                    int Limit,
                    double Balance,
                    byte CardType,
                    byte ExpirationMonth,
                    byte ExpirationYear,
                    Person CreditCardUser)
        {
            this.Limit = Limit;
            this.Balance = Balance;
            this.CardType = CardType;
            this.ExpirationMonth = ExpirationMonth;
            this.ExpirationYear = ExpirationYear;
            this.CreditCardUser = CreditCardUser;
        }

        /**
        * int CreidtCardId
        * long CreditCardNumber
        * int Limit
        * double Balance
        * byte CardType = 0 //Physica card
        *               = 1 //Virtual Card
        *               = 2 //Physical AND Virtual Card
        * byte ExpirationMonth
        * byte ExperationYear
        * Person CreditCardUser
        */
        public CreditCard(
                    long CreditCardNumber,
                    int Limit,
                    double Balance,
                    byte CardType,
                    byte ExpirationMonth,
                    byte ExpirationYear,
                    Person CreditCardUser)
        {
            this.CreditCardNumber = CreditCardNumber;
            this.Limit = Limit;
            this.Balance = Balance;
            this.CardType = CardType;
            this.ExpirationMonth = ExpirationMonth;
            this.ExpirationYear = ExpirationYear;
            this.CreditCardUser = CreditCardUser;
        }

        /**
        * int CreidtCardId
        * long CreditCardNumber
        * int Limit
        * double Balance
        * byte CardType = 0 //Physica card
        *               = 1 //Virtual Card
        *               = 2 //Physical AND Virtual Card
        * byte ExpirationMonth
        * byte ExperationYear
        * Person CreditCardUser
        */
        public CreditCard(
                    int CreditCardId,
                    long CreditCardNumber,
                    int Limit,
                    double Balance,
                    byte CardType,
                    byte ExpirationMonth,
                    byte ExpirationYear,
                    Person CreditCardUser)
        {
            this.CreditCardId = CreditCardId;
            this.CreditCardNumber = CreditCardNumber;
            this.Limit = Limit;
            this.Balance = Balance;
            this.CardType = CardType;
            this.ExpirationMonth = ExpirationMonth;
            this.ExpirationYear = ExpirationYear;
            this.CreditCardUser = CreditCardUser;
        }


        /**
        * int CreidtCardId
        * long CreditCardNumber
        * int Limit
        * double Balance
        * byte CardType = 0 //Physica card
        *               = 1 //Virtual Card
        *               = 2 //Physical AND Virtual Card
        * byte ExpirationMonth
        * byte ExperationYear
        * Person CreditCardUser
        */
        public CreditCard(
                    long CreditCardNumber,
                    int Limit,
                    double Balance,
                    byte CardType,
                    byte ExpirationMonth,
                    byte ExpirationYear,
                    Person CreditCardUser,
                    Account Account)
        {
            this.CreditCardNumber = CreditCardNumber;
            this.Limit = Limit;
            this.Balance = Balance;
            this.CardType = CardType;
            this.ExpirationMonth = ExpirationMonth;
            this.ExpirationYear = ExpirationYear;
            this.CreditCardUser = CreditCardUser;
            this.Account = Account;
        }

        /**
        * int CreidtCardId
        * long CreditCardNumber
        * int Limit
        * double Balance
        * byte CardType = 0 //Physica card
        *               = 1 //Virtual Card
        *               = 2 //Physical AND Virtual Card
        * byte ExpirationMonth
        * byte ExperationYear
        * Person CreditCardUser
        */
        public CreditCard(
                    int CreditCardId,
                    long CreditCardNumber,
                    int Limit,
                    double Balance,
                    byte CardType,
                    byte ExpirationMonth,
                    byte ExpirationYear,
                    Person CreditCardUser,
                    Account Account)
        {
            this.CreditCardId = CreditCardId;
            this.CreditCardNumber = CreditCardNumber;
            this.Limit = Limit;
            this.Balance = Balance;
            this.CardType = CardType;
            this.ExpirationMonth = ExpirationMonth;
            this.ExpirationYear = ExpirationYear;
            this.CreditCardUser = CreditCardUser;
            this.Account = Account;
        }
       

        /**
         * Validate if the instance variables are valid
         *
         *  bool - true if instance variables are valid, else false
         */
        public bool validate()
        {
            if (CreditCardId < 0)
            {
                return false;
            }
            if (CreditCardNumber == 0)
            {
                return false;
            }
            if (CardType < 0)
                 {
                     return false;
                 }
                 if (Limit == 0)
                 {
         
                     return false;
                 }
               if (ExpirationMonth < 1)
                  {
          
                      return false;
                  }

               if (ExpirationYear < 1)
                        {
      
                            return false;
                        }
                    
                 if (CreditCardUser.validate() == false)
                             {
                                 return false;
                             }
                            
            return true;
        }
    }
}
