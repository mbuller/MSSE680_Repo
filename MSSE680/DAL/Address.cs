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
    
    public partial class Address
    {
        public Address()
        {
            this.People = new HashSet<Person>();
        }
    
        public int AddressId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public Nullable<int> Zipcode { get; set; }
        public Nullable<int> Person_PersonId { get; set; }
    
        public virtual Person Person { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
