using UnityEngine;
using System.Collections;

public class CardEffect {

    private int _attack;

    public int Attack
    {
        get
        {
            return _attack;
        }
    }

    private int _defence;

    public int Defence
    {
        get
        {
            return _defence;
        }
    }

    private int _health;

    public int Health
    {
        get
        {
            return _health;
        }
    }

    private int _speed;

    public int Speed
    {
        get
        {
            return _speed;
        }
    }

    // CardEffect constructor
    public CardEffect(int attack, int defence, int health, int speed)
    {
        _attack = attack;
        _defence = defence;
        _health = health;
        _speed = speed;
    }
}
