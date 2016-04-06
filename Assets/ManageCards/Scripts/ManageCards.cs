using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Assets.Card_Data;
using System;
using UnityEngine.SceneManagement;

public class ManageCards : MonoBehaviour {

    public CardDatabase cardDatabase;
    public User user;
    public GameObject cardListPrefab;
    public GameObject cardPrefab;
    public GameObject gameList;
	public GameObject equippedCell;
    public int activeCardType;

    public void HeadClick()
    {
        activeCardType = 0;
        ShowCardList(activeCardType);
    }

    public void ChestClick()
    {
        activeCardType = 1;
        ShowCardList(activeCardType);
    }

    public void LeftHandClick()
    {
        activeCardType = 2;
        ShowCardList(activeCardType);
    }

    public void RightHandClick()
    {
        activeCardType = 3;
        ShowCardList(activeCardType);
    }

    public void Support1Click()
    {
        activeCardType = 4;
        ShowCardList(activeCardType);
    }

    public void Support2Click()
    {
        activeCardType = 5;
        ShowCardList(activeCardType);
    }

    public void Support3Click()
    {
        activeCardType = 6;
        ShowCardList(activeCardType);
    }

    public void Support4Click()
    {
        activeCardType = 7;
        ShowCardList(activeCardType);
    }

    public void Support5Click()
    {
        activeCardType = 8;
        ShowCardList(activeCardType);
    }

    public void ShowCardList(int typeOfCards)
    {
        if (gameList != null) Destroy(gameList);

        //create a new item, name it, and set the parent
        gameList = Instantiate(cardListPrefab) as GameObject;
        gameList.name = "DynamicCardListPanel";
        gameList.transform.SetParent(gameObject.transform, false);

        List<Card> cards = new List<Card>();

		Card currentlyEquippedCard = null;

        switch (typeOfCards)
        {
            case 0:
                //Head Armor
				currentlyEquippedCard = user.Avocado.HeadArmor;
                cards = new List<Card>(user.HeadArmorCards);
                break;
            case 1:
                //Chest Armor
				currentlyEquippedCard = user.Avocado.ChestArmor;
                cards = new List<Card>(user.ChestArmorCards);
                break;
            case 2:
                //Left Hand
				currentlyEquippedCard = user.Avocado.LeftHandWeapon;
                cards = new List<Card>(user.WeaponCards);
                break;
            case 3:
                //Right Hand
				currentlyEquippedCard = user.Avocado.RightHandWeapon;
                cards = new List<Card>(user.WeaponCards);
                break;
            case 4:
                //Support 1
                cards = new List<Card>(user.SupportCards);
                break;
            case 5:
                //Support 2
                cards = new List<Card>(user.SupportCards);
                break;
            case 6:
                //Support 3
                cards = new List<Card>(user.SupportCards);

                break;
            case 7:
                //Support 4
                cards = new List<Card>(user.SupportCards);
                break;
            case 8:
                //Support 5
                cards = new List<Card>(user.SupportCards);
                break;
        }

		if (currentlyEquippedCard != null) {
			
			equippedCell = Instantiate (cardPrefab) as GameObject;

			equippedCell.name = currentlyEquippedCard.CardID.ToString ();
			var textlLabels = equippedCell.GetComponentsInChildren<Text> ();

			textlLabels [0].text = currentlyEquippedCard.Name;
			//Attack
			textlLabels [1].text = "Atk:  " + currentlyEquippedCard.AttackEffect.ToString ();
			//Defence
			textlLabels [2].text = "Def:  " + currentlyEquippedCard.DefenceEffect.ToString ();
			//Health
			textlLabels [3].text = "H/P:  " + currentlyEquippedCard.HealthEffect.ToString ();
			//Speed
			textlLabels [4].text = "Spd:  " + currentlyEquippedCard.SpeedEffect.ToString ();

			equippedCell.transform.SetParent(gameObject.transform, false);
		}

        int max = cards.Count;

        for (int i = 0; i < max; i++)
        {
            //create a new item, name it, and set the parent
            GameObject newItem = Instantiate(cardPrefab) as GameObject;

            newItem.name = cards[i].CardID.ToString();
            var labels = newItem.GetComponentsInChildren<Text>();

            labels[0].text = cards[i].Name;
            //Attack
            labels[1].text = "Atk:  " + cards[i].AttackEffect.ToString();
            //Defence
            labels[2].text = "Def:  " + cards[i].DefenceEffect.ToString();
            //Health
            labels[3].text = "H/P:  " + cards[i].HealthEffect.ToString();
            //Speed
            labels[4].text = "Spd:  " + cards[i].SpeedEffect.ToString();

            newItem.transform.parent = gameList.transform.FindChild("CardList").transform.FindChild("Grid").transform;
        }
    }

    public void cardSelected(GameObject sender)
    {
        Card card = user.Cards.Find(x => x.CardID == Int32.Parse(sender.name));

        switch (activeCardType)
        {
            case 0:
                //Head Armor
                user.EquipCardToAvocado(card);

                break;
            case 1:
                //Chest Armor
                user.EquipCardToAvocado(card);

                break;
            case 2:
                //Left Hand
                user.EquipLeftHandWeapon(card);

                break;
            case 3:
                //Right Hand
                user.EquipRightHandWeapon(card);

                break;
            case 4:
                //Support 1
                user.EquipCardToAvocado(card);

                break;
            case 5:
                //Support 2
                user.EquipCardToAvocado(card);

                break;
            case 6:
                //Support 3
                user.EquipCardToAvocado(card);

                break;
            case 7:
                //Support 4
                user.EquipCardToAvocado(card);

                break;
            case 8:
                //Support 5
                user.EquipCardToAvocado(card);

                break;
        }

        UpdateImages();

        Destroy(gameList);
    }

    public void OpenPacks()
    {
        SceneManager.LoadScene(5);
    }

    public void ViewCollection()
    {
        SceneManager.LoadScene(10);
    }

    public void Back()
    {
        SceneManager.LoadScene(2);
    }

    public void cardListBack(GameObject sender)
    {
        Destroy(sender);
		Destroy (equippedCell);
    }

	// Use this for initialization
	void Start () {
        user = GetCurrentInfo.User;
        cardDatabase = new CardDatabase();

        UpdateImages();
    }
	
    void UpdateImages()
    {
        if (user.Avocado.LeftHandWeapon != null)
        {
            GameObject.Find("LeftHandImage").GetComponent<Image>().sprite = Resources.Load("Cards/" + user.Avocado.LeftHandWeapon.CardID.ToString(), typeof(Sprite)) as Sprite;
        }
        else
        {
            GameObject.Find("LeftHandImage").GetComponent<Image>().sprite = null;
        }

        if (user.Avocado.RightHandWeapon != null)
        {
            GameObject.Find("RightHandImage").GetComponent<Image>().sprite = Resources.Load("Cards/" + user.Avocado.RightHandWeapon.CardID.ToString(), typeof(Sprite)) as Sprite;
        }
        else
        {
            GameObject.Find("RightHandImage").GetComponent<Image>().sprite = null;
        }

        if (user.Avocado.HeadArmor != null)
        {
            GameObject.Find("HeadImage").GetComponent<Image>().sprite = Resources.Load("Cards/" + user.Avocado.HeadArmor.CardID.ToString(), typeof(Sprite)) as Sprite;
        }
        else
        {
            GameObject.Find("HeadImage").GetComponent<Image>().sprite = null;
        }

        if (user.Avocado.ChestArmor != null)
        {
            GameObject.Find("ChestImage").GetComponent<Image>().sprite = Resources.Load("Cards/" + user.Avocado.ChestArmor.CardID.ToString(), typeof(Sprite)) as Sprite;
        }
        else
        {
            GameObject.Find("ChestImage").GetComponent<Image>().sprite = null;
        }

        for (int i = 0; i < 5; i++)
        {
            if (i >= user.Avocado.SupportCards.Count)
            {
                GameObject.Find("SupportImage" + (i + 1).ToString()).GetComponent<Image>().sprite = null;
            }
            else
            {
                GameObject.Find("SupportImage" + (i + 1).ToString()).GetComponent<Image>().sprite = Resources.Load("Cards/" + user.Avocado.SupportCards[i].CardID.ToString(), typeof(Sprite)) as Sprite;
            }
        }

        var attack = GameObject.Find("AttackLabel").GetComponent<Text>();
        var defence = GameObject.Find("DefenceLabel").GetComponent<Text>();
        var health = GameObject.Find("HealthLabel").GetComponent<Text>();
        var speed = GameObject.Find("SpeedLabel").GetComponent<Text>();

        attack.text = "Attack: " + user.Avocado.Attack;
        defence.text = "Defence: " + user.Avocado.Defence;
        health.text = "Health: " + user.Avocado.MaxHealth;
        speed.text = "Speed: " + user.Avocado.Speed;
    }

	// Update is called once per frame
	void Update () {
	
	}
}
