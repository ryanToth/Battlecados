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

    // Temporary addition
    int userGold;

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
                SceneManager.LoadScene(6);
                numBronzePacks--;
                print("Open Bronze Pack");
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
                SceneManager.LoadScene(6);
                numSilverPacks--;
                print("Open Silver Pack");
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
                SceneManager.LoadScene(6);
                numGoldPacks--;
                print("Open Gold Pack");
            }
        }
        else
        {
            GUI.Label(new Rect(packX, goldY, packWidth, packHeight), "", goldStyle);
        }

        // Gold price label
        GUI.Label(new Rect(packX, quantityLabelY + goldY + packHeight, packWidth, quantityLabelHeight), numGoldPacks.ToString(), quantityLabelStyle);

        // Back Button
        if (GUI.Button(new Rect(backX, backY, backWidth, backHeight), "Back"))
        {
            print("Back");
            //Go to Main Menu
            SceneManager.LoadScene(2);
        }
    }

    void Start()
    {
        //Get these from the User class later
        numBronzePacks = 1;
        numSilverPacks = 0;
        numGoldPacks = 1;

        // Temporary until we link this scene to the rest and pass along the User object
        userGold = 1200;
    }

    void Update()
    {
        //Update all value fields that change when stuff happens i.e. number of each pack the user has
    }

    void SetRelativeComponentSizes()
    {
        packX = Screen.width * 0.15f;
        packWidth = Screen.width * 0.40f;
        packHeight = Screen.height * 0.25f;

        bronzeY = Screen.height * 0.06f;
        silverY = bronzeY * 2 + packHeight;
        goldY = bronzeY * 3 + 2 * packHeight;

        quantityLabelY = 1;
        quantityLabelHeight = bronzeY;

        backHeight = Screen.height * 0.075f;
        backWidth = Screen.width * 0.33f;
        backX = Screen.width - backWidth;
        backY = Screen.height * 0.90f;
    }
}

