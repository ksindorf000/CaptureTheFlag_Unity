using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalControl : MonoBehaviour
{
    public static int lives = 5;
    public static int level;

    public static GlobalControl Instance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

}
