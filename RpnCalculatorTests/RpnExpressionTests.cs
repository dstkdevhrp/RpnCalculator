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
            // Only +, -, *, / available
            Assert.IsTrue(re.isOperator("+"));
            Assert.IsTrue(re.isOperator("-"));
            Assert.IsTrue(re.isOperator("*"));
            Assert.IsTrue(re.isOperator("/"));
            // Any others unavailable
            Assert.IsFalse(re.isOperator("("));
            Assert.IsFalse(re.isOperator(")"));
        }

        [TestMethod()]
        public void isDoubleTest()
        {
            RpnExpression re = new RpnExpression();
            // Integer is ok to both ',' and '.'
            Assert.IsTrue(re.isDouble("-1", '.'));
            Assert.IsTrue(re.isDouble("100", '.'));
            // Double need to judge if ',' or '.'
            Assert.IsTrue(re.isDouble("0.01", '.'));
            Assert.IsFalse(re.isDouble("0.01", ','));
            Assert.IsTrue(re.isDouble("0,01", ','));
            Assert.IsFalse(re.isDouble("0,01", '.'));
            // Operator should false for both ',' and '.'
            Assert.IsFalse(re.isDouble("/", ','));
            Assert.IsFalse(re.isDouble("/", '.'));
        }

        [TestMethod()]
        public void validInputTest()
        {
            RpnExpression re = new RpnExpression();
            // Space array is ok
            Assert.IsTrue(re.validInput("-1    0.01 +", '.'));
            Assert.IsTrue(re.validInput("-1    0,01 +", ','));
            Assert.IsTrue(re.validInput("2,5 5 /", ','));
            Assert.IsTrue(re.validInput("2.5 5 /", '.'));
            // Numbers of operator and digi is not different with 1
            Assert.IsFalse(re.validInput("-1  200   0,01 +", ','));
            Assert.IsTrue(re.validInput("-1  200   0,01 + -", ','));
            // Incorrect & Correct operator
            Assert.IsFalse(re.validInput("-1  200   0,01 + %", ','));
            Assert.IsTrue(re.validInput("-1  200   0,01 + *", ','));
            // Operator incorrect position
            Assert.IsFalse(re.validInput(" - -1  200   0,01 + ", ','));
            Assert.IsFalse(re.validInput("-1  -  200   0,01  *", ','));
            Assert.IsTrue(re.validInput(" -1  200   0,01 / + ", ','));
            Assert.IsTrue(re.validInput("-1     200   0,01  * /", ','));
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
            // Integer
            RpnExpression re = new RpnExpression("100  200  300  -  +", '.');
            Assert.AreEqual(0, re.calculate());
            re = new RpnExpression("100  20  200  -  30  /  50  *  +", '.');
            Assert.AreEqual(-200, re.calculate());
            re = new RpnExpression("100  200  300  -  +", ',');
            Assert.AreEqual(0, re.calculate());
            re = new RpnExpression("100  20  200  -  30  /  50  *  +", ',');
            Assert.AreEqual(-200, re.calculate());
            // Double
            re = new RpnExpression("10,2  12,5  10  -  0,5  /  50  *  +", ',');
            Assert.AreEqual(260.2, re.calculate());
            re = new RpnExpression("10.2  12.5  10  -  0.5  /  50  *  +", '.');
            Assert.AreEqual(260.2, re.calculate());
        }
    }
}