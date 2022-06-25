using System.Diagnostics;
using System.Text.RegularExpressions;

namespace string_calculator_test
{
    [TestClass]
    public class StringCalculatorTest
    {
        private readonly Regex regex = new Regex(@"//(.*)\\n(.*)");
        private readonly string customDelimExpression = "//;\\n1;2;3";
        private readonly string baseDelimExpression = "1,2,3";

        [TestMethod]
        public void base_delim_test()
        {
            char[] baseDelim = { ',', ':' };

            string[] actual = baseDelimExpression.Split(baseDelim);
            string[] expected = { "1", "2", "3" };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void custom_delim_test()
        {
            MatchCollection matches = regex.Matches(customDelimExpression);

            string customDelim = matches[0].Groups[1].Value;
            string nums = matches[0].Groups[2].Value;

            Debug.WriteLine($"Custom Delim {customDelim}");
            Debug.WriteLine($"Nums {nums}");
        }

        [TestMethod]
        public void none_custom_delim_test()
        {
            //string 
            MatchCollection nonMathces = regex.Matches(baseDelimExpression);

            foreach(Match match in nonMathces)
            {
                GroupCollection group = match.Groups;

                Debug.WriteLine(group.Count);
            }
        }
    }
}
