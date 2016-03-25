using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class User : MonoBehaviour {

    private Avocado _avocado;

    public Avocado Acocado
    {
        get
        {
            return _avocado;
        }
    }

    private List<Card> _cards;

    public List<Card> Cards
    {
        get
        {
            if (_cards == null)
            {
                _cards = new List<Card>();
            }

            return _cards;
        }
    }

    private string _username;

    public string Username
    {
        get
        {
            return _username;
        }
    }

    private int _gold;

    public int Gold
    {
        get
        {
            return _gold;
        }
    }

    private int _bronzePacks;

    public int BronzePacks
    {
        get
        {
            return _bronzePacks;
        }
    }

    private int _silverPacks;

    public int SilverPacks
    {
        get
        {
            return _silverPacks;
        }
    }

    private int _goldPacks;

    public int GoldPacks
    {
        get
        {
            return _goldPacks;
        }
    }

    private int _storyLevel;

    public int StoryLevel
    {
        get
        {
            return _storyLevel;
        }
    }

    public IEnumerable<Card> OneHandedWeaponCards
    {
        get
        {
            return from card in Cards where card.CardType == CardType.OneHandedWeapon select card;
        }
    }

    public IEnumerable<Card> TwoHandedWeaponCards
    {
        get
        {
            return from card in Cards where card.CardType == CardType.TwoHandedWeapon select card;
        }
    }

    public IEnumerable<Card> HeadArmorCards
    {
        get
        {
            return from card in Cards where card.CardType == CardType.HeadArmor select card;
        }
    }

    public IEnumerable<Card> ChestArmorCards
    {
        get
        {
            return from card in Cards where card.CardType == CardType.ChestArmor select card;
        }
    }

    public IEnumerable<Card> LegArmorCards
    {
        get
        {
            return from card in Cards where card.CardType == CardType.LegArmor select card;
        }
    }

    public IEnumerable<Card> ArmArmorCards
    {
        get
        {
            return from card in Cards where card.CardType == CardType.ArmArmor select card;
        }
    }

    public IEnumerable<Card> SupportCards
    {
        get
        {
            return from card in Cards where card.CardType == CardType.Support select card;
        }
    }

    public IEnumerable<Card> ArmorCards
    {
        get
        {
            return from card in Cards where card.CardType == CardType.ChestArmor 
                   || card.CardType == CardType.ArmArmor || card.CardType == CardType.LegArmor
                   || card.CardType == CardType.HeadArmor select card;
        }
    }

    public IEnumerable<Card> WeaponCards
    {
        get
        {
            return from card in Cards
                   where card.CardType == CardType.OneHandedWeapon || card.CardType == CardType.TwoHandedWeapon 
                   select card;
        }
    }

    // Called on create new user
    public User(string username)
    {
        _username = username;
        _gold = 0;
        // Start them off with some packs to start?
        _bronzePacks = 3;
        _silverPacks = 2;
        _goldPacks = 1;
        // Start them off on level 1
        _storyLevel = 1;
        // Create them a new avocado

        _avocado = new Avocado();
    }

    // Called any other time a user logs in successfully
    public User(string username, int gold, int bronzePacks, int silverPacks, int goldPacks, int storyLevel, Avocado avocado)
    {
        _username = username;
        _gold = gold;
        _bronzePacks = bronzePacks;
        _silverPacks = silverPacks;
        _goldPacks = goldPacks;
        _storyLevel = storyLevel;

        _avocado = avocado;

        // Should have some code here to initialize the User's Cards list
    }

    // After every battle, this function is called to reward the player
    public void battleCompleted(int goldGained, int experienceGained)
    {
        _gold += goldGained;
        _avocado.GainExperiencePoints(experienceGained);
    }

    // Returns true if pack was successfully purchased, false otherwise
    public bool buyBronzePack(int price)
    {
        if (_gold >= price)
        {
            _bronzePacks++;
            _gold -= price;

            return true;
        }
        return false;
    }

    // Returns true if pack was successfully purchased, false otherwise
    public bool buySilverPack(int price)
    {
        if (_gold >= price)
        {
            _silverPacks++;
            _gold -= price;

            return true;
        }
        return false;
    }

    // Returns true if pack was successfully purchased, false otherwise
    public bool buyGoldPack(int price)
    {
        if (_gold >= price)
        {
            _goldPacks++;
            _gold -= price;

            return true;
        }
        return false;
    }

    // Returns true if the user has packs to be opened, false otherwise
    public bool openBronzePack()
    {
        if (_bronzePacks > 0)
        {
            _bronzePacks--;
            return true;
        }
        return false;
    }

    // Returns true if the user has packs to be opened, false otherwise
    public bool openSilverPack()
    {
        if (_silverPacks > 0)
        {
            _silverPacks--;
            return true;
        }
        return false;
    }

    // Returns true if the user has packs to be opened, false otherwise
    public bool openGoldPack()
    {
        if (_goldPacks > 0)
        {
            _goldPacks--;
            return true;
        }
        return false;
    }

    // Remove card from collection and add its salvage value to the User's gold
    public void salvageCard(Card card)
    {
        if (Cards.Remove(card))
        {
            _gold += card.SalvageValue;
        }
    }

    // This function is called whenever the user moves to the next level in the story mode
    public void goToNextLevel()
    {
        _storyLevel++;
    }

    public void equipRightHandWeapon(Card card)
    {
        if (card.CardType != CardType.OneHandedWeapon) return;

        _avocado.equipRightHandWeapon(card);
        Cards.Remove(card);
    }

    public void equipLeftHandWeapon(Card card)
    {
        if (card.CardType != CardType.OneHandedWeapon) return;

        _avocado.equipLeftHandWeapon(card);
        Cards.Remove(card);
    }

    // Used to equip cards to avocados, except for one handed weapons, removes the card from the User's card collection so they cannot equip the ame card multiple times
    public void equipCardToAvocado(Card card)
    {

        switch (card.CardType)
        {
            case CardType.TwoHandedWeapon:

                if (Cards.Remove(card)) _avocado.equipTwoHandWeapon(card);
                break;

            case CardType.HeadArmor:

                if (Cards.Remove(card)) _avocado.equipHeadArmor(card);
                break;

            case CardType.ChestArmor:

                if (Cards.Remove(card)) _avocado.equipChestArmor(card);
                break;

            case CardType.LegArmor:

                if (Cards.Remove(card)) _avocado.equipLegArmor(card);
                break;

            case CardType.ArmArmor:

                if (Cards.Remove(card)) _avocado.equipArmArmor(card);
                break;

            case CardType.Support:

                if (_avocado.tryEquipSupportCard(card)) Cards.Remove(card);
                break;
        }
    }

    // Unequips the card from the avocado and returns it to the User's card collection
    public void unequipRightHandWeapon()
    {
        Card card = _avocado.unequipRightHandWeapon();

        if (card != null) Cards.Add(card);
    }

    // Unequips the card from the avocado and returns it to the User's card collection
    public void unequipLeftHandWeapon()
    {
        Card card = _avocado.unequipLeftHandWeapon();

        if (card != null) Cards.Add(card);
    }

    // Used to unequip any card attached to an avocado except for support cards and one handed weapons. Returns the card to the User's card collection
    public void unequipCard(CardType cardType)
    {
        Card card = null;

        switch (cardType)
        {
            case CardType.TwoHandedWeapon:

                card = _avocado.unequipTwoHandedWeapon();
                break;
            case CardType.HeadArmor:

                card = _avocado.unequipHeadArmor();
                break;
            case CardType.ChestArmor:

                card = _avocado.unequipChestArmor();
                break;
            case CardType.LegArmor:

                card = _avocado.unequipLegArmor();
                break;
            case CardType.ArmArmor:

                card = _avocado.unequipArmArmor();
                break;
        }

        if (card != null) Cards.Add(card);
    }

    // Unequips the card from the avocado and returns it to the User's card collection
    public void unequipSupportCard(int index)
    {
        Card card = _avocado.unequipSupportCard(index);

        if (card != null) Cards.Add(card);
    }

    public void OpenBronzePack()
    {
        if (_bronzePacks > 0)
        {
            BronzePack pack = new BronzePack();
            Cards.AddRange(pack.Open());
            _bronzePacks--;
        }
    }

    public void OpenSilverPack()
    {
        if (_silverPacks > 0)
        {
            SilverPack pack = new SilverPack();
            Cards.AddRange(pack.Open());
            _silverPacks--;
        }
    }

    public void OpenGoldPack()
    {
        if (_goldPacks > 0)
        {
            GoldPack pack = new GoldPack();
            Cards.AddRange(pack.Open());
            _goldPacks--;
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
