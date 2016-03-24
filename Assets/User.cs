using UnityEngine;
using System.Collections;

public class User : MonoBehaviour {

    private Avocado _avocado;

    public Avocado Acocado
    {
        get
        {
            return _avocado;
        }
    }

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

    // This function is called whenever the user moves to the next level in the story mode
    public void goToNextLevel()
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
