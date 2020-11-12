using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMath.Tests
{
    [TestClass()]
    public class ExpressionTests : InterpreterTests
    {

        [TestMethod()]
        public void MultiplicationTest()
        {
            Assert.AreEqual(6, i.Interpret("2+2*2"));
        }

        [TestMethod()]
        public void DivisionTest()
        {
            Assert.AreEqual(3, i.Interpret("2+2/2"));
        }

        [TestMethod()]
        public void PowerTest0()
        {
            Assert.AreEqual(1<<9, i.Interpret("2^3^2"));
        }

        [TestMethod()]
        public void PowerTest1()
        {
            Assert.AreEqual(2.2, i.Interpret("2+(8-3)^-1"));
        }

        [TestMethod()]
        public void PowerTest2()
        {
            Assert.AreEqual(7, i.Interpret("2+(8-3)^--1"));
        }

        [TestMethod()]
        public void BracketsTest()
        {
            Assert.AreEqual(8, i.Interpret("(2+2)*2"));
        }

        [TestMethod()]
        public void InnerBracketsTest()
        {
            Assert.AreEqual(6, i.Interpret("3+6*(4/(7+1))"));
        }

        [TestMethod()]
        public void NegativeTest0()
        {
            Assert.AreEqual(0, i.Interpret("-5 - -2 + 3"));
        }

        [TestMethod()]
        public void NegativeTest1()
        {
            Assert.AreEqual(-7, i.Interpret("-5 ---2"));
        }

        [TestMethod()]
        public void NegativeAndPowerTest()
        {
            Assert.AreEqual(-4, i.Interpret("-2^2"));
        }

        [TestMethod()]
        public void FunctionTest0()
        {
            Assert.AreEqual(1, i.Interpret("sin(1)^2+cos(1)^2"));
        }

        [TestMethod()]
        public void FunctionTest1()
        {
            Assert.AreEqual(Math.Sin(2+3), i.Interpret("sin(2)*cos(3)+cos(2)*sin(3)"));
        }

        [TestMethod()]
        public void FunctionTest2()
        {
            Assert.AreEqual(Math.Tan(5), i.Interpret("sin(5)/cos(5)"));
        }

        [TestMethod()]
        public void FunctionTest3()
        {
            Assert.AreEqual(Math.Pow(17, Math.Cos(0)), i.Interpret("17^cos(0)"));
        }

        [TestMethod()]
        public void FunctionTest4()
        {
            Assert.AreEqual(3, i.Interpret("log(8, 2)"));
        }

        [TestMethod()]
        public void ConstantTest0()
        {
            Assert.AreEqual(Math.Sin(Math.PI/6), i.Interpret("sin(pi/6)"));
        }

        [TestMethod()]
        public void VariablesTest0()
        {
            i.Interpret("a = 5");
            i.Interpret("b = 3");
            Assert.AreEqual(8, i.Interpret("a + b"));
        }

        [TestMethod()]
        public void VariablesTest1()
        {
            i.Interpret("a = sin(pi/4)");
            i.Interpret("b = 2^(1/2)");
            Assert.AreEqual(1, i.Interpret("a * b"));
        }

        [TestMethod()]
        public void VariablesTest2()
        {
            i.Interpret("a = cos(0)");
            i.Interpret("b = a");
            Assert.AreEqual(0, i.Interpret("a - b"));
        }

        [TestMethod()]
        public void VariablesTest3()
        {
            i.Interpret("a = cos(0)");
            i.Interpret("b = a - 6");
            Assert.AreEqual(6, i.Interpret("a - b"));
        }
    }
}