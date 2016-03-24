using UnityEngine;
using System.Collections;

public class User : MonoBehaviour {

    private string _username;

    public string Username
    {
        get {
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
    }

    // Called any other time a user logs in successfully
    public User(string username, int gold, int bronzePacks, int silverPacks, int goldPacks, int storyLevel)
    {
        _username = username;
        _gold = gold;
        _bronzePacks = bronzePacks;
        _silverPacks = silverPacks;
        _goldPacks = goldPacks;
        _storyLevel = storyLevel;
    }

    // After every battle, this function is called to reward the player
    public void BattleCompleted(int goldGained, int experienceGained)
    {
        _gold += goldGained;
        // Once avocado class is implemented, increase its experience
    }

    // Returns true if pack was successfully purchased, false otherwise
    public bool BuyBronzePack(int price)
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
    public bool BuySilverPack(int price)
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
    public bool BuyGoldPack(int price)
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
    public bool OpenBronzePack()
    {
        if (_bronzePacks > 0)
        {
            _bronzePacks--;
            return true;
        }
        return false;
    }

    // Returns true if the user has packs to be opened, false otherwise
    public bool OpenSilverPack()
    {
        if (_silverPacks > 0)
        {
            _silverPacks--;
            return true;
        }
        return false;
    }

    // Returns true if the user has packs to be opened, false otherwise
    public bool OpenGoldPack()
    {
        if (_goldPacks > 0)
        {
            _goldPacks--;
            return true;
        }
        return false;
    }

    public void GoToNextLevel()
    {
        _storyLevel++;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
