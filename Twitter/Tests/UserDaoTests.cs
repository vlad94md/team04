using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using DAL.Entities;
namespace Tests
{
    [TestClass]
    public class UserDaoTests
    {
        //MethodName_StateUnderTest_ExpectedBehavior convention

        [TestMethod]
        public void Add_NewUser_True()
        {
            //arrange
            var userDao = new UserDao();

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
    }
}
