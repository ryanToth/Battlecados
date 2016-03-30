using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BuyPack : MonoBehaviour {

    public Texture backgroundTexture;

    public float packX;
    public float packWidth;
    public float packHeight;

    public float bronzeY;
    public GUIStyle bronzeStyle;
    public float silverY;
    public GUIStyle silverStyle;
    public float goldY;
    public GUIStyle goldStyle;

    public float priceLabelY;
    public float priceLabelHeight;
    public GUIStyle priceLabelStyle;

    public float backX;
    public float backY;
    public float backWidth;
    public float backHeight;
    public GUIStyle backStyle;

    public float userGoldX;
    public float userGoldY = 0;
    public float userGoldWidth;
    public float userGoldHeight;
    public GUIStyle userGoldStyle;

    public string userGoldText;
    public int goldPrice;
    public int silverPrice;
    public int bronzePrice;

    public int userLevel;
    public float userLevelX;
    public float userLevelY;
    public float userLevelWidth;
    public float userLevelHeight;

    public int experienceToNextLevel;

    public GUIStyle statBarStyle;


    // Temporary addition
    int userGold;

    public User user;

    void OnGUI()
    {

        SetRelativeComponentSizes();

        //Display our background texture     
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        // Bronze Pack button
        if (GUI.Button(new Rect(packX, bronzeY, packWidth, packHeight), "", bronzeStyle))
        {
            user.BuyBronzePack(bronzePrice);
            userGold = user.Gold;
            print("Purchased Bronze Pack");
        }

        // Bronze price label
        GUI.Label(new Rect(packX, priceLabelY + bronzeY + packHeight, packWidth, priceLabelHeight), bronzePrice.ToString(), priceLabelStyle);

        // Silver Pack button
        if (GUI.Button(new Rect(packX, silverY, packWidth, packHeight), "", silverStyle))
        {
            user.BuySilverPack(silverPrice);
            userGold = user.Gold;
            print("Purchased Silver Pack");
        }

        // Silver price label
        GUI.Label(new Rect(packX, priceLabelY + silverY + packHeight, packWidth, priceLabelHeight), silverPrice.ToString(), priceLabelStyle);

        // Gold Pack button
        if (GUI.Button(new Rect(packX, goldY, packWidth, packHeight), "", goldStyle))
        {
            user.BuyGoldPack(goldPrice);
            userGold = user.Gold;
            print("Purchased Gold Pack");
        }

        // Gold price label
        GUI.Label(new Rect(packX, priceLabelY + goldY + packHeight, packWidth, priceLabelHeight), goldPrice.ToString(), priceLabelStyle);

        // User gold label
        GUI.Label(new Rect(userGoldX, userGoldY, userGoldWidth, userGoldHeight), userGoldText + userGold.ToString(), userGoldStyle);

        // Back Button
        if (GUI.Button(new Rect(backX, backY, backWidth, backHeight), "Back"))
        {
            print("Back");
            //Go to Main Menu
            SceneManager.LoadScene(2);
        }

        // Stat bar at the bottom of the screen
        GUI.Label(new Rect(userLevelX, userLevelY, userLevelWidth, userLevelHeight), "Lvl. " + userLevel.ToString(), statBarStyle);
        GUI.Label(new Rect(userLevelX + userLevelWidth, userLevelY, Screen.width - userLevelWidth, userLevelHeight), "Experience To Next Level: " + experienceToNextLevel.ToString(), statBarStyle);
    }

    void Start()
    {
        goldPrice = new GoldPack().Cost;
        silverPrice = new SilverPack().Cost;
        bronzePrice = new BronzePack().Cost;
        userGoldText = "Gold: ";

        user = GetCurrentInfo.User;

        userGold = user.Gold;
    }

    void SetRelativeComponentSizes()
    {
        priceLabelStyle.fontSize = (int)(Screen.width * 0.05f);
        userGoldStyle.fontSize = (int)(Screen.width * 0.06f);

        packX = Screen.width * 0.10f;
        packWidth = Screen.width * 0.40f;
        packHeight = Screen.height * 0.25f;

        bronzeY = Screen.height * 0.045f;
        silverY = bronzeY * 2 + packHeight;
        goldY = bronzeY * 3 + 2 * packHeight;

        priceLabelY = 1;
        priceLabelHeight = bronzeY;

        userGoldX = Screen.width * 0.60f;
        userGoldWidth = Screen.width - userGoldX;
        userGoldHeight = Screen.height * 0.075f;

        backHeight = CommonElementSizes.backHeight;
        backWidth = CommonElementSizes.backWidth;
        backX = CommonElementSizes.backX;
        backY = CommonElementSizes.backY;

        userLevel = user.Avocado.Level;

        userLevelX = 0;
        userLevelY = Screen.height * 0.965f;
        userLevelWidth = Screen.width * 0.25f;
        userLevelHeight = Screen.width - userLevelY;

        statBarStyle.fontSize = (int)(Screen.width * 0.05);

        experienceToNextLevel = user.Avocado.ExperiencePointsToNextLevel;

    }
}
