using UnityEngine;
using System.Collections;

public class EnemyEyes : MonoBehaviour {

    public int eyes;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
