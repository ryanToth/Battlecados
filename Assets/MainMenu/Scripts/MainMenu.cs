using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Texture backgroundTexture;

    public float storyButtonY;
    public float versusButtonY;

    public float firstTwoButtonsWidth;
    public float firstTwoButtonsHeight;

    public float buyCardsButtonY;
    public float manageCardsButtonY;

    public float lastTwoButtonsWidth;
    public float lastTwoButtonsHeight;

    public GUIStyle storyButtonStyle;
    public GUIStyle versusButtonStyle;
    public GUIStyle buyCardsButtonStyle;
    public GUIStyle manageCardsButtonStyle;

    /*
    float pointerFingerY;
    public float pointerFingerWidth;
    public float pointerFingerHeight;
    */

    public int pointerFingerIndex = 0;

    public GUIStyle pointerFingerStyle;

    public int userLevel;
    public float userLevelX;
    public float userLevelY;
    public float userLevelWidth;
    public float userLevelHeight;

    public GUIStyle statBarStyle;

    public User user;

    public int experienceToNextLevel;
    void OnGUI()
    {
        storyButtonY = Screen.height * 0.43168f;
        versusButtonY = Screen.height * 0.53267f;

        firstTwoButtonsWidth = Screen.width * 0.60701f;
        firstTwoButtonsHeight = Screen.height * 0.07327f;

        buyCardsButtonY = Screen.height * 0.63564f;
        manageCardsButtonY = Screen.height * 0.78416f;

        lastTwoButtonsWidth = Screen.width * 0.60701f;
        lastTwoButtonsHeight = Screen.height * 0.125f;

        userLevel = user.Avocado.Level;

        userLevelX = 0;
        userLevelY = Screen.height * 0.965f;
        userLevelWidth = Screen.width * 0.25f;
        userLevelHeight = Screen.width - userLevelY;

        statBarStyle.fontSize = (int)(Screen.width * 0.05);

        experienceToNextLevel = user.Avocado.ExperiencePointsToNextLevel;

        //Display our background texture
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        if (GUI.Button(new Rect(0, storyButtonY, firstTwoButtonsWidth, firstTwoButtonsHeight), "", storyButtonStyle))
        {
            print("Clicked Story Button");
            SceneManager.LoadScene(8);
        }

        if (GUI.Button(new Rect(0, versusButtonY, firstTwoButtonsWidth, firstTwoButtonsHeight), "", versusButtonStyle))
        {
            print("Clicked Versus Button");
            SceneManager.LoadScene(9);
        }

        if (GUI.Button(new Rect(0, buyCardsButtonY, lastTwoButtonsWidth, lastTwoButtonsHeight), "", buyCardsButtonStyle))
        {
            print("Clicked Buy Cards Button");
            SceneManager.LoadScene(4);
        }

        if (GUI.Button(new Rect(0, manageCardsButtonY, lastTwoButtonsWidth, lastTwoButtonsHeight), "", manageCardsButtonStyle))
        {
            print("Clicked Manage Cards Button");
            SceneManager.LoadScene(5);
        }

        /*
        pointerFingerWidth = Screen.width * 0.28421f;
        pointerFingerHeight = Screen.height * 0.12079f;

        if (pointerFingerIndex == 0) pointerFingerY = storyButtonY - Screen.height * 0.03f;
        else if (pointerFingerIndex == 1) pointerFingerY = versusButtonY - Screen.height * 0.03f;
        else if (pointerFingerIndex == 2) pointerFingerY = buyCardsButtonY;
        else if (pointerFingerIndex == 3) pointerFingerY = manageCardsButtonY;

        GUI.Label(new Rect(firstTwoButtonsWidth, pointerFingerY, pointerFingerWidth, pointerFingerHeight), "", pointerFingerStyle);
        */

        // Stat bar at the bottom of the screen
        GUI.Label(new Rect(userLevelX, userLevelY, userLevelWidth, userLevelHeight), "Lvl. " + userLevel.ToString(), statBarStyle);
        GUI.Label(new Rect(userLevelX + userLevelWidth, userLevelY, Screen.width - userLevelWidth, userLevelHeight), "Experience To Next Level: " + experienceToNextLevel.ToString(), statBarStyle);
    }

    void Start()
    {
        user = GetCurrentInfo.User;
    }

    public void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (pointerFingerIndex != 3) pointerFingerIndex++;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (pointerFingerIndex != 0) pointerFingerIndex--;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch(pointerFingerIndex)
            {
                case 0:
                    print("Clicked Story Button");
                    break;
                case 1:
                    print("Clicked Versus Button");
                    break;
                case 2:
                    print("Clicked Buy Cards Button");
                    break;
                case 3:
                    print("Clicked Manage Cards Button");
                    break;
            }
        }
        */
    }
}
