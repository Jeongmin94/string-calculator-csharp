using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace string_calculator_csharp
{
    internal class StringCalculator
    {
        private readonly Regex regex = new Regex(@"//(.*)\\n(.*)");
        private char[] delim = {',', ':'};

        public int parseExpression(string expression)
        {
            MatchCollection matchCollection = regex.Matches(expression);
            char[] delimeters = delim;

            if(matchCollection.Count != 0)
            {
                delimeters = parseCustomDelim(matchCollection);
                expression = parseExpr(matchCollection);
            }

            List<int> splitedNums = expression.Split(delimeters).Select(int.Parse).ToList();
            int sum = 0;
            splitedNums.ForEach(x =>
            {
                if (x < 0)
                {
                    throw new InvalidDataException($"Minus number is not allowed here - {x}");
                }
                sum += x;
            });

            return sum;
        }

        private char[] parseCustomDelim(MatchCollection matchCollection)
        {
            return matchCollection[0].Groups[1].Value.ToCharArray();
        }

        private string parseExpr(MatchCollection matchCollection)
        {
            return matchCollection[0].Groups[2].Value;
        }
    }
}
