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




//bool correct_paranthesis(string str)
//{
//	stack<char> stk;
//	map<char, char> bracket_map;
//	bracket_map[')'] = '(';
//	bracket_map['}'] = '{';
//	bracket_map[']'] = '[';

//	for (int i = 0; i < str.size(); i++)
//	{
//		if (str[i] == '(' || str[i] == '{' || str[i] == '[')
//			stk.push(str[i]);
//		if (str[i] == ')' || str[i] == '}' || str[i] == ']')
//		{
//			if (stk.empty())
//				return false;
//			if (stk.top() == bracket_map[str[i]])
//				stk.pop();
//		}
//	}

//	return (stk.empty() == true);
//}

//    using System;
//using System.Collections;
//public class SamplesStack
//{

//    public static void Main()
//    {

//        // Creates and initializes a new Stack.
//        Stack myStack = new Stack();
//        myStack.Push("Hello");
//        myStack.Push("World");
//        myStack.Push("!");

//        // Displays the properties and values of the Stack.
//        Console.WriteLine("myStack");
//        Console.WriteLine("\tCount:    {0}", myStack.Count);
//        Console.Write("\tValues:");
//        PrintValues(myStack);
//    }

//    public static void PrintValues(IEnumerable myCollection)
//    {
//        foreach (Object obj in myCollection)
//            Console.Write("    {0}", obj);
//        Console.WriteLine();
//    }
//}