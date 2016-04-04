using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class CardList : MonoBehaviour {

    User user;
    public GameObject itemPrefab;
    public GameObject areyousurePrefab;

    // Use this for initialization
    void Start ()
    {
        user = GetCurrentInfo.User;
        int max = 5;//user.Cards.Count;

        for (int i = 0; i < max; i++)
        {
            //create a new item, name it, and set the parent
            GameObject newItem = Instantiate(itemPrefab) as GameObject;

            newItem.name = user.Cards[i].CardID.ToString();
            var labels = newItem.GetComponentsInChildren<Text>();
            var image = newItem.GetComponentsInChildren<Image>();

            //Put cardID here cards[currentIndex].CardID.ToString()
            image[1].sprite = Resources.Load("Cards/" + user.Cards[i].CardID.ToString(), typeof(Sprite)) as Sprite;

            labels[0].text = user.Cards[i].Name;
            //Attack
            labels[6].text = user.Cards[i].AttackEffect.ToString();
            //Defence
            labels[7].text = user.Cards[i].DefenceEffect.ToString();
            //Health
            labels[8].text = user.Cards[i].HealthEffect.ToString();
            //Speed
            labels[9].text = user.Cards[i].SpeedEffect.ToString();
            //Salvage Value
            labels[10].text = user.Cards[i].SalvageValue.ToString();

            newItem.transform.parent = gameObject.transform;
        }

    }
	
    public void SalvageCard(GameObject cardTile)
    {
        var pos = new Vector3(0, 50, 0);
        var rot = Quaternion.identity;

        var cardInfo = cardTile.GetComponentsInChildren<Text>();

        string cardName = cardInfo[0].text;
        string cardID = cardTile.name;

        GameObject newItem = Instantiate(areyousurePrefab, pos, rot) as GameObject;

        var labels = newItem.GetComponentsInChildren<Text>();

        labels[0].text = "Salvage " + cardName + "?";

        newItem.name = cardID;

        newItem.transform.SetParent(gameObject.transform.parent.transform, false);
    }

    public void ConfirmSalvage(GameObject sender)
    {
        var labels = sender.GetComponentsInChildren<Text>();
        string name = sender.name;

        Destroy(sender);

        var things = GameObject.FindGameObjectsWithTag("CardTile");

        foreach(var cardTile in things)
        {
            if (cardTile.name == name)
            {
                var card = user.Cards.Find(x => x.CardID == Int32.Parse(name));
                user.SalvageCard(card);
                Destroy(cardTile);
                return;
            }
        }
    }

    public void CancelSalvage(GameObject sender)
    {
        Destroy(sender);
    }

	// Update is called once per frame
	void Update ()
    {
	
	}
}
