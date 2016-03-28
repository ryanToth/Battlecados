using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ViewOpenPack : MonoBehaviour {

    public Texture backgroundTexture;
    public Texture2D[] cardImages;
    public List<Card> cards;
    public int currentIndex = 0;

    public float cardY;
    public float cardX;
    public float cardHeight;
    public float cardWidth;

    public float buttonY;
    public float nextButtonX;
    public float prevButtonX;
    public float buttonWidth;
    public float buttonHeight;

    public string nextButtonText = "Next";

    void OnGUI()
    {
        SetRelativeComponentSizes();

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        GUI.DrawTexture(new Rect(cardX, cardY, cardWidth, cardHeight), cardImages[currentIndex]);

        if (currentIndex != 0)
        {
            if (GUI.Button(new Rect(prevButtonX, buttonY, buttonWidth, buttonHeight), "Previous"))
            {
                if (currentIndex == cards.Count-1)
                {
                    nextButtonText = "Next";
                }

                currentIndex--;
            }
        }

        if (GUI.Button(new Rect(nextButtonX, buttonY, buttonWidth, buttonHeight), nextButtonText))
        {
            if (currentIndex == cards.Count-1)
            {
                // Go back to other screen if on last card
                SceneManager.LoadScene(5);
            }
            else
            {
                currentIndex++;

                if (currentIndex == cards.Count-1)
                {
                    nextButtonText = "Done";
                }
            }
        }
    }

    private void SetRelativeComponentSizes()
    {
        cardY = Screen.height * 0.25f;
        
        cardHeight = Screen.height *0.39604f;
        cardWidth = Screen.width * 0.51228f;

        cardX = (Screen.width - cardWidth)/2.0f;

        buttonY = cardY + cardHeight + Screen.height * 0.05f;
        buttonHeight = Screen.height * 0.075f;
        buttonWidth = Screen.width * 0.35f;
        nextButtonX = Screen.width - buttonWidth;
        prevButtonX = 0;

    }

    // Use this for initialization
    void Start () {

        cards = new BronzePack().Open();

	}
}
