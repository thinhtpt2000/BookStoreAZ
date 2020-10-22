using System;

namespace BookStoreAZ.Bussiness.BusinessRules
{
    public class ValidateRange : BusinessRule
    {
        private ValidationDataType _dataType { get; set; }

        private object _minValue;
        private object _maxValue;

        public ValidateRange(string property, object minValue, object maxValue, ValidationDataType dataType)
            : base(property)
        {
            _minValue = minValue;
            _maxValue = maxValue;
            _dataType = dataType;
            Error = $"{property} must be between {_minValue} and {_maxValue}";
        }

        public override bool Validate(BusinessObject businessObject)
        {
            try
            {
                string value = GetPropertyValue(businessObject).ToString();

                switch (_dataType)
                {
                    case ValidationDataType.Date:
                        DateTime tMin = DateTime.Parse(_minValue.ToString());
                        DateTime tMax = DateTime.Parse(_maxValue.ToString());
                        DateTime tVal = DateTime.Parse(value);
                        return (tVal >= tMin && tVal <= tMax);

                    case ValidationDataType.Decimal:
                        decimal cMin = decimal.Parse(_minValue.ToString());
                        decimal cMax = decimal.Parse(_maxValue.ToString());
                        decimal cVal = decimal.Parse(value);
                        return (cVal >= cMin && cVal <= cMax);

                    case ValidationDataType.Double:
                        double dMin = double.Parse(_minValue.ToString());
                        double dMax = double.Parse(_maxValue.ToString());
                        double dVal = double.Parse(value);
                        return (dVal >= dMin && dVal <= dMax);

                    case ValidationDataType.Integer:
                        int iMin = int.Parse(_minValue.ToString());
                        int iMax = int.Parse(_maxValue.ToString());
                        int iVal = int.Parse(value);
                        return (iVal >= iMin && iVal <= iMax);

                    case ValidationDataType.String:
                        string sMin = _minValue.ToString();
                        string sMax = _maxValue.ToString();

                        bool rMin = value.CompareTo(sMin) >= 0;
                        bool rMax = value.CompareTo(sMax) <= 0;
                        return (rMin && rMax);
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}