namespace BookStoreAZ.Bussiness.BusinessRules
{
    public class ValidateId : BusinessRule
    {
        public ValidateId(string property)
            : base(property)
        {
            Error = property + " is an invalid ID";
        }

        public override bool Validate(BusinessObject businessObject)
        {
            int id;
            bool isValid = int.TryParse(GetPropertyValue(businessObject).ToString(), out id);
            return (isValid && id >= 0);
        }
    }
}