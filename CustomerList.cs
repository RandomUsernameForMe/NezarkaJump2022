using NezarkaBookstoreWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpingPlatformGame
{
    class CustomerList
    {
        string name;
        DateTime? date_joined;

        public static explicit operator CustomerList(Customer other)
        {
            CustomerList return_value = new CustomerList();
            return_value.name = string.Format("{0} {1}", other.FirstName, other.LastName);
            return_value.date_joined = other.DateJoined;
            return return_value;
        }
        public override string ToString()
        {
            return name;
        }


    }
}
