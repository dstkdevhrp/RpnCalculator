using Microsoft.VisualStudio.TestTools.UnitTesting;
using RpnCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpnCalculator.Tests
{
    [TestClass()]
    public class RpnExpressionTests
    {
        [TestMethod()]
        public void isOperatorTest()
        {
            RpnExpression re = new RpnExpression();
            Assert.IsTrue(re.isOperator("+"));
            Assert.IsTrue(re.isOperator("-"));
            Assert.IsTrue(re.isOperator("*"));
            Assert.IsTrue(re.isOperator("/"));
            Assert.IsFalse(re.isOperator("("));
            Assert.IsFalse(re.isOperator(")"));
        }

        [TestMethod()]
        public void isFloatTest()
        {
            RpnExpression re = new RpnExpression();
            Assert.IsTrue(re.isDouble("-1"));
            Assert.IsTrue(re.isDouble("0.01"));
            Assert.IsTrue(re.isDouble("100"));
            Assert.IsFalse(re.isDouble("/"));
        }

        [TestMethod()]
        public void validInputTest()
        {
            RpnExpression re = new RpnExpression();
            Assert.IsTrue(re.validInput("-1,0.01,+"));
            Assert.IsTrue(re.validInput("0.01,     9,    *"));
            Assert.IsTrue(re.validInput("100, 200, 2000, -, +"));
            Assert.IsTrue(re.validInput("-, 100, 200"));
            Assert.IsTrue(re.validInput("101,+ , 100, 200, *"));
            Assert.IsFalse(re.validInput("100, 200, -90, -, -, 100, 200"));
        }

        [TestMethod()]
        public void calculateTest()
        {
            RpnExpression re = new RpnExpression();
            Assert.AreEqual(300, re.calculate(100, 200, "+"));
            Assert.AreEqual(-100, re.calculate(100, 200, "-"));
            Assert.AreEqual(0.0693, re.calculate(0.33, 0.21, "*"));
            Assert.AreEqual(0.4, re.calculate(2, 5, "/"));
        }

        [TestMethod()]
        public void calculateTest1()
        {
            RpnExpression re = new RpnExpression("100, 200, 300, -, +");
            Assert.AreEqual(0, re.calculate());
            re = new RpnExpression("100, 20, 200, -, 30, /, 50, *, +");
            Assert.AreEqual(-200, re.calculate());
        }
    }
}