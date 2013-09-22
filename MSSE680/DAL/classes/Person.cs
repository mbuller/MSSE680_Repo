using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSE680.DAL
{
    public partial class Person
    {

        /**
         * byte Age
         * String FirstName
         * String LastName
         * String Password
         */
        public Person(
                    int PersonId,
                    byte Age,
                    String FirstName,
                    String LastName,
                    String UserName,
                    Address Address)
        {

            this.PersonId = PersonId;
            this.Age = Age;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.UserName = UserName;
            this.Password = "Password1";
            this.Address = Address;
            this.Address_AddressId = Address.AddressId;
        }


        /**
         * byte Age
         * String FirstName
         * String LastName
         * String Password
         */
        public Person(
                    byte Age,
                    String FirstName,
                    String LastName,
                    String UserName,
                    Address Address)
        {
            this.Age = Age;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.UserName = UserName;
            this.Password = "Password1";
            this.Address = Address;
            this.Address_AddressId = Address.AddressId;
        }

        /**
        * byte Age
        * String FirstName
        * String LastName
        * String Password
        * Address Address
        */
        public Person(
                    byte Age,
                    String FirstName,
                    String LastName,
                    String UserName,
                    String Password,
                    byte Permissions,
                    Address Address)
        {
            this.Age = Age;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.UserName = UserName;
            this.Password = Password;
            this.Permissions = Permissions;
            this.Address = Address;
            this.Address_AddressId = Address.AddressId;
        }

        /**
         * byte Age
         * String FirstName
         * String LastName
         * String UserName
         * String Password
         */
        public Person(
                    byte Age,
                    String FirstName,
                    String LastName,
                    String UserName,
                    String Password,
                    byte Permissions)
        {

            this.Age = Age;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.UserName = UserName;
            this.Password = Password;
            this.Permissions = Permissions;
        }

        /**
         * int PersonId
         * byte Age
         * String FirstName
         * String LastName
         * String UserName
         * String Password
         * Address Address
         */
        public Person(
                    int PersonId,
                    byte Age,
                    String FirstName,
                    String LastName,
                    String UserName,
                    String Password,
                    byte Permissions,
                    Address Address)
        {

            this.PersonId = PersonId;
            this.Age = Age;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.UserName = UserName;
            this.Password = Password;
            this.Permissions = Permissions;
            this.Address = Address;
            this.Address_AddressId = Address.AddressId;
        }

        /**
         * Validate if the instance variables are valid
         *
         *  bool - true if instance variables are valid, else false
         */
        public bool validate()
        {
            if (PersonId < 0)
            {
                return false;
            }
            if (LastName == null)
            {
                return false;
            }
            if (FirstName == null)
            {
                return false;
            }
            if (UserName == null)
            {
                return false;
            }
            if (Password == null)
            {
                return false;
            }
            if (Age == 0)
            {
                return false;
            }
            if (Address.validate() == false)
            {
                return false;
            }

            return true;
        }
    }
}
