using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CardList : MonoBehaviour {

    User user;
    public GameObject itemPrefab;

	// Use this for initialization
	void Start ()
    {

        user = GetCurrentInfo.User;
        int max = user.Cards.Count;

        for (int i = 0; i < max; i++)
        {
            //create a new item, name it, and set the parent
            GameObject newItem = Instantiate(itemPrefab) as GameObject;

            newItem.name = i.ToString();
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
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
