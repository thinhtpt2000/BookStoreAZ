using BookStoreAZ.Bussiness.BusinessRules;
using System.Collections.Generic;

namespace BookStoreAZ.Bussiness
{
    public abstract class BusinessObject
    {
        private List<BusinessRule> BusinessRules = new List<BusinessRule>();

        private List<string> errors;

        public List<string> Errors
        {
            get { return errors; }
        }

        protected void AddRule(BusinessRule rule)
        {
            BusinessRules.Add(rule);
        }
    }
}