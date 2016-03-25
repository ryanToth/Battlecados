using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

    private string _flavourText;

    public string FlavourText
    {
        get
        {
            return _flavourText;
        }
    }

    private int _cardID;

    public int CardID
    {
        get
        {
            return _cardID;
        }
    }

    private CardType _cardType;

    public CardType CardType
    {
        get
        {
            return _cardType;
        }
    }

    private CardRarity _cardRarity;

    public CardRarity CardRarity
    {
        get
        {
            return _cardRarity;
        }
    }

    private int _salvageValue;

    public int SalvageValue
    {
        get
        {
            return _salvageValue;
        }
    }

    private CardEffect _cardEffect;

    public Card(string flavourText, int cardID, int salvageValue, CardType cardType, CardRarity cardRarity, CardEffect cardEffect)
    {
        _flavourText = flavourText;
        _cardID = cardID;
        _salvageValue = salvageValue;
        _cardType = cardType;
        _cardRarity = cardRarity;
        _cardEffect = cardEffect;
    }

    // Returns the effect on the Attack stat that the card has
    public int AttackEffect
    {
        get
        {
            return _cardEffect.Attack;
        }
    }

    // Returns the effect on the Defence stat that the card has
    public int DefenceEffect
    {
        get
        {
            return _cardEffect.Defence;
        }
    }

    // Returns the effect on the Health stat that the card has
    public int HealthEffect
    {
        get
        {
            return _cardEffect.Health;
        }
    }

    // Returns the effect on the Speed stat that the card has
    public int SpeedEffect
    {
        get
        {
            return _cardEffect.Speed;
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

public enum CardType
{
    OneHandedWeapon = 0,
    TwoHandedWeapon = 1,
    HeadArmor = 2,
    ChestArmor = 3,
    Support = 4,
    Treasure = 5
}

public enum CardRarity
{
    Common = 0,
    Uncommon = 1,
    Rare = 2
}