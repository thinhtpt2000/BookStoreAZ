namespace BookStoreAZ.Business.BusinessRules
{
    public abstract class BusinessRule
    {
        public string Property { get; set; }

        public string Error { get; set; }

        protected BusinessRule(string property)
        {
            Property = property;
            Error = property + " is not valid";
        }

        public abstract bool Validate(BusinessObject businessObject);

        protected object GetPropertyValue(BusinessObject businessObject)
        {
            return businessObject.GetType().GetProperty(Property).GetValue(businessObject, null);
        }
    }
}