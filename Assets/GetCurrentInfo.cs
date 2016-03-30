using UnityEngine;

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
}
