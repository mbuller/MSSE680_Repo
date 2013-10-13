using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using DAL;

namespace Service
{
    public partial class CreditCardSvcRepoImpl : ICreditCardSvc
    {
        public DataRepository<CreditCard> CreditCardRepo;

        public CreditCardSvcRepoImpl()
        {
            CreditCardRepo = new DataRepository<CreditCard>();
        }

        public void CreateCreditCard(CreditCard CreditCard)
        {
            CreditCardRepo.Insert(CreditCard);
        }
        public void RemoveCreditCard(CreditCard CreditCard)
        {
            CreditCardRepo.Delete(CreditCard);
        }
        public void ModifyCreditCard(CreditCard CreditCard)
        {
            CreditCardRepo.Update(CreditCard);
        }

        public CreditCard RetrieveCreditCard(String DBColumnName, String StringValue)
        {
            return CreditCardRepo.GetBySpecificKey(DBColumnName, StringValue).FirstOrDefault<CreditCard>();
        }

        public CreditCard RetrieveCreditCard(String DBColumnName, int IntValue)
        {
            return CreditCardRepo.GetBySpecificKey(DBColumnName, IntValue).FirstOrDefault<CreditCard>();
        }

        public CreditCard RetrieveCreditCard(String DBColumnName, int? NullableIntValue)
        {
            return CreditCardRepo.GetBySpecificKey(DBColumnName, NullableIntValue).FirstOrDefault<CreditCard>();
        }
        public ICollection<CreditCard> RetrieveCreditCards(String DBColumnName, int NullableIntValue)
        {
            return CreditCardRepo.GetBySpecificKey(DBColumnName, NullableIntValue).ToList<CreditCard>();
        }        
        
        public ICollection<CreditCard> RetrieveCreditCards(String DBColumnName, int? NullableIntValue)
        {
            return CreditCardRepo.GetBySpecificKey(DBColumnName, NullableIntValue).ToList<CreditCard>();
        }
        public ICollection<CreditCard> RetrieveAllCreditCards()
        {
            return CreditCardRepo.GetAll().ToList<CreditCard>();
        }


        public void AddAccountToCreditCard(Account Account, CreditCard CreditCard)
        {
            CreditCard.Account_AccountId = Account.AccountId;
            ModifyCreditCard(CreditCard);
        }
        public void RemoveAccountFromCreditCard(Account Account, CreditCard CreditCard)
        {
            CreditCard.Account_AccountId = null;
            ModifyCreditCard(CreditCard);
        }

        public void AddPersonToCreditCard(Person Person, CreditCard CreditCard)
        {
            CreditCard.CreditCardUser_PersonId = Person.PersonId;
            ModifyCreditCard(CreditCard);
        }
        public void RemovePersonFromCreditCard(Person Person, CreditCard CreditCard)
        {
            CreditCard.CreditCardUser_PersonId = null;
            ModifyCreditCard(CreditCard);
        }

        public void DisposeCreditCard()
        {
            CreditCardRepo.Dispose();
        }
    }
}
