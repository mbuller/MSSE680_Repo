using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSE680.DAL;

namespace MSSE680.DAL
{
    public partial class Address
    {

        /**
         * String City
         * String Street
         * String State
         * int ZipCode
         */
        public Address(
                    String City,
                    String Street,
                    String State,
                    int Zipcode)
        {
            this.AddressId = AddressId;
            this.City = City;
            this.Street = Street;
            this.State = State;
            this.Zipcode = Zipcode;
        }

        /**
         * int AddressId
         * String City
         * String Street
         * String State
         * int ZipCode
         */
        public Address(
                    int AddressId,
                    String City,
                    String Street,
                    String State,
                    int Zipcode)
        {
            this.AddressId = AddressId;
            this.City = City;
            this.Street = Street;
            this.State = State;
            this.Zipcode = Zipcode;
        }

        /**
         * Validate if the instance variables are valid
         *
         * bool - true if instance variables are valid, else false
         */
        public bool validate()
        {
            if (AddressId < 0)
            {
                return false;
            }
            if (City == null)
            {
                return false;
            }
            if (Street == null)
            {
                return false;
            }
            if (State == null)
            {
                return false;
            }
            if (Zipcode == 0)
            {
                return false;
            }

            return true;
        }
    }
}
