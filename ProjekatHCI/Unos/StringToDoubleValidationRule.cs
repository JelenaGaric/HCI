using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjekatHCI.Unos
{

    public class StringToDoubleValidationRule : ValidationRule
    {
        public static int flag = 0;
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string err = "Neispravan unos!".PadLeft(1);
            try
            {
                var s = value as string;
                if (String.IsNullOrWhiteSpace(s))
                {
                    return new ValidationResult(false, err);
                }
                Regex r = new Regex(@"^[šŠđĐčČćĆžŽa-zA-Z0-9_' ']+$");
                if (!r.IsMatch(s))
                {
                    flag = 1;

                    return new ValidationResult(false, err);
                }else
                
                return new ValidationResult(true, null);
            }
            catch
            {
                flag = 1;
                return new ValidationResult(false, "Neispravan unos.");
            }
        }
    }
    
}
