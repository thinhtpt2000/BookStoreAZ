using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAZ.Business.BusinessRules
{
    public class ValidateQuantity : BusinessRule
    {
        public ValidateQuantity(string property)
           : base(property)
        {
            Error = property + " is an invalid quantity";
        }

        public override bool Validate(BusinessObject businessObject)
        {
            int quantity;
            bool isValid = int.TryParse(GetPropertyValue(businessObject).ToString(), out quantity);
            return (isValid && quantity >= 0);
        }
    }
}
