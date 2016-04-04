using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Networking;
using UnityEngine.SceneManagement;
using Assets.Card_Data;

public class User : MonoBehaviour {

    
    private int _userCode;

    public int UserCode
    {
        get
        {
            return _userCode;
        }
    }

    private Avocado _avocado;

    public Avocado Avocado
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

    public IEnumerable<int> CardCollectionIDs
    {
        get
        {
            return from card in Cards select card.CardID;
        }
    }

    // Called on create new user
    public User(string username, int userCode)
    {
        _username = username;
        _userCode = userCode;
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
    public User(string username, int userCode, int gold, int bronzePacks, int silverPacks, int goldPacks, int storyLevel, Avocado avocado)
    {
        _username = username;
        _userCode = userCode;
        _gold = gold;
        _bronzePacks = bronzePacks;
        _silverPacks = silverPacks;
        _goldPacks = goldPacks;
        _storyLevel = storyLevel;

        _avocado = avocado;
        // Should have some code here to initialize the User's Cards list
    }

    // Called any other time a user logs in successfully
    public void SetValues(string username, int userCode, int gold, int bronzePacks, int silverPacks, int goldPacks, int storyLevel, Avocado avocado, IEnumerable<int> userCards, IEnumerable<int> avocadoCards)
    {
        _username = username;
        _userCode = userCode;
        _gold = gold;
        _bronzePacks = bronzePacks;
        _silverPacks = silverPacks;
        _goldPacks = goldPacks;
        _storyLevel = storyLevel;

        _avocado = avocado;

        // Should have some code here to initialize the User's Cards list

        CardDatabase cardDatabase = new CardDatabase();

        _cards = cardDatabase.GetCardsInfo(userCards);

        List<Card> cadoCards = cardDatabase.GetCardsInfo(avocadoCards);

        // Make switch statement later
        foreach (Card card in cadoCards)
        {
            CardType type = card.CardType;
            switch (type)
            {
                case CardType.OneHandedWeapon:
                    if (_avocado.RightHandWeapon != null)
                    {
                        _avocado.EquipRightHandWeapon(card);
                    }
                    else
                    {
                        _avocado.EquipLeftHandWeapon(card);
                    }
                    break;
                case CardType.TwoHandedWeapon:
                    _avocado.EquipTwoHandWeapon(card);
                    break;
                case CardType.Support:
                    _avocado.TryEquipSupportCard(card);
                    break;
                case CardType.ChestArmor:
                    _avocado.EquipChestArmor(card);
                    break;
                case CardType.HeadArmor:
                    _avocado.EquipHeadArmor(card);
                    break;
            }
        }
    }

    //Copy constructor
    public void CopyUser(User user)
    {
        _username = user.Username;
        _userCode = user.UserCode;
        _gold = user.Gold;
        _bronzePacks = user.BronzePacks;
        _silverPacks = user.SilverPacks;
        _goldPacks = user.GoldPacks;
        _storyLevel = user.StoryLevel;

        _avocado = user.Avocado;
    }

    // After every battle, this function is called to reward the player
    public void BattleCompleted(int goldGained, int experienceGained)
    {
        _gold += goldGained;
        _avocado.GainExperiencePoints(experienceGained);

        SaveManager.TrySaveBattleResults(_userCode, _avocado.Level, _avocado.ExperiencePointsToNextLevel, _gold);
    }

    // Returns true if pack was successfully purchased, false otherwise
    public bool BuyBronzePack(int price)
    {
        if (_gold >= price)
        {
            _bronzePacks++;
            _gold -= price;

            SaveManager.TryBuyPack(_userCode, _bronzePacks, _silverPacks, _goldPacks, _gold);

            return true;
        }

        return false;
    }

    // Returns true if pack was successfully purchased, false otherwise
    public bool BuySilverPack(int price)
    {
        if (_gold >= price)
        {
            _silverPacks++;
            _gold -= price;

            SaveManager.TryBuyPack(_userCode, _bronzePacks, _silverPacks, _goldPacks, _gold);

            return true;
        }
        return false;
    }

    // Returns true if pack was successfully purchased, false otherwise
    public bool BuyGoldPack(int price)
    {
        if (_gold >= price)
        {
            _goldPacks++;
            _gold -= price;

            SaveManager.TryBuyPack(_userCode, _bronzePacks, _silverPacks, _goldPacks, _gold);

            return true;
        }
        return false;
    }

    // Remove card from collection and add its salvage value to the User's gold
    public void SalvageCard(Card card)
    {
        if (Cards.Remove(card))
        {
            _gold += card.SalvageValue;

            SaveManager.TrySellCard(_userCode, _gold, card.CardID);
        }
    }

    // This function is called whenever the user moves to the next level in the story mode
    public void GoToNextLevel()
    {
        _storyLevel++;

        SaveManager.TryGoToNextLevel(_userCode, _storyLevel);
    }

    public void EquipRightHandWeapon(Card card)
    {
        if (card.CardType != CardType.OneHandedWeapon) return;

        _avocado.EquipRightHandWeapon(card);
        Cards.Remove(card);

        SaveManager.TryEquipCardToAvocado(_userCode, card.CardID);
    }

    public void EquipLeftHandWeapon(Card card)
    {
        if (card.CardType != CardType.OneHandedWeapon) return;

        _avocado.EquipLeftHandWeapon(card);
        Cards.Remove(card);

        SaveManager.TryEquipCardToAvocado(_userCode, card.CardID);
    }

    // Used to equip cards to avocados, except for one handed weapons, removes the card from the User's card collection so they cannot equip the same card multiple times
    public void EquipCardToAvocado(Card card)
    {
        switch (card.CardType)
        {
            case CardType.TwoHandedWeapon:

                if (Cards.Remove(card)) _avocado.EquipTwoHandWeapon(card);
                break;

            case CardType.HeadArmor:

                if (Cards.Remove(card)) _avocado.EquipHeadArmor(card);
                break;

            case CardType.ChestArmor:

                if (Cards.Remove(card)) _avocado.EquipChestArmor(card);
                break;

            case CardType.Support:

                if (_avocado.TryEquipSupportCard(card)) Cards.Remove(card);
                break;
        }

        SaveManager.TryEquipCardToAvocado(_userCode, card.CardID);
    }

    // Unequips the card from the avocado and returns it to the User's card collection
    public void UnequipRightHandWeapon()
    {
        Card card = _avocado.UnequipRightHandWeapon();

        if (card != null)
        {
            Cards.Add(card);
            SaveManager.TryUnequipCardToAvocado(_userCode, card.CardID);
        }
    }

    // Unequips the card from the avocado and returns it to the User's card collection
    public void UnequipLeftHandWeapon()
    {
        Card card = _avocado.UnequipLeftHandWeapon();

        if (card != null)
        {
            Cards.Add(card);
            SaveManager.TryUnequipCardToAvocado(_userCode, card.CardID);
        }
    }

    // Used to unequip any card attached to an avocado except for support cards and one handed weapons. Returns the card to the User's card collection
    public void UnequipCard(CardType cardType)
    {
        Card card = null;

        switch (cardType)
        {
            case CardType.TwoHandedWeapon:

                card = _avocado.UnequipTwoHandedWeapon();
                break;
            case CardType.HeadArmor:

                card = _avocado.UnequipHeadArmor();
                break;
            case CardType.ChestArmor:

                card = _avocado.UnequipChestArmor();
                break;
        }

        if (card != null)
        {
            Cards.Add(card);
            SaveManager.TryUnequipCardToAvocado(_userCode, card.CardID);
        }
    }

    // Unequips the support card at the specified index from the avocado and returns it to the User's card collection
    public void UnequipSupportCard(int index)
    {
        Card card = _avocado.UnequipSupportCard(index);

        if (card != null)
        {
            Cards.Add(card);
            SaveManager.TryUnequipCardToAvocado(_userCode, card.CardID);
        }
    }

    public List<Card> OpenBronzePack()
    {
        if (_bronzePacks > 0)
        {
            BronzePack pack = new BronzePack();
            List<Card> newCards = pack.Open();
            Cards.AddRange(newCards);
            _bronzePacks--;

            SaveManager.TryOpenPack(_userCode, _bronzePacks, _silverPacks, _goldPacks, newCards);

            return newCards;
        }
        return null;
    }

    public List<Card> OpenSilverPack()
    {
        if (_silverPacks > 0)
        {
            SilverPack pack = new SilverPack();
            List<Card> newCards = pack.Open();
            Cards.AddRange(newCards);
            _silverPacks--;

            SaveManager.TryOpenPack(_userCode, _bronzePacks, _silverPacks, _goldPacks, newCards);

            return newCards;
        }
        return null;
    }

    public List<Card> OpenGoldPack()
    {
        if (_goldPacks > 0)
        {
            GoldPack pack = new GoldPack();
            List<Card> newCards = pack.Open();
            Cards.AddRange(newCards);
            _goldPacks--;

            SaveManager.TryOpenPack(_userCode, _bronzePacks, _silverPacks, _goldPacks, newCards);

            return newCards;
        }
        return null;
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start () {
        SceneManager.LoadScene(0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
