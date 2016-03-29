using UnityEngine;

public class GetCurrentInfo : MonoBehaviour {

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
            var gameObject = GameObject.FindGameObjectWithTag("TypeOfPack");

            return gameObject.GetComponent<TypeOfPackBought>();
        }
    }
}
