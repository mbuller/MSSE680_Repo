using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Service
{
    public interface ICreditCardSvc : IService
    {


        void CreateCreditCard(CreditCard CreditCard);
        void RemoveCreditCard(CreditCard CreditCard);
        void ModifyCreditCard(CreditCard CreditCard);
        CreditCard RetrieveCreditCard(String DBColumnName, String StringValue);
        CreditCard RetrieveCreditCard(String DBColumnName, int IntValue);
        CreditCard RetrieveCreditCard(String DBColumnName, int? NullableIntValue);
        ICollection<CreditCard> RetrieveAllCreditCards();

        ICollection<CreditCard> RetrieveCreditCards(String DBColumnName, int? NullableIntValue);
        ICollection<CreditCard> RetrieveCreditCards(String DBColumnName, int NullableIntValue);

        void AddAccountToCreditCard(Account Account, CreditCard CreditCard);
        void RemoveAccountFromCreditCard(Account Account, CreditCard CreditCard);

        void AddPersonToCreditCard(Person Person, CreditCard CreditCard);
        void RemovePersonFromCreditCard(Person Person, CreditCard CreditCard);

        void DisposeCreditCard();
    }
}
