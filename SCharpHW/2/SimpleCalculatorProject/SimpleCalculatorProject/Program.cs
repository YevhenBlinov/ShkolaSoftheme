using System;
using System.Linq;

namespace SimpleCalculatorProject
{
    class Program
    {
        private readonly static char[] SimpleMathematicalOperators = {'+', '-', '*', '/'};
        private static readonly char[] Separators = {'+', '-', '*', '/', ' '};

        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter operation to do in this way: firstNumber mathematicalOperator secondNumber");
            var operation = Console.ReadLine();

            double result;
            try
            {
                result = GetResultFromEnteredOperation(operation);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Console.WriteLine(operation + " = {0}", result);
            
        }

        private static double GetResultFromEnteredOperation(string operation)
        {
            var numbers = GetNumbersArrayFromEnteredOperation(operation);
            double firstNumber, secondNumber;
            if (numbers.Length != 2 || !double.TryParse(numbers[0], out firstNumber) || !double.TryParse(numbers[1], out secondNumber))
            {
                throw new Exception("Numbers must be type of double.");
            }
            var mathematicalOperator = GetMathematicalOperatorFromEnteredOperation(operation);

            switch (mathematicalOperator)
            {
                case "-":
                    return SimpleCalculator.Subtraction(firstNumber, secondNumber);
                case "*":
                    return SimpleCalculator.Multiplication(firstNumber, secondNumber);
                case "/":
                    return SimpleCalculator.Division(firstNumber, secondNumber);
                default:
                    return SimpleCalculator.Addition(firstNumber, secondNumber);
            }
        }

        private static string[] GetNumbersArrayFromEnteredOperation(string operation)
        {
            return operation.Split(Separators).Where(num => !string.IsNullOrWhiteSpace(num)).ToArray();
        }

        private static string GetMathematicalOperatorFromEnteredOperation(string operation)
        {
            return
                SimpleMathematicalOperators.Where(
                    simpleMathematicalOperator => operation.Contains(simpleMathematicalOperator)).First().ToString();
        }
    }
}
