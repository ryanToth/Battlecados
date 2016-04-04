using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ConnectingScreen : MonoBehaviour {

    public Texture backgroundTexture;
    public float framesPerSecond = 10.0f;

    public Texture[] loadingIcon;
    public float loadingX;
    public float loadingY;
    public float loadingWidth;
    public float loadingHeight;

    public float messageX;
    public float messageY;
    public float messageWidth;
    public float messageHeight;
    public GUIStyle messageStyle;

    void OnGUI()
    {
        SetRelativeComponentSizes();

        //Display our background texture     
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        // Connecting Message
        GUI.Label(new Rect(messageX, messageY, messageWidth, messageHeight), "Connecting You To An Opponent", messageStyle);

        // Loading Icon
        int index = (int)((Time.time * framesPerSecond) % loadingIcon.Length);
        GUI.DrawTexture(new Rect(loadingX, loadingY, loadingWidth, loadingHeight), loadingIcon[index]);

        // Cancel Button
        if (GUI.Button(new Rect(CommonElementSizes.backX, CommonElementSizes.backY, CommonElementSizes.backWidth, CommonElementSizes.backHeight), "Cancel")) 
        {
            // Do cancel try to connect stuff
            print("Cancel");
            SceneManager.LoadScene(2);
        }
    }

	// Use this for initialization
	void Start ()
    {

        TryToConnect();

	}

    // Should be an async function
    private bool TryToConnect()
    {
        return true;
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void SetRelativeComponentSizes()
    {
        messageX = 0;
        messageY = Screen.height * 0.175f;
        messageWidth = Screen.width;
        messageHeight = Screen.height * 0.075f;
        messageStyle.fontSize = (int)(Screen.width * 0.065);

        loadingWidth = Screen.width * 0.33f;
        loadingHeight = loadingWidth;
        loadingX = (Screen.width - loadingWidth) / 2;
        loadingY = Screen.height * 0.33f;
    }
}
