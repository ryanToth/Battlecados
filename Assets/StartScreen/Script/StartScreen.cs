using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Assets.Networking;

public class StartScreen : MonoBehaviour {

    public Texture2D[] backgroundTexture;
	public Texture2D bg;
	public Texture2D hill;
	public Texture2D lGrass;
	public Texture2D dGrass;
	public Texture2D trunk;
	public Texture2D leaves;
	public Texture2D cloud1;
	public Texture2D cloud2;
	public Texture2D cloud3;
	public Texture2D stars;
	public Texture2D title;
	public Texture2D start;

	public Animator anim;

    float framesPerSecond = 30.0f;

	float xCloud1 = 0;
	float xCloud2 = 0;
	float xCloud3 = 0;

	void nextScreen(){
		SceneManager.LoadScene(1);
	}

    void OnGUI()
    {
        //Display our background texture     
        //int index = (int)((Time.time * framesPerSecond) % backgroundTexture.Length);
        //GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture[index]);
		/*
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), bg);
		GUI.DrawTexture(new Rect(0, 500, Screen.width, Screen.height), hill);
		GUI.DrawTexture(new Rect(0, 500, Screen.width, Screen.height), dGrass);
		GUI.DrawTexture(new Rect(0, 500, Screen.width, Screen.height), lGrass);
		GUI.DrawTexture(new Rect(0, 500, Screen.width, Screen.height), trunk);
		GUI.DrawTexture(new Rect(0, 500, Screen.width, Screen.height), leaves);
		GUI.DrawTexture(new Rect(xCloud1, 0, Screen.width, Screen.height), cloud1);
		GUI.DrawTexture(new Rect(xCloud2, 0, Screen.width, Screen.height), cloud2);
		GUI.DrawTexture(new Rect(xCloud3, 0, Screen.width, Screen.height), cloud3);
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), stars);
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), title);
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), start);
		*/

		if(xCloud1 <= -100){
			xCloud1 = Screen.width;
		}
		else {
			xCloud1 -= 0.2f;
		}

		if(xCloud2 <= -300){
			xCloud2 = Screen.width;
		}
		else {
			xCloud2 -= 0.4f;
		}

		if(xCloud3 <= -400){
			xCloud3 = Screen.width;
		}
		else {
			xCloud3 -= 0.3f;
		}


        if (Event.current.type == EventType.KeyDown || Input.GetMouseButtonDown(0))
        {
			anim.Play ("Transition");
			//yield WaitForSeconds(2);
			//SceneManager.LoadScene(1);
			Invoke("nextScreen", 2.0f);
        }
    }

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
        }
        */
    }

    void Start()
    {
        // set the desired aspect ratio 
        float targetaspect = 285.0f / 505.0f;

        // determine the game window's current aspect ratio
        float windowaspect = (float)Screen.width / (float)Screen.height;

        // current viewport height should be scaled by this amount
        float scaleheight = windowaspect / targetaspect;

        // obtain camera component so we can modify its viewport
        Camera camera = GetComponent<Camera>();

		// get the animator
		anim = GameObject.Find("Canvas").GetComponent<Animator>();
		//anim = GetComponent<Animator> ();

        // if scaled height is less than current height, add letterbox
        if (scaleheight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            camera.rect = rect;
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }
}