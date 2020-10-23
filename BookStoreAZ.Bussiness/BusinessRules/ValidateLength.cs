namespace BookStoreAZ.Business.BusinessRules
{
    internal class ValidateLength : BusinessRule
    {
        private int _minLength;
        private int _maxLength;

        public ValidateLength(string property, int minLength, int maxLength)
            : base(property)
        {
            _minLength = minLength;
            _maxLength = maxLength;
            Error = $"{property} is must be between {minLength} and {maxLength} chars";
        }

        public override bool Validate(BusinessObject businessObject)
        {
            int length = GetPropertyValue(businessObject).ToString().Length;
            return (length >= _minLength && length <= _maxLength);
        }
    }
}