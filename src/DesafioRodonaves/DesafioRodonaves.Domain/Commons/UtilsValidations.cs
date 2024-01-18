using System.Text.RegularExpressions;

namespace DesafioRodonaves.Domain.Commons
{
    public class UtilsValidations
    {
        public static bool ContainsWhitespace(string value)
        {
            // verificar se o valor passado contém espaço em branco no começo ou no final da informação
            if (value == null) return false;

            return Regex.IsMatch(value, @"^\s|\s$") ? true : false;
        }
    }
}
