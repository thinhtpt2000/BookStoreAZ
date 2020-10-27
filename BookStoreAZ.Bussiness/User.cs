using BookStoreAZ.Business.BusinessRules;
using System.Collections.Generic;

namespace BookStoreAZ.Business
{
    public class User : BusinessObject
    {
        public User()
        {
            AddRule(new ValidateId("ID"));

            AddRule(new ValidateRequired("Email"));
            AddRule(new ValidateLength("Email", 1, 256));
            AddRule(new ValidateEmail("Email"));

            AddRule(new ValidateLength("Password", 0, 256));

            AddRule(new ValidateRequired("FullName"));
            AddRule(new ValidateLength("FullName", 1, 256));

            //AddRule(new ValidateId("RoleID"));

            AddRule(new ValidateRequired("Phone"));
            AddRule(new ValidateLength("Phone", 1, 10));
            AddRule(new ValidatePhone("Phone"));

            AddRule(new ValidateRequired("Address"));
            AddRule(new ValidateLength("Address", 1, 256));
        }

        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        //public int RoleID { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; }
        public virtual Role Role { get; set; }
    }
}