using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStats : MonoBehaviour
{
    public static GlobalStats Instance;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public float PlayerSavings;
    public float FishKG;

    public float PhpPerKG;

    [Range(1, 3)]
    public int BoatSpdLvl;

    [Range(1, 3)]
    public int NetLevel;
}
