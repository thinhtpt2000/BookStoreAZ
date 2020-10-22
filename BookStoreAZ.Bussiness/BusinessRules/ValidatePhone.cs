namespace BookStoreAZ.Bussiness.BusinessRules
{
    public class ValidatePhone : ValidateRegex
    {
        public ValidatePhone(string property)
            : base(property, @"(03|07|08|09|01[2|6|8|9])+([0-9]{8})$")
        {
            Error = property + " is an invalid phone number";
        }
    }
}