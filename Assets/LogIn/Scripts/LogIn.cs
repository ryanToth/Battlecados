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

    public string userNameInput = "";
    public string passwordInput = "";

    public Texture backgroundTexture;

    public void OnGUI()
    {
        loginButtonX = Screen.width * 0.33f;
        loginButtonY = Screen.height * 0.66f;
        loginButtonWidth = Screen.width * 0.33f;
        loginButtonHeight = Screen.height * 0.05f;

        loginUsernameX = Screen.width * 0.25f;
        loginUsernameY = Screen.height * 0.50f;
        loginUsernameWidth = Screen.width * 0.50f;
        loginUsernameHeight = 25;

        loginPasswordX = Screen.width * 0.25f;
        loginPasswordY = Screen.height * 0.58f;
        loginPasswordWidth = Screen.width * 0.50f;
        loginPasswordHeight = 25;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        userNameInput = GUI.TextField(new Rect(loginUsernameX, loginUsernameY, loginUsernameWidth, loginUsernameHeight), userNameInput);
        passwordInput = GUI.PasswordField(new Rect(loginPasswordX, loginPasswordY, loginPasswordWidth, loginPasswordHeight), passwordInput, '*');

        if (GUI.Button(new Rect(loginButtonX, loginButtonY, loginButtonWidth, loginButtonHeight), "Log In") || Event.current.keyCode == KeyCode.Return)
        {
            //Take the input and try to sign in

            print(userNameInput + " : " + passwordInput);

            SceneManager.LoadScene(2);
        }
    }

}
