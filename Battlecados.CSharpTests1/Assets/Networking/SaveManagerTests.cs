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
            string username = "jhhgffsd";
            string password = "b";
            User user;

            // Act
            bool result = SaveManager.TryCreateNewUser(username, password, out user);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void TryGoToNextLevelTest()
        {
            // Arrange
            int userCode = 50;
            int storyLevel = 3;

            // Act
            bool result = SaveManager.TryGoToNextLevel(userCode, storyLevel);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void TrySaveBattleResultsTest()
        {
            // Arrange
            int userCode = 50;
            int avocadoLevel = 45;
            int avocadoExperiencePoints = 80;
            int gold = 900;

            // Act
            bool result = SaveManager.TrySaveBattleResults(userCode, avocadoLevel, avocadoExperiencePoints, gold);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void TryBuyPackTest()
        {
            // Arrange
            int userCode = 50;
            int numberOfBronzePacks = 5;
            int numberOfSilverPacks = 3;
            int numberOfGoldPacks = 2;
            int gold = 300;

            // Act
            bool result = SaveManager.TryBuyPack(userCode, numberOfBronzePacks, numberOfSilverPacks, numberOfGoldPacks, gold);

            // Assert
            Assert.IsTrue(result);
        }

        /*[TestMethod()]
        public void TryOpenPackTest()
        {
            // Arrange
            int userCode = 50;
            int numberOfBronzePacks = 5;
            int numberOfSilverPacks = 3;
            int numberOfGoldPacks = 2;
            List<Card> cardCollection = new List<Card>(new Card[] { 1, 2, 3 });
            // Act
            bool result = SaveManager.TryOpenPack(userCode, numberOfBronzePacks, numberOfSilverPacks, numberOfGoldPacks, cardCollection);

            // Assert
            Assert.IsTrue(result);
        }*/

        [TestMethod()]
        public void TryEquipCardToAvocadoTest()
        {
            // Arrange
            int userCode = 50;
            int cardID = 1;

            // Act
            bool result = SaveManager.TryEquipCardToAvocado(userCode, cardID);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void TryUnequipCardToAvocadoTest()
        {
            // Arrange
            int userCode = 50;
            int cardID = 1;

            // Act
            bool result = SaveManager.TryUnequipCardToAvocado(userCode, cardID);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void TrySellCardTest()
        {
            // Arrange
            int userCode = 50;
            int cardID = 1;
            int gold = 700;

            // Act
            bool result = SaveManager.TrySellCard(userCode, gold, cardID);

            // Assert
            Assert.IsTrue(result);
        }
    }
}