using System;
using NUnit.Framework;
using SQLTest.domain;
using SQLTest.util;

namespace SQLTest {
    [TestFixture]
    public class Tests {
        [Test]
        public void UsersDomainTest() {
            Users u = new Users(1L, "qqq", "aaa");
            Console.WriteLine(u);
        }

        [Test]
        public void MD5UilTest() {
            bool result = MD5Util.VerifyPassword("123456","e10adc3949ba59abbe56e057f20f883e");
            Assert.AreEqual(result,true);
        }
    }
}