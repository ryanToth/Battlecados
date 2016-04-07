using UnityEngine;

// Class for saving data that needs to be Persitant
public class GetCurrentInfo {

    public static User User
    {
        get
        {
            var gameObject = GameObject.FindGameObjectWithTag("User");

            return gameObject.GetComponent<User>();
        }
    }

    public static TypeOfPackBought TypeOfPackToOpen
    {
        get
        {
            var gameObject = GameObject.FindGameObjectWithTag("User");

            return gameObject.GetComponent<TypeOfPackBought>();
        }
    }

    public static EnemyEyes EnemyEyes
    {
        get
        {
            var gameObject = GameObject.FindGameObjectWithTag("User");

            return gameObject.GetComponent<EnemyEyes>();
        }
    }

    public static AudioSources AudioSources
    {
        get
        {
            var gameObject = GameObject.FindGameObjectWithTag("User");

            return gameObject.GetComponent<AudioSources>();
        }
    }


    public static AudioSource AudioSource
    {
        get
        {
            var gameObject = GameObject.FindGameObjectWithTag("User");

            return gameObject.GetComponent<AudioSource>();
        }
    }
}
