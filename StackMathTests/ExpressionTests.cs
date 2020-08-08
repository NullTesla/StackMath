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
    }
}