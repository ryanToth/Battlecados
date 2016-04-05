using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour {

    public void onClick()
    {
        print("Back");
        //Go to Main Menu
        SceneManager.LoadScene(11);
    }
}
