using System;
using ConnectBridge.Util;
using NUnit.Framework;
using SQLTest.dao;
using SQLTest.dao.impl;
using SQLTest.domain;
using SQLTest.util;

namespace SQLTest {
    [TestFixture]
    public class Tests {
        [Test]
        public void UsersDomainTest() {
            Users u = new Users("qqq", "aaa");
            Console.WriteLine(u);
        }

        [Test]
        public void MD5UilTest() {
            bool result = MD5Util.VerifyPassword("123456", "e10adc3949ba59abbe56e057f20f883e");
            Assert.AreEqual(result, true);
        }

        [Test]
        public void RegisterUserTest() {
            IUserDAO userDao = new IUserDAOImpl();
            bool result = userDao.Register(new Users("falcon", MD5Util.GetMD5("123456")));
            Assert.AreEqual(true, result);
        }

        [Test]
        public void VerifyUserTest() {
            IUserDAO userDao = new IUserDAOImpl();
            bool result = userDao.Verify(new Users("falcon", MD5Util.GetMD5("123456")));
            Assert.AreEqual(true, result);
        }
    }
}