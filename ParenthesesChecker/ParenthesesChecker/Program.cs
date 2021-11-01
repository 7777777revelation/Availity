using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;

namespace ParenthesesChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            // Type your LISP string and press enter
            Console.WriteLine("Enter LISP string to be checked:");

            // Create a string variable and get user input from the keyboard and store it in the variable
            string lispString = Console.ReadLine();

            ParenthesesBalanceChecker checker = new ParenthesesBalanceChecker(lispString);
            bool areBalanced = checker.AreParenthesesProperlyBalanced();
            if (areBalanced)
                Console.WriteLine("Parentheses are balanced.");
            else
                Console.WriteLine("Parentheses are not balanced.");

            Thread.Sleep(3000);
        }


    }
}

