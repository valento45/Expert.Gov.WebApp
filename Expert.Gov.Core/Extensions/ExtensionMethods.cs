using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Gov.Core.Extensions
{
    public static class ExtensionMethods
    {


        public static string ObterTextoSimplificado(this string value, int length = 0)
        {
            string end = string.Empty;

            if (length > 0 && length <= value.Length)
            {
                end = value.Substring(0, length);
            }
            else
            {
                if (value.Length > 50)
                {
                    end = value.Substring(0, 50);
                }

                else
                    return value;
            }

            return end;
        }
    }
}
