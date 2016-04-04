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
            string connStr = "server=newuserdb.cvk754rpwemy.us-east-1.rds.amazonaws.com;port=3306;user=battlecado;password=milehigh;database=User;";
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
        
        // Done
        // Attempts to get the user's info from the database, returns true if user was found, false otherwise, sends the user back all their info
        // Should be called from the LogIn page controller
        public static bool TryLogIn(string username, string password, out User user)
        {
            bool found = false;
            user = GetCurrentInfo.User;

            // User database work
            int userCode = 0;
            int bronzePacks = 0;
            int silverPacks = 0;
            int goldPacks = 0;
            int storyLevel = 0;
            int gold = 0;
            MySqlConnection conn = DatabaseConnect();
            string sql = "SELECT * FROM User WHERE username='" + username +"'AND hashPassword = '" + password + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                found = true;
                userCode = Convert.ToInt32(rdr[0]);
                bronzePacks = Convert.ToInt32(rdr[3]);
                silverPacks = Convert.ToInt32(rdr[4]);
                goldPacks = Convert.ToInt32(rdr[5]);
                storyLevel = Convert.ToInt32(rdr[6]);
                gold = Convert.ToInt32(rdr[7]);
            }
            rdr.Close();

            // Avocado database work
            int level = 0;
            int experiencePoints = 0;
            int rightHandedWeapon = 0;
            int leftHandedWeapon = 0;
            int twoHandedWeapon = 0;
            int headArmor = 0;
            int chestArmor = 0;
            int supportCards = 0;
            string cado_sql = "SELECT * FROM Avocado WHERE avocadoID = " + userCode;
            MySqlCommand cado_cmd = new MySqlCommand(cado_sql, conn);
            MySqlDataReader cado_rdr = cado_cmd.ExecuteReader();
            while (cado_rdr.Read())
            {
                level = Convert.ToInt32(cado_rdr[1]);
                experiencePoints = Convert.ToInt32(cado_rdr[2]);
                rightHandedWeapon = Convert.ToInt32(cado_rdr[3]);
                leftHandedWeapon = Convert.ToInt32(cado_rdr[4]);
                twoHandedWeapon = Convert.ToInt32(cado_rdr[5]);
                headArmor = Convert.ToInt32(cado_rdr[6]);
                chestArmor = Convert.ToInt32(cado_rdr[7]);
                supportCards = Convert.ToInt32(cado_rdr[8]);
            }
            cado_rdr.Close();
            DatabaseDisconnect(conn);
            //public Avocado(int level, int experiencePoints, Card rightHandedWeapon, Card leftHandedWeapon, Card twoHandedWeapon,
                //Card headArmor, Card chestArmor, List<Card> supportCards)
            Avocado cado = new Avocado(level, experiencePoints, null, null, null, null, null, null);

            //public User(string username, int userCode, int gold, int bronzePacks, int silverPacks, int goldPacks, int storyLevel, Avocado avocado)
            user.SetValues(username, userCode, gold, bronzePacks, silverPacks, goldPacks, storyLevel, cado);

            return found;
        }

        // Done
        // Attempts to create a new user in the database, returns true if no user by the given name exists, false otherwise, sends the user back their user code
        // Should be called from the LogIn page controller
        public static bool TryCreateNewUser(string username, string password, out User user)
        {
            bool success = false;
            MySqlConnection conn = DatabaseConnect();
            user = GetCurrentInfo.User;
            int userCode = 0;
            int bronzePacks = 0;
            int silverPacks = 0;
            int goldPacks = 0;
            int storyLevel = 0;
            int gold = 0;

            string sql = "INSERT INTO User (username, hashPassword) VALUES ('" + username + "', '" + password + "')";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            string r_retrieve = "SELECT LAST_INSERT_ID()";
            MySqlCommand retrieve = new MySqlCommand(r_retrieve, conn);
            var result = retrieve.ExecuteScalar();
            if (result != null)
            {
                userCode = Convert.ToInt32(result);
                success = true;
                Console.WriteLine("User code: " + userCode);
            }
            string usersql = "SELECT * FROM User WHERE userCode = " + userCode;
            MySqlCommand getUser = new MySqlCommand(usersql, conn);
            MySqlDataReader rdr = getUser.ExecuteReader();
            while (rdr.Read())
            {
                bronzePacks = Convert.ToInt32(rdr[3]);
                silverPacks = Convert.ToInt32(rdr[4]);
                goldPacks = Convert.ToInt32(rdr[5]);
                storyLevel = Convert.ToInt32(rdr[6]);
                gold = Convert.ToInt32(rdr[7]);
            }
            rdr.Close();

            // Creating user's avocado
            string avocadosql = "INSERT INTO Avocado (avocadoID) VALUES (" + userCode + ")";
            MySqlCommand newAvocado = new MySqlCommand(avocadosql, conn);
            newAvocado.ExecuteNonQuery();

            // Creating user
            user.SetValues(username, userCode, gold, bronzePacks, silverPacks, goldPacks, storyLevel, new Avocado());

            DatabaseDisconnect(conn);

            return success;
        }

        // Done
        // Attempts to save user info after an online battle (win or lose), returns true if save was successful, false otherwise
        public static bool TrySaveBattleResults(int userCode, int avocadoLevel, int avocadoExperiencePoints, int gold)
        {
            bool success = false;
            try
            {
                MySqlConnection conn = DatabaseConnect();
                string sql = "UPDATE User SET gold=" + gold + " WHERE userCode=" + userCode;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                string cado_sql = "UPDATE Avocado SET level=" + avocadoLevel + ", experiencePoints=" + avocadoExperiencePoints + " WHERE avocadoID = " + userCode;
                MySqlCommand cado_cmd = new MySqlCommand(cado_sql, conn);
                cado_cmd.ExecuteNonQuery();
                success = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                success = false;
            }
            return success;
        }
        
        // Done
        // Attempts to save user info after a story mode battle win, returns true if save was successful, false otherwise
        public static bool TryGoToNextLevel(int userCode, int storyLevel)
        {
            bool success = false;
            try
            {
                MySqlConnection conn = DatabaseConnect();
                string sql = "UPDATE User SET storyLevel=" + storyLevel + " WHERE userCode=" + userCode;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                success = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                success = false;
            }
            return success;
        }

        // Done
        // Attempts to save user info after a pack is purchased, returns true if save was successful, false otherwise
        public static bool TryBuyPack(int userCode, int numberOfBronzePacks, int numberOfSilverPacks, int numberOfGoldPacks, int gold)
        {
            bool success = false;
            try
            {
                MySqlConnection conn = DatabaseConnect();
                string sql = "UPDATE User SET bronzePacks=" + numberOfBronzePacks+", silverPacks=" + numberOfSilverPacks
                    + ", goldPacks=" + numberOfGoldPacks + ", gold=" + gold + " WHERE userCode=" + userCode;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                success = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                success = false;
            }

            return success;
        }

        // Attempts to save user info after a pack is opened, returns true if save was successful, false otherwise
        // Card collection is a list of card id's that the user has in their collection
        public static bool TryOpenPack(int userCode, int numberOfBronzePacks, int numberOfSilverPacks, int numberOfGoldPacks, IEnumerable<int> cardCollection)
        {
            bool success = false;
            try
            {
                MySqlConnection conn = DatabaseConnect();
                // Update user card packs
                string sql = "UPDATE User SET bronzePacks=" + numberOfBronzePacks + ", silverPacks=" + numberOfSilverPacks
                    + ", goldPacks=" + numberOfGoldPacks + " WHERE userCode=" + userCode;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                // Update user cards
                foreach (int cardID in cardCollection)
                {
                    string cardsql = "INSERT INTO UserCards (userID, cardID) VALUES (" + userCode + ", " + cardID + ")";
                    MySqlCommand newCard = new MySqlCommand(cardsql, conn);
                    newCard.ExecuteNonQuery();
                }
                
                success = true;
                DatabaseDisconnect(conn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                success = false;
            }

            return success;
        }

        public static bool TryEquipCardToAvocado(int userCode, int cardID)
        {
            // Remove **First instance** from UserCards, insert into AvocadoCards
            bool success = false;
            try
            {
                MySqlConnection conn = DatabaseConnect();
                string usersql = "DELETE FROM UserCards WHERE userID = " + userCode + ", cardID = " + cardID;
                MySqlCommand usercmd = new MySqlCommand(usersql, conn);
                usercmd.ExecuteNonQuery();
                string cadosql = "INSERT INTO AvocadoCards (avocadoID, cardID) VALUES (" + userCode + ", " + cardID + ")";
                MySqlCommand cadocmd = new MySqlCommand(cadosql, conn);
                cadocmd.ExecuteNonQuery();
                success = true;
                DatabaseDisconnect(conn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                success = false;
            }

            return success;
        }

        public static bool TryUnequipCardToAvocado(int userCode, int cardID)
        {
            // Remove **First instance ** from AvocadoCards, insert into UserCards
            bool success = true;

            return success;
        }

        // Attempts to save user info after a card is sold, returns true if successful, false otherwise
        public static bool TrySellCard(int userCode, int gold, int cardID)
        {
            bool success = true;

            return success;
        }

    }
}
