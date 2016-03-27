using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LogIn : MonoBehaviour {

    public float loginButtonX;
    public float loginButtonY;
    public float loginButtonWidth;
    public float loginButtonHeight;

    public float loginUsernameX;
    public float loginUsernameY;
    public float loginUsernameWidth;
    public float loginUsernameHeight;

    public float loginPasswordX;
    public float loginPasswordY;
    public float loginPasswordWidth;
    public float loginPasswordHeight;

    public float usernameLabelY;
    public float passwordLabelY;

    public string userNameInput = "";
    public string passwordInput = "";

    public float createAccountButtonY;
    public float createAcountButtonWidth;

    public Texture backgroundTexture;

    public void OnGUI()
    {
        GUI.skin.label.fontSize = (int)(Screen.width * 0.070);
        GUI.skin.button.fontSize = (int)(Screen.width * 0.066);
        GUI.skin.textField.fontSize = (int)(Screen.width * 0.075);

        loginButtonX = Screen.width * 0.33f;
        loginButtonY = Screen.height * 0.70f;
        loginButtonWidth = Screen.width * 0.33f;
        loginButtonHeight = Screen.height * 0.075f;

        loginUsernameX = Screen.width * 0.25f;
        loginUsernameY = Screen.height * 0.45f;
        loginUsernameWidth = Screen.width * 0.50f;
        loginUsernameHeight = Screen.width * 0.10f;

        usernameLabelY = Screen.height * 0.40f;
        passwordLabelY = Screen.height * 0.53f;

        loginPasswordX = Screen.width * 0.25f;
        loginPasswordY = Screen.height * 0.58f;
        loginPasswordWidth = Screen.width * 0.50f;
        loginPasswordHeight = Screen.width * 0.10f;

        createAccountButtonY = Screen.height * 0.90f;
        createAcountButtonWidth = Screen.width * 0.50f;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        GUI.Label(new Rect(loginUsernameX, usernameLabelY, loginUsernameWidth, loginUsernameHeight), "Username:");
        userNameInput = GUI.TextField(new Rect(loginUsernameX, loginUsernameY, loginUsernameWidth, loginUsernameHeight), userNameInput, 9);

        GUI.Label(new Rect(loginPasswordX, passwordLabelY, loginPasswordWidth, loginPasswordHeight), "Password:");
        passwordInput = GUI.PasswordField(new Rect(loginPasswordX, loginPasswordY, loginPasswordWidth, loginPasswordHeight), passwordInput, '*', 9);

        if (GUI.Button(new Rect(loginButtonX, loginButtonY, loginButtonWidth, loginButtonHeight), "Log In"))
        {
            Login();
        }

        if (GUI.Button(new Rect(0, createAccountButtonY, createAcountButtonWidth, loginButtonHeight), "Create Account"))
        {
            CreateAccount();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Login();
        }
    }

    void Login()
    {
        //Take the input and try to sign in

        print(userNameInput + " : " + passwordInput);

        SceneManager.LoadScene(2);
    }

    void CreateAccount()
    {
        print("Create New User Account");

        SceneManager.LoadScene(3);
    }

}
