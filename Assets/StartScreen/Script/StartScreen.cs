using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartScreen : MonoBehaviour {

    public Texture backgroundTexture;

    void OnGUI()
    {
        //Display our background texture     
        GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), backgroundTexture);

        if (Event.current.type == EventType.KeyDown || Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(1);
        }

    }
}
