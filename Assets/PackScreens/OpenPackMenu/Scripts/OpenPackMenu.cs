using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OpenPackMenu : MonoBehaviour
{
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

    public float quantityLabelY;
    public float quantityLabelHeight;
    public GUIStyle quantityLabelStyle;

    public float backX;
    public float backY;
    public float backWidth;
    public float backHeight;
    public GUIStyle backStyle;

    public string userGoldText;
    public int numGoldPacks = 0;
    public int numSilverPacks = 0;
    public int numBronzePacks = 1;

    public int userLevel;
    public float userLevelX;
    public float userLevelY;
    public float userLevelWidth;
    public float userLevelHeight;

    public int experienceToNextLevel;

    public GUIStyle statBarStyle;

    public int userGold;

    public User user;

    void OnGUI()
    {

        SetRelativeComponentSizes();

        //Display our background texture     
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        if (numBronzePacks > 0)
        {
            // Bronze Pack button
            if (GUI.Button(new Rect(packX, bronzeY, packWidth, packHeight), "", bronzeStyle))
            {
                // Need to find a way to tell the next scene that I opened a Bronze pack
                TypeOfPackBought type = GetCurrentInfo.TypeOfPackToOpen;
                type.packType = 1;
                print("Open Bronze Pack");
                SceneManager.LoadScene(6);
            }
        }
        else
        {
            GUI.Label(new Rect(packX, bronzeY, packWidth, packHeight), "", bronzeStyle);
        }

        // Bronze price label
        GUI.Label(new Rect(packX, quantityLabelY + bronzeY + packHeight, packWidth, quantityLabelHeight), numBronzePacks.ToString(), quantityLabelStyle);

        if (numSilverPacks > 0)
        {
            // Silver Pack button
            if (GUI.Button(new Rect(packX, silverY, packWidth, packHeight), "", silverStyle))
            {
                // Need to find a way to tell the next scene that I opened a Silver pack
                TypeOfPackBought type = GetCurrentInfo.TypeOfPackToOpen;
                type.packType = 2;
                print("Open Silver Pack");
                SceneManager.LoadScene(6);
            }
        }
        else
        {
            GUI.Label(new Rect(packX, silverY, packWidth, packHeight), "", silverStyle);
        }

        // Silver price label
        GUI.Label(new Rect(packX, quantityLabelY + silverY + packHeight, packWidth, quantityLabelHeight), numSilverPacks.ToString(), quantityLabelStyle);

        if (numGoldPacks > 0)
        {
            // Gold Pack button
            if (GUI.Button(new Rect(packX, goldY, packWidth, packHeight), "", goldStyle))
            {
                // Need to find a way to tell the next scene that I opened a Gold pack
                TypeOfPackBought type = GetCurrentInfo.TypeOfPackToOpen;
                type.packType = 3;
                print("Open Gold Pack");
                SceneManager.LoadScene(6);
            }
        }
        else
        {
            GUI.Label(new Rect(packX, goldY, packWidth, packHeight), "", goldStyle);
        }

        // Gold price label
        GUI.Label(new Rect(packX, quantityLabelY + goldY + packHeight, packWidth, quantityLabelHeight), numGoldPacks.ToString(), quantityLabelStyle);

        // Back Button
        if (GUI.Button(new Rect(backX, backY, backWidth, backHeight), "", backStyle))
        {
            print("Back");
            //Go to Main Menu
            SceneManager.LoadScene(11);
        }

        // Stat bar at the bottom of the screen
        GUI.Label(new Rect(userLevelX, userLevelY, userLevelWidth, userLevelHeight), "Lvl. " + userLevel.ToString(), statBarStyle);
        GUI.Label(new Rect(userLevelX + userLevelWidth, userLevelY, Screen.width - userLevelWidth, userLevelHeight), "Experience To Next Level: " + experienceToNextLevel.ToString(), statBarStyle);
    }

    public void Start()
    {
        user = GetCurrentInfo.User;
        UpdateUpdateableFields();
    }

    void UpdateUpdateableFields()
    {
        numBronzePacks = user.BronzePacks;
        numSilverPacks = user.SilverPacks;
        numGoldPacks = user.GoldPacks;
    }

    void Update()
    {
        //Update all value fields that change when stuff happens i.e. number of each pack the user has
    }

    void SetRelativeComponentSizes()
    {
        quantityLabelStyle.fontSize = (int)(Screen.width * 0.05f);
        goldStyle.fontSize = (int)(Screen.width * 0.06f);

        packX = Screen.width * 0.15f;
        packWidth = Screen.width * 0.40f;
        packHeight = Screen.height * 0.25f;

        bronzeY = Screen.height * 0.045f;
        silverY = bronzeY * 2 + packHeight;
        goldY = bronzeY * 3 + 2 * packHeight;

        quantityLabelY = 1;
        quantityLabelHeight = bronzeY;

        backHeight = CommonElementSizes.backHeight;
        backWidth = CommonElementSizes.backWidth;
        backX = CommonElementSizes.backX;
        backY = CommonElementSizes.backY;

        userLevel = user.Avocado.Level;

        userLevelX = 0;
        userLevelY = Screen.height * 0.965f;
        userLevelWidth = Screen.width * 0.25f;
        userLevelHeight = Screen.width - userLevelY;

        experienceToNextLevel = user.Avocado.ExperiencePointsToNextLevel;

        statBarStyle.fontSize = (int)(Screen.width * 0.05);
    }
}

