namespace BookStoreAZ.Bussiness.BusinessRules
{
    public class ValidatePrice : BusinessRule
    {
        public ValidatePrice(string property)
           : base(property)
        {
            Error = property + " is an invalid price";
        }

        public override bool Validate(BusinessObject businessObject)
        {
            int price;
            bool isValid = int.TryParse(GetPropertyValue(businessObject).ToString(), out price);
            int mod = price % 1000;
            return (isValid && price > 0 && mod == 0);
        }
    }
}