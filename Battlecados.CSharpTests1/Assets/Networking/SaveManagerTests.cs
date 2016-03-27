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
            string username = "testing";
            string password = "testing";
            User user = null;
            SaveManager savemgr = new SaveManager();

            // Act
            bool result = SaveManager.TryLogIn(username, password, out user);
            Assert.Fail();
        }
    }
}