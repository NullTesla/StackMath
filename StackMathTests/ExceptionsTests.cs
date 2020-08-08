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
    public class ExceptionsTests : InterpreterTests
    {

        [TestMethod()]
        public void ExceptionTest0()
        {
            Assert.ThrowsException<InvalidOperationException>(() => i.Interpret("2 +"));
        }

        [TestMethod()]
        public void ExceptionTest1()
        {
            Assert.ThrowsException<InvalidOperationException>(() => i.Interpret("+ 2"));
        }

        [TestMethod()]
        public void BracketsExceptionTest0()
        {
            Assert.ThrowsException<ArgumentException>(() => i.Interpret("2 + 3 + (2-1))"));
        }

        [TestMethod()]
        public void BracketsExceptionTest1()
        {
            Assert.ThrowsException<ArgumentException>(() => i.Interpret("2 + 3 + ((2-1)"));
        }
    }
}