using System;

namespace SimpleCalculatorProject
{
    public static class SimpleCalculator
    {
        public static double Addition(double firstNumber, double secondNumber)
        {
            return Math.Round(firstNumber + secondNumber, 2);
        }
        public static double Subtraction(double firstNumber, double secondNumber)
        {
            return Math.Round(firstNumber - secondNumber, 2);
        }
        public static double Multiplication(double firstNumber, double secondNumber)
        {
            return Math.Round(firstNumber * secondNumber, 2);
        }
        public static double Division(double firstNumber, double secondNumber)
        {
            return Math.Round(firstNumber / secondNumber, 2);
        }
    }
}
