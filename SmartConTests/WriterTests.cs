using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace SmartConTests
{
    [TestClass]
    public class WriterTests
    {
        [TestMethod]
        public void WriterMustNotThrowOnInvalidFormat()
        {
            var hasThrown = false;
            try
            {
                var con = new SmartConsole();
                con.WriteLine("{");
            }
            catch (Exception)
            {
                hasThrown = true;
            }
            Assert.IsFalse(hasThrown);
        }
    }
}