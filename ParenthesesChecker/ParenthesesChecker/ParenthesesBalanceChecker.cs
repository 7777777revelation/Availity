using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ParenthesesChecker
{
    /// <summary>
    /// Class used to check LISP expressions to make sure parentheses are properly balanced
    /// </summary>
    public class ParenthesesBalanceChecker
    {
        private string _lispString;

        public ParenthesesBalanceChecker(string lispString)
        {
            _lispString = lispString;
        }

        /// <summary>
        /// Check the LISP string that was passed in the constructor and make sure the parentheses are properly balanced.
        /// </summary>
        /// <returns></returns>
       public bool AreParenthesesProperlyBalanced()
        {
            Stack lispStack = new Stack();

            for (int i = 0; i < _lispString.Length; i++)
            {
                if (_lispString[i] == '(')
                {
                    lispStack.Push(_lispString[i]);
                }

                if (_lispString[i] == ')')
                {
                    if (lispStack.Count == 0)
                    {
                        return false;
                    }

                    if (((char)lispStack.Peek()) == '(')
                        lispStack.Pop();
                }
            }

            if (lispStack.Count == 0)
                return true;
            else
                return false;
        }
    }
}
