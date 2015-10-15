using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using DAL.Entities;
using Moq;
namespace Tests
{
    [TestClass]
    public class UserDaoTests
    {
        //MethodName_StateUnderTest_ExpectedBehavior convention
        UserDao userDao;

        [TestInitialize]
        public void Initialize()
        {
            userDao = new UserDao();
        }

        [TestMethod]
        public void Add_NewUser_True()
        {
            //arrange

            //act
            User newuser = new User()
            {
                FullName = "Vlad Guleaev",
                Email = "vladg@gmail.com",
                Passwrd = "123",
                Username = "testUser"
            };

            bool actual = userDao.Add(newuser);

            //assert
            Assert.AreEqual(true, actual);

            //delete
            userDao.Delete(newuser);
        }

        [TestMethod]
        public void IsNull_UserIsNull_False()
        {
            //arrange

            //act
            User Expected = new User();
            Expected = null;

            var Actual = userDao.Add(Expected);
            //assert
            Assert.IsFalse(Actual);
        }

        [TestMethod]
        public void Delete_UserIsDeleted_True()
        {
            //act
            User Expected = new User()
            {
                FullName = "Vlad Guleaev",
                Email = "vladg@gmail.com",
                Passwrd = "123",
                Username = "testUser"
            };

            userDao.Add(Expected);


            var Actual = userDao.Delete(Expected);

            Assert.IsTrue(Actual);
        }

        [TestMethod]
        public void GetByUserName_returnUser_User()
        {
            User Expected = new User()
            {
                FullName = "Vlad Guleaev",
                Email = "vladg@gmail.com",
                Passwrd = "123",
                Username = "testUser"
            };
            userDao.Add(Expected);

            var Actual = userDao.GetByUsername(Expected.Username);

            userDao.Delete(Expected);
            //assert
            Assert.IsNotNull(Actual);
        }

        [TestMethod]
        public void GetById_returnUser_User()
        {
            User newuser = new User()
            {
                FullName = "Vlad Guleaev",
                Email = "vladg@gmail.com",
                Passwrd = "123",
                Username = "testUser"
            };

            userDao.Add(newuser);

            var Actual = userDao.GetById(newuser.Id);

            userDao.Delete(newuser);

            Assert.IsNotNull(Actual);
        }

    }
}
