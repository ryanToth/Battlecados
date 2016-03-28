using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assets.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Networking.Tests
{
    [TestClass()]
    public class SaveManagerTests
    {
        [TestMethod()]
        public void TryLogInTest()
        {
            // Arrange
            string username = "estingt";
            string password = "testing";
            User user;

            // Act
            bool result = SaveManager.TryLogIn(username, password, out user);

            // Assert
            Assert.Fail();
        }

        [TestMethod()]
        public void TryCreateNewUserTest()
        {
            // Arrange
            string username = "jhfjsdfgjhhgffsd";
            string password = "b";
            User user;

            // Act
            bool result = SaveManager.TryCreateNewUser(username, password, out user);

            // Assert
            Assert.IsTrue(result);
        }
    }
}