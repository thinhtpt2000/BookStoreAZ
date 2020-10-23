namespace BookStoreAZ.Business.BusinessRules
{
    public class ValidateRequired : BusinessRule
    {
        public ValidateRequired(string property)
            : base(property)
        {
            Error = property + " is a required field";
        }

        public override bool Validate(BusinessObject businessObject)
        {
            try
            {
                return GetPropertyValue(businessObject).ToString().Length > 0; 
            }
            catch
            {
                // maybe null
                return false;
            }
        }
    }
}