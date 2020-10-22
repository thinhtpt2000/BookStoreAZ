namespace BookStoreAZ.Bussiness.BusinessRules
{
    public class ValidateEmail : ValidateRegex
    {
        public ValidateEmail(string property)
                : base(property, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
        {
            Error = property + " is an invalid email";
        }
    }
}