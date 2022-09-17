using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ResturantAPI.Extensions
{
    public static class StringExtensions
    {
        public static string CapitalizeFirstChar(this string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                var value = str.Trim();
                var sb = new StringBuilder(str);
                sb[0] = char.ToUpper(sb[0]);
                return sb.ToString();
            }
            else return str;

        }
    }
}
