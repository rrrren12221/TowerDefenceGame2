using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �Q�[���S�̂��Ǘ�����
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