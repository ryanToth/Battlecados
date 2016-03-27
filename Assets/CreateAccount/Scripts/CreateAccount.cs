using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreateAccount : MonoBehaviour {

    public float createButtonX;
    public float createButtonY;
    public float createButtonWidth;
    public float createButtonHeight;

    public float createUsernameX;
    public float createUsernameY;
    public float createUsernameWidth;
    public float createUsernameHeight;

    public float createPasswordX;
    public float createPasswordY;
    public float createPasswordWidth;
    public float createPasswordHeight;

    public float usernameLabelY;
    public float passwordLabelY;

    public string userNameInput = "";
    public string passwordInput = "";

    public Texture backgroundTexture;

    public void OnGUI()
    {
        GUI.skin.label.fontSize = (int)(Screen.width * 0.070);
        GUI.skin.button.fontSize = (int)(Screen.width * 0.066);
        GUI.skin.textField.fontSize = (int)(Screen.width * 0.075);

        createButtonX = Screen.width * 0.25f;
        createButtonY = Screen.height * 0.70f;
        createButtonWidth = Screen.width * 0.50f;
        createButtonHeight = Screen.height * 0.075f;

        createUsernameX = Screen.width * 0.25f;
        createUsernameY = Screen.height * 0.45f;
        createUsernameWidth = Screen.width * 0.50f;
        createUsernameHeight = Screen.width * 0.10f;

        usernameLabelY = Screen.height * 0.40f;
        passwordLabelY = Screen.height * 0.53f;

        createPasswordX = Screen.width * 0.25f;
        createPasswordY = Screen.height * 0.58f;
        createPasswordWidth = Screen.width * 0.50f;
        createPasswordHeight = Screen.width * 0.10f;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        GUI.Label(new Rect(createUsernameX, usernameLabelY, createUsernameWidth, createUsernameHeight), "Username:");
        userNameInput = GUI.TextField(new Rect(createUsernameX, createUsernameY, createUsernameWidth, createUsernameHeight), userNameInput, 9);

        GUI.Label(new Rect(createPasswordX, passwordLabelY, createPasswordWidth, createPasswordHeight), "Password:");
        passwordInput = GUI.TextField(new Rect(createPasswordX, createPasswordY, createPasswordWidth, createPasswordHeight), passwordInput, 9);

        if (GUI.Button(new Rect(createButtonX, createButtonY, createButtonWidth, createButtonHeight), "Create Account"))
        {
            CreateNewAccount();
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CreateNewAccount();
        }
    }

    void CreateNewAccount()
    {
        //Take the input and try to create account and sign in

        print(userNameInput + " : " + passwordInput);

        SceneManager.LoadScene(2);
    }
}
