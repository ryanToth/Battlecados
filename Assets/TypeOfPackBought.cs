using UnityEngine;
using System.Collections;

public class TypeOfPackBought : MonoBehaviour {

    public int packType;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
