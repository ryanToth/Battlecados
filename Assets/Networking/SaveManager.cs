using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Assets.Networking
{
    public class SaveManager
    {
        private static MySqlConnection DatabaseConnect()
        {
            string connStr = "server=userdb.cvk754rpwemy.us-east-1.rds.amazonaws.com;port=3306;user=battlecado;password=milehigh;database=User;";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return conn;
        }
        private static void DatabaseDisconnect(MySqlConnection conn)
        {
            conn.Close();
            Console.WriteLine("Database connection closed");
        }
        // Attempts to get the user's info from the database, returns true if user was found, false otherwise, sends the user back all their info
        // Should be called from the LogIn page controller
        public static bool TryLogIn(string username, string password, out User user)
        {
            bool found = true;
            MySqlConnection conn = DatabaseConnect();
            string sql = "SELECT username, hashPassword FROM User WHERE username='" + username+"';'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine(rdr[0] + " ------- " + rdr[1]);
            }
            rdr.Close();
            user = null;
            DatabaseDisconnect(conn);
            return found;
        }

        // Attempts to create a new user in the database, returns true if no user by the given name exists, false otherwise, sends the user back their user code
        // Should be called from the LogIn page controller
        public static bool TryCreateNewUser(string username, string password, out int userCode)
        {
            bool success = true;

            userCode = 0;
            return success;
        }

        // Attempts to save user info after an online battle (win or lose), returns true if save was successful, false otherwise
        public static bool TrySaveBattleResults(int userCode, int avocadoLevel, int avocadoExperienceToNextLevel, int gold)
        {
            bool success = true;

            return success;
        }

        // Attempts to save user info after a story mode battle win, returns true if save was successful, false otherwise
        public static bool TryGoToNextLevel(int userCode, int storyLevel)
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
        public static bool TryOpenPack(int userCode, int numberOfBronzePacks, int numberOfSilverPacks, int numberOfGoldPacks, IEnumerable<int> cardCollection)
        {
            bool success = true;

            return success;
        }

        // Anytime a card is equipped or unequipped from an Avocado, the result needs to be saved, return true if save was successful, false otherwise
        public static bool TryUpdateAvococado(int userCode, Avocado avocado, IEnumerable<int> cardCollection)
        {
            bool success = true;

            return success;
        }

        // Attempts to save user info after a card is sold, returns true if successful, false otherwise
        public static bool TrySellCard(int userCode, int gold, IEnumerable<int> cardCollection)
        {
            bool success = true;

            return success;
        }

    }
}
