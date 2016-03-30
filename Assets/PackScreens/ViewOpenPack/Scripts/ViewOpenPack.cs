using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ViewOpenPack : MonoBehaviour {

    public Texture backgroundTexture;

    public Texture[] cardTypeImages;
    public Texture[] cardSubTypeImages;
    public Texture2D cardImage;

    public List<Card> cards;
    public int currentIndex = 0;

    public float cardY;
    public float cardX;
    public float cardHeight;
    public float cardWidth;

    public float cardImageX;
    public float cardImageY;
    public float cardImageWidth;
    public float cardImageHeight;

    public float cardNameY;
    public float cardNameX;
    public float cardNameWidth;
    public float cardNameHeight;
    public GUIStyle cardNameStyle;

    public float statX;
    public float statY;
    public float statWidth;
    public float statHeight;
    public int statNum = 0;
    public GUIStyle statStyle;

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

        GUI.DrawTexture(new Rect(cardX, cardY, cardWidth, cardHeight), cardTypeImages[(int)cards[currentIndex].CardType]);

        GUI.Label(new Rect(cardNameX, cardNameY, cardNameWidth, cardNameHeight), cards[currentIndex].Name, cardNameStyle);

        cardImage = Resources.Load("Cards/" + cards[currentIndex].CardID.ToString(), typeof(Texture2D)) as Texture2D;

        GUI.DrawTexture(new Rect(cardImageX, cardImageY, cardImageWidth, cardImageHeight), cardImage);

        statNum = 0;

        if (cards[currentIndex].AttackEffect != 0)
        {
            GUI.Label(new Rect(statX, statY + statNum*statHeight, statWidth, statHeight), "Attack: " + cards[currentIndex].AttackEffect.ToString(), statStyle);
            statNum++;
        }

        if (cards[currentIndex].DefenceEffect != 0)
        {
            GUI.Label(new Rect(statX, statY + statNum * statHeight, statWidth, statHeight), "Defence: " + cards[currentIndex].DefenceEffect.ToString(), statStyle);
            statNum++;
        }

        if (cards[currentIndex].SpeedEffect != 0)
        {
            GUI.Label(new Rect(statX, statY + statNum * statHeight, statWidth, statHeight), "Speed: " + cards[currentIndex].SpeedEffect.ToString(), statStyle);
            statNum++;
        }

        if (cards[currentIndex].HealthEffect != 0)
        {
            GUI.Label(new Rect(statX, statY + statNum * statHeight, statWidth, statHeight), "Health: " + cards[currentIndex].HealthEffect.ToString(), statStyle);
            statNum++;
        }

        GUI.Label(new Rect(statX, statY + 4 * statHeight, statWidth, statHeight), "Salvage Value: " + cards[currentIndex].SalvageValue.ToString(), statStyle);

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
        cardY = Screen.height * 0.10f;
        
        cardHeight = Screen.height *0.39604f * 1.5f;
        cardWidth = Screen.width * 0.51228f * 1.5f;

        cardX = (Screen.width - cardWidth)/2.0f;

        cardNameX = cardX + Screen.width * 0.11382f;
        cardNameY = cardY + Screen.height * 0.0300f;
        cardNameWidth = cardWidth - (cardNameX - cardX) * 2.0f;
        cardNameHeight = cardHeight * 0.11439f;

        cardNameStyle.fontSize = (int)(Screen.width * (1 / 18.0f));

        cardImageX = cardX + cardWidth * 0.164f;
        cardImageY = cardY + cardHeight * 0.1981f;
        cardImageWidth = cardWidth * 0.675f;
        cardImageHeight = cardHeight * 0.325f;

        statX = cardX;
        statY = cardY + cardHeight * 0.58118f;
        statWidth = cardWidth;
        statHeight = cardHeight * 0.075f;

        statStyle.fontSize = (int)(Screen.width * (1 / 19.0f));

        buttonY = cardY + cardHeight + Screen.height * 0.05f;
        buttonHeight = Screen.height * 0.075f;
        buttonWidth = Screen.width * 0.35f;
        nextButtonX = Screen.width - buttonWidth;
        prevButtonX = 0;

    }

    // Use this for initialization
    void Start ()
    {
        User user = GetCurrentInfo.User;

        if (GetCurrentInfo.TypeOfPackToOpen.packType == 1)
            cards = user.OpenBronzePack();
        else if (GetCurrentInfo.TypeOfPackToOpen.packType == 2)
            cards = user.OpenSilverPack();
        else
            cards = user.OpenGoldPack();
    }
}
