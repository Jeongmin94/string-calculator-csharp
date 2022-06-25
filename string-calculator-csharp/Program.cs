using string_calculator_csharp;

StringCalculator stringCalculator = new StringCalculator();
string expression = "//;\\n1;2;3";
string baseExpr = "1,2,3";
string minusExpr = "-1,2,3";

Console.WriteLine(stringCalculator.parseExpression(expression));
Console.WriteLine(stringCalculator.parseExpression(baseExpr));
Console.WriteLine(stringCalculator.parseExpression(minusExpr));
