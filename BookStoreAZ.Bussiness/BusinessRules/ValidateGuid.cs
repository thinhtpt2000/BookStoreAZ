using BookStoreAZ.Business;
using BookStoreAZ.Business.BusinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAZ.Bussiness.BusinessRules
{
    public class ValidateGuid : BusinessRule
    {
        public ValidateGuid(string property)
           : base(property)
        {
            Error = $"{property} is an invalid Guid";
        }

        public override bool Validate(BusinessObject businessObject)
        {
            try
            {
                Guid guid = Guid.Parse(GetPropertyValue(businessObject).ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
