//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account
    {
        public Account()
        {
            this.CreditCards = new HashSet<CreditCard>();
        }
    
        public int AccountId { get; set; }
        public Nullable<int> CreditCard_CreditCardId { get; set; }
        public Nullable<int> AccountUser_PersonId { get; set; }
        public int Limit { get; set; }
        public decimal Balance { get; set; }
    
        public virtual Person AccountUser { get; set; }
        public virtual CreditCard CreditCard { get; set; }
        public virtual ICollection<CreditCard> CreditCards { get; set; }
    }
}
