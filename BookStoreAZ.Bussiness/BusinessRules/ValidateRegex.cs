using System.Text.RegularExpressions;

namespace BookStoreAZ.Business.BusinessRules
{
    public class ValidateRegex : BusinessRule
    {
        protected string RegexPattern { get; set; }

        public ValidateRegex(string property, string regexPattern)
            : base(property)
        {
            RegexPattern = regexPattern;
        }

        public override bool Validate(BusinessObject businessObject)
        {
            return Regex.Match(GetPropertyValue(businessObject).ToString(), RegexPattern).Success;
        }
    }
}