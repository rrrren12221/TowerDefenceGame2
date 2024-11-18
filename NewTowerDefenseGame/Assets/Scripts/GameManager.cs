using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ƒQ[ƒ€‘S‘Ì‚ğŠÇ—‚·‚é
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public bool isGame = false;

    void Start()
    {
        isGame = true;
    }

}