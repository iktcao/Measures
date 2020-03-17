using System.Globalization;
using System.Windows.Controls;

namespace Measures.Helper
{
    public class NumericRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str = (string)value;
            string str2 = str + "0";
            string str3 = "0" + str;
            string str4 = "0" + str + "0";

            double dbl;

            if (!double.TryParse(str, out dbl))
            {
                if (!double.TryParse(str2, out dbl))
                {
                    if (!double.TryParse(str3, out dbl))
                    {
                        if (!double.TryParse(str4, out dbl))
                            return new ValidationResult(false, "输入有误！");
                    }
                }
            }
            return new ValidationResult(true, null);
        }
    }

    public class AtmRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str = (string)value;
            double dbl;

            if (double.TryParse(str, out dbl))
            {
                if (dbl < 0)
                {
                    return new ValidationResult(false, "输入不能为负数！");
                }
            }
            return new ValidationResult(true, null);
        }
    }
    public class RhoRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str = (string)value;
            double dbl;

            if (double.TryParse(str, out dbl))
            {
                if (dbl <= 0)
                {
                    return new ValidationResult(false, "输入不能为零或负数！");
                }
            }
            return new ValidationResult(true, null);
        }
    }


}
