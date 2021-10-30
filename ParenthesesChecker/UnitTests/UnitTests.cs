using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParenthesesChecker;

namespace UnitTests
{
    [TestClass]
    public class UnitTests    {
        [TestMethod]
        public void AreParenthesesProperlyBalanced_ReturnsTrueForBalancedString()
        {
            string lispString = "(((())))";
            ParenthesesBalanceChecker checker = new ParenthesesBalanceChecker(lispString);
            Assert.IsTrue(checker.AreParenthesesProperlyBalanced());
        }

        [TestMethod]
        public void AreParenthesesProperlyBalanced_ReturnsTrueForBalancedString2()
        {
            string lispString = "((stuff)(stuff2)((())))";
            ParenthesesBalanceChecker checker = new ParenthesesBalanceChecker(lispString);
            Assert.IsTrue(checker.AreParenthesesProperlyBalanced());
        }

        [TestMethod]
        public void AreParenthesesProperlyBalanced_ReturnsFalseForUnBalancedString()
        {
            string lispString = "(((()))";
            ParenthesesBalanceChecker checker = new ParenthesesBalanceChecker(lispString);
            Assert.IsFalse(checker.AreParenthesesProperlyBalanced());
        }

        [TestMethod]
        public void AreParenthesesProperlyBalanced_ReturnsFalseForUnBalancedString2()
        {
            string lispString = "((()";
            ParenthesesBalanceChecker checker = new ParenthesesBalanceChecker(lispString);
            Assert.IsFalse(checker.AreParenthesesProperlyBalanced());
        }

    }
}



