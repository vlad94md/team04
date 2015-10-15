using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    //[TestClass]
    //class TweetsDaoTests
    //{
    //    private Mock<ITweetsDao> tweetMock;
    //    private Mock<IUserDao> userMock;
    //    ITweetsDao tweetDao;

    //    [TestInitialize]
    //    public void Initialize()
    //    {
    //        tweetMock = new Mock<ITweetsDao>();
    //        userMock = new Mock<IUserDao>();
    //        tweetDao = new TweetsDao(userMock.Object);
    //    }

    //    [TestMethod]
    //    public void Add_NewTweet_True()
    //    {
    //        User newuser = new User()
    //        {
    //            FullName = "Jora Ivanov",
    //            Email = "pumc@gmail.com",
    //            Passwrd = "123",
    //            Username = "JorJoraJora"
    //        };
    //        userDao.Add(newuser);

    //        Tweet newTweet = new Tweet()
    //        {
    //            Body = "HELLO!",
    //            Date_time = DateTime.Now,
    //            User_Id = newuser.Id
    //        };


    //        var Actual = tweetDao.Add(newTweet);

    //        tweetDao.Delete(newTweet);
    //        userDao.Delete(newuser);

    //        Assert.IsTrue(Actual);
    //    }
    //}
}
