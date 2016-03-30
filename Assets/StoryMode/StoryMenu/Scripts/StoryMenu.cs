using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StoryMenu : MonoBehaviour {

    public Texture backgroundTexture;

    public float startButtonX;
    public float startButtonY;
    public float startButtonWidth;
    public float startButtonHeight;
    public GUIStyle startButtonStyle;

    public float backButtonX;
    public float backButtonY;
    public float backButtonWidth;
    public float backButtonHeight;
    public GUIStyle backButtonStyle;

    public Texture enemyToFight;
    public float enemyX;
    public float enemyY;
    public float enemyWidth;
    public float enemyHeight;

    public int storyLevel;
    public float storyLevelLabelX;
    public float storyLevelLabelY;
    public float storyLevelLabelWidth;
    public float storyLevelLabelHeight;
    public GUIStyle storyLevelLabelStyle;

    public string enemyName;
    public float enemyNameX;
    public float enemyNameY;
    public float enemyNameWidth;
    public float enemyNameHeight;
    public GUIStyle enemyNameStyle;

    public int userLevel;
    public float userLevelX;
    public float userLevelY;
    public float userLevelWidth;
    public float userLevelHeight;

    public int experienceToNextLevel;

    public GUIStyle statBarStyle;

    User user;

    void OnGUI()
    {
        SetRelativeComponentSizes();

        //Display our background texture     
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        // Story Stage Label
        GUI.Label(new Rect(storyLevelLabelX, storyLevelLabelY, storyLevelLabelWidth, storyLevelLabelHeight), "Story Stage: " + storyLevel.ToString(), storyLevelLabelStyle);

        // Enemy Image
        GUI.DrawTexture(new Rect(enemyX, enemyY, enemyWidth, enemyHeight), enemyToFight);

        // Enemy Name Label
        GUI.Label(new Rect(enemyNameX, enemyNameY, enemyNameWidth, enemyHeight), enemyName + " Wants to Battle!", enemyNameStyle);

        // Start Battle Button
        if (GUI.Button(new Rect(startButtonX, startButtonY, startButtonWidth, startButtonHeight), "Start Battle"))
        {
            StartButtonPressed();
        }

        // Back Button
        if (GUI.Button(new Rect(backButtonX, backButtonY, backButtonWidth, backButtonHeight), "Back"))
        {
            BackButtonPressed();
        }

        // Stat bar at the bottom of the screen
        GUI.Label(new Rect(userLevelX, userLevelY, userLevelWidth, userLevelHeight), "Lvl. " + userLevel.ToString(), statBarStyle);
        GUI.Label(new Rect(userLevelX + userLevelWidth, userLevelY, Screen.width - userLevelWidth, userLevelHeight), "Experience To Next Level: " + experienceToNextLevel.ToString(), statBarStyle);
    }

    void SetRelativeComponentSizes()
    {
        startButtonX = 0;
        startButtonY = Screen.height * 0.71f;
        startButtonWidth = Screen.width;
        startButtonHeight = (Screen.height - Screen.height * 0.75f) / 2;

        backButtonX = startButtonX;
        backButtonY = startButtonY + startButtonHeight;
        backButtonWidth = startButtonWidth;
        backButtonHeight = startButtonHeight;

        storyLevelLabelX = 0;
        storyLevelLabelY = Screen.height * 0.025f;
        storyLevelLabelWidth = Screen.width;
        storyLevelLabelHeight = Screen.height * 0.05f;

        storyLevelLabelStyle.fontSize = (int)(Screen.width * 0.075f);
        enemyNameStyle.fontSize = (int)(Screen.width * 0.075f);

        enemyNameWidth = storyLevelLabelWidth;
        enemyNameHeight = storyLevelLabelHeight;
        enemyNameX = 0;
        enemyNameY = startButtonY - enemyNameHeight - Screen.height * 0.01f;

        // Set once actually have the avocado image, set the height based on the width
        enemyHeight = Screen.height * 0.5f;
        enemyWidth = Screen.width * 0.75f;
        enemyX = (Screen.width - enemyWidth) / 2;
        enemyY = (enemyNameY - (storyLevelLabelHeight + storyLevelLabelY) - enemyHeight) / 2 + storyLevelLabelY + storyLevelLabelHeight;

        // Stat Bar Stuff
        userLevelX = 0;
        userLevelY = Screen.height * 0.965f;
        userLevelWidth = Screen.width * 0.25f;
        userLevelHeight = Screen.width - userLevelY;

        statBarStyle.fontSize = (int)(Screen.width * 0.05);
    }

    public void StartButtonPressed()
    {

    }

    public void BackButtonPressed()
    {
        SceneManager.LoadScene(2);
    }

    // Use this for initialization
    void Start () {

        user = GetCurrentInfo.User;

        storyLevel = user.StoryLevel;
        experienceToNextLevel = user.Avocado.ExperiencePointsToNextLevel;
        userLevel = user.Avocado.Level;

        EnemyEyes eyes = GetCurrentInfo.EnemyEyes;
        // Eyes will be a randomly generated number between 1 and the number of eyes we have
        eyes.eyes = 1;

        // Name will be randomly generated
        enemyName = "Phil";

        enemyToFight = Resources.Load("Eyes/eyes" + eyes.eyes.ToString(), typeof(Texture)) as Texture;
    }
}
