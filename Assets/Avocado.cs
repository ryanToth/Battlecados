using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Avocado : MonoBehaviour {

    private int _level;

    public int Level
    {
        get
        {
            return _level;
        }
    }

    private int _experiencePoints;

    public int ExperiencePoints
    {
        get
        {
            return _experiencePoints;
        }
    }

    private Card _rightHandWeapon;

    public Card RightHandWeapon
    {
        get
        {
            return _rightHandWeapon;
        }
    }

    private Card _leftHandWeapon;

    public Card LeftHandWeapon
    {
        get
        {
            return _leftHandWeapon;
        }
    }

    private Card _twoHandedWeapon;

    public Card TwoHandedWeapon
    {
        get
        {
            return _twoHandedWeapon;
        }
    }

    private Card _headArmor;

    public Card HeadArmor
    {
        get
        {
            return _headArmor;
        }
    }

    private Card _chestArmor;

    public Card ChestArmor
    {
        get
        {
            return _chestArmor;
        }
    }

    private List<Card> _supportCards;

    public List<Card> SupportCards
    {
        get
        {
            if (_supportCards == null)
            {
                _supportCards = new List<Card>();
            }

            return _supportCards;
        }
    }

    private int _remainingHealth;

    public int RemainingHealth
    {
        get
        {
            if (_remainingHealth < 0) return 0;

            return _remainingHealth;
        }
    }

    // Default constructor for an Avocado
    public Avocado()
    {
        _level = 1;
        _experiencePoints = 0;
        _remainingHealth = MaxHealth;
    }

    // Avocado constructor for existing avocados
    public Avocado(int level, int experiencePoints, Card rightHandedWeapon, Card leftHandedWeapon, Card twoHandedWeapon,
        Card headArmor, Card chestArmor, List<Card> supportCards)
    {
        _level = level;
        _experiencePoints = experiencePoints;
        _rightHandWeapon = rightHandedWeapon;
        _leftHandWeapon = leftHandedWeapon;
        _twoHandedWeapon = twoHandedWeapon;
        _headArmor = headArmor;
        _chestArmor = chestArmor;
        _supportCards = supportCards;
        _remainingHealth = MaxHealth;
    }

    // Dictates how much experience is needed in order to level up
    public int ExperiencePointsToNextLevel
    {
        get
        {
            return _level * 150;
        }
    }

    // Return true if level up occurs, false otherwise
    public bool GainExperiencePoints(int experience)
    {
        _experiencePoints += experience;

        if (_experiencePoints >= ExperiencePointsToNextLevel)
        {
            _experiencePoints -= ExperiencePointsToNextLevel;
            _level++;

            return true;
        }
        return false;
    }

    // The Avocado's health, if card bonuses drop it below 0, return 1
    public int MaxHealth
    {
        get
        {
            int health = _level * 10 + CardHealthBonus;

            if (health > 0) return health;

            return 1;
        }
    }

    // Lower the avocado's remaining health by the amount of damage taken, return true if the avocado has died, false otherwise
    public bool RecieveDamage(int damage)
    {
        _remainingHealth -= damage;

        return IsDead;
    }

    public bool IsDead
    {
        get
        {
            return _remainingHealth <= 0;
        }
    }

    // The Avocado's attack, if card bonuses drop it below 0, return 1
    public int Attack
    {
        get
        {
            int attack = _level * 10 + CardHealthBonus;

            if (attack > 0) return attack;

            return 1;
        }
    }

    // The Avocado's defence, if card bonuses drop it below 0, return 1
    public int Defence
    {
        get
        {
            int defence = _level * 10 + CardDefenceBonus;

            if (defence > 0) return defence;

            return 1;
        }
    }

    // The Avocado's speed, if card bonuses drop it below 0, return 1
    public int Speed
    {
        get
        {
            int speed = _level * 10 + CardSpeedBonus;

            if (speed > 0) return speed;

            return 1;
        }
    }

    // The amount of additional attack received from equipped cards
    private int CardAttackBonus
    {
        get
        {
            int bonus = 0;

            if (_rightHandWeapon != null) bonus += _rightHandWeapon.AttackEffect;
            if (_leftHandWeapon != null) bonus += _leftHandWeapon.AttackEffect;
            if (_twoHandedWeapon != null) bonus += _twoHandedWeapon.AttackEffect;
            if (_headArmor != null) bonus += _headArmor.AttackEffect;
            if (_chestArmor != null) bonus += _chestArmor.AttackEffect;

            return bonus;
        }
    }

    // The amount of additional defence received from equipped cards
    private int CardDefenceBonus
    {
        get
        {
            int bonus = 0;

            if (_rightHandWeapon != null) bonus += _rightHandWeapon.DefenceEffect;
            if (_leftHandWeapon != null) bonus += _leftHandWeapon.DefenceEffect;
            if (_twoHandedWeapon != null) bonus += _twoHandedWeapon.DefenceEffect;
            if (_headArmor != null) bonus += _headArmor.DefenceEffect;
            if (_chestArmor != null) bonus += _chestArmor.DefenceEffect;

            return bonus;
        }
    }

    // The amount of additional health received from equipped cards
    private int CardHealthBonus
    {
        get
        {
            int bonus = 0;

            if (_rightHandWeapon != null) bonus += _rightHandWeapon.HealthEffect;
            if (_leftHandWeapon != null) bonus += _leftHandWeapon.HealthEffect;
            if (_twoHandedWeapon != null) bonus += _twoHandedWeapon.HealthEffect;
            if (_headArmor != null) bonus += _headArmor.HealthEffect;
            if (_chestArmor != null) bonus += _chestArmor.HealthEffect;

            return bonus;
        }
    }

    // The amount of additional speed received from equipped cards
    private int CardSpeedBonus
    {
        get
        {
            int bonus = 0;

            if (_rightHandWeapon != null) bonus += _rightHandWeapon.SpeedEffect;
            if (_leftHandWeapon != null) bonus += _leftHandWeapon.SpeedEffect;
            if (_twoHandedWeapon != null) bonus += _twoHandedWeapon.SpeedEffect;
            if (_headArmor != null) bonus += _headArmor.SpeedEffect;
            if (_chestArmor != null) bonus += _chestArmor.SpeedEffect;

            return bonus;
        }
    }

    // Try to equip a right handed weapon, if one is already equipped or a two handed weapon is already equipped, equip the new card and return the old one
    public Card EquipRightHandWeapon(Card weapon)
    {
        Card cardToReturn = null;

        // If the card is not a one handed weapon, do not equip it
        if (weapon.CardType != CardType.OneHandedWeapon) return null;

        if (_twoHandedWeapon != null) cardToReturn = UnequipTwoHandedWeapon();
        if (_rightHandWeapon != null) cardToReturn = UnequipRightHandWeapon();

        _rightHandWeapon = weapon;

        return cardToReturn;
    }

    // Try to equip a left handed weapon, if one is already equipped or a two handed weapon is already equipped, equip the new card and return the old one
    public Card EquipLeftHandWeapon(Card weapon)
    {
        Card cardToReturn = null;

        // If the card is not a one handed weapon, do not equip it
        if (weapon.CardType != CardType.OneHandedWeapon) return null;

        if (_twoHandedWeapon != null) cardToReturn = UnequipTwoHandedWeapon();
        if (_leftHandWeapon != null) cardToReturn = UnequipLeftHandWeapon();

        _leftHandWeapon = weapon;

        return cardToReturn;
    }

    // Try to equip a two handed weapon, if one is already equipped or one handed weapons are already equipped, equip the new card and return the old ones
    public List<Card> EquipTwoHandWeapon(Card weapon)
    {
        List<Card> cardsToReturn = new List<Card>();

        // If the card is not a one handed weapon, do not equip it
        if (weapon.CardType != CardType.TwoHandedWeapon) return null;

        if (_twoHandedWeapon != null) cardsToReturn.Add(UnequipTwoHandedWeapon());
        if (_leftHandWeapon != null) cardsToReturn.Add(UnequipLeftHandWeapon());
        if (_rightHandWeapon != null) cardsToReturn.Add(UnequipRightHandWeapon());

        _twoHandedWeapon = weapon;

        return cardsToReturn;
    }

    // Try to equip head armor, if one is already equipped, remove it, equip the new card and return the old one
    public Card EquipHeadArmor(Card armor)
    {
        Card cardToReturn = null;

        // If the card is not head armor, do not equip it
        if (armor.CardType != CardType.HeadArmor) return null;

        if (_headArmor != null) cardToReturn = UnequipHeadArmor();

        _headArmor = armor;

        return cardToReturn;
    }

    // Try to equip chest armor, if one is already equipped, remove it, equip the new card and return the old one
    public Card EquipChestArmor(Card armor)
    {
        Card cardToReturn = null;

        // If the card is not chest armor, do not equip it
        if (armor.CardType != CardType.ChestArmor) return null;

        if (_chestArmor != null) cardToReturn = UnequipChestArmor();

        _chestArmor = armor;

        return cardToReturn;
    }

    // If there are already 5 support cards equipped, do not equip the new card and return false, otherwise equip the card and return true;
    public bool TryEquipSupportCard(Card card)
    {
        if (SupportCards.Count == 5) return false;

        SupportCards.Add(card);

        return true;
    }

    public Card UnequipRightHandWeapon()
    {
        Card cardToReturn = _rightHandWeapon;
        _rightHandWeapon = null;
        return cardToReturn;
    }

    public Card UnequipLeftHandWeapon()
    {
        Card cardToReturn = _leftHandWeapon;
        _leftHandWeapon = null;
        return cardToReturn;
    }

    public Card UnequipTwoHandedWeapon()
    {
        Card cardToReturn = _twoHandedWeapon;
        _twoHandedWeapon = null;
        return cardToReturn;
    }

    public Card UnequipHeadArmor()
    {
        Card cardToReturn = _headArmor;
        _headArmor = null;
        return cardToReturn;
    }

    public Card UnequipChestArmor()
    {
        Card cardToReturn = _chestArmor;
        _chestArmor = null;
        return cardToReturn;
    }

    public Card UnequipSupportCard(int index)
    {
        // No support card at index
        if (!(SupportCards.Count > index)) return null;

        Card cardToReturn = SupportCards.ToArray()[index];
        SupportCards.RemoveAt(index);

        return cardToReturn;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
