using Microsoft.VisualStudio.TestTools.UnitTesting;
using Opg1;
using System;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestForfatter()
        {
            Assert.ThrowsException<ForfatterException>(()=> new Bog("Titel", "L", 100, "1234567891123"));
        }
        [TestMethod]
        public void TestSideAntalMin()
        {
            Assert.ThrowsException<SideAntalException>(() => new Bog("Titel", "Lars", 3, "1234567891123"));
        }
        [TestMethod]
        public void TestSideAntalMax()
        {
            Assert.ThrowsException<SideAntalException>(() => new Bog("Titel", "Lars", 2000, "1234567891123"));
        }
        [TestMethod]
        public void TestIsbn13()
        {
            Assert.ThrowsException<Isbn13Exception>(() => new Bog("Titel", "Lars", 100, "12"));
        }

    }
}
