using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;
    public bool IsFlipped = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public bool GetFlipped()
    {
        return IsFlipped;
    }

    public void SetFlipped(bool _bool)
    {
        IsFlipped = _bool;
    }


}
