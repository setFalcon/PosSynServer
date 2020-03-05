using System;
using NUnit.Framework;
using SQLTest.domain;

namespace SQLTest {
    [TestFixture]
    public class Tests {
        [Test]
        public void UsersDomainTest() {
            Users u = new Users(1L, "qqq", "aaa");
            Console.WriteLine(u);
        }
    }
}