using UnityEngine;
using System.Collections;

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

    // Default constructor for an Avocado
    public Avocado()
    {
        _level = 1;
        _experiencePoints = 0;
    }

    // Avocado constructor for existing avocados
    public Avocado(int level, int experiencePoints)
    {
        _level = level;
        _experiencePoints = experiencePoints;
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

    // The Avocados health
    public int Health
    {
        get
        {
            return _level * 10;
        }
    }

    // The Avocados attack
    public int Attack
    {
        get
        {
            return _level * 10;
        }
    }

    // The Avocados defense
    public int Defense
    {
        get
        {
            return _level * 10;
        }
    }

    // The Avocados speed
    public int Speed
    {
        get
        {
            return _level * 10;
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
