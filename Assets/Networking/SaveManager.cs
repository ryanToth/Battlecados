using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Networking
{
    class SaveManager
    {
        // Attempts to get the user's info from the database, returns true if user was found, false otherwise
        public static bool TryLogIn(string username, string password)
        {
            bool found = true;

            return found;
        }

        // Attempts to create a new user in the database, returns true if no user by the given name exists, false otherwise
        public static bool TryCreateNewUser(string username, string password)
        {
            bool success = true;

            return success;
        }

        // Attempts to save user info after an online battle (win or lose), returns true if save was successful, false otherwise
        public static bool TrySaveOnlineBattleResults(int userCode, int avocadoLevel, int avocadoExperienceToNextLevel, int gold)
        {
            bool success = true;

            return success;
        }

        // Attempts to save user info after a story mode battle (win or lose), returns true if save was successful, false otherwise
        public static bool TrySaveStoryBattleResults(int userCode, int avocadoLevel, int avocadoExperienceToNextLevel, int gold, int storyLevel)
        {
            bool success = true;

            return success;
        }

        // Attempts to save user info after a pack is purchased, returns true if save was successful, false otherwise
        public static bool TryBuyPack(int userCode, int numberOfBronzePacks, int numberOfSilverPacks, int numberOfGoldPacks, int gold)
        {
            bool success = true;

            return success;
        }

        // Attempts to save user info after a pack is opened, returns true if save was successful, false otherwise
        // Card collection is a list of card id's that the user has in their collection
        public static bool TryOpenPack(int userCode, int numberOfBronzePacks, int numberOfSilverPacks, int numberOfGoldPacks, List<int> cardCollection)
        {
            bool success = true;

            return success;
        }

        // Anytime a card is equipped or unequipped from an Avocado, the result needs to be saved, return true if save was successful, false otherwise
        public static bool TryUpdateAvococado(int userCode, Avocado avocado, List<int> cardCollection)
        {
            bool success = true;

            return success;
        }

        // Attempts to save user info after a card is sold, returns true if successful, false otherwise
        public static bool TrySellCard(int userCode, int gold, List<int> cardCollection)
        {
            bool success = true;

            return success;
        }

    }
}
