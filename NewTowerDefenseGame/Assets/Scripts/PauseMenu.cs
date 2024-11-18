using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // �\���E��\����؂�ւ���Ώ�
    [SerializeField] private GameObject PauseMenuObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseMenuObject != null)
            {
                // PauseMenuObject���A�N�e�B�u��Ԃ����m�F���Đ؂�ւ�
                if (PauseMenuObject.activeSelf)
                {
                    PauseMenuObject.SetActive(false); // ��A�N�e�B�u�ɐݒ�
                    Debug.Log("PauseMenuObject has been deactivated.");
                }
                else
                {
                    PauseMenuObject.SetActive(true); // �A�N�e�B�u�ɐݒ�
                    Debug.Log("PauseMenuObject has been activated.");
                }
            }
            else
            {
                Debug.LogError("PauseMenuObject is not assigned in the Inspector.");
            }
        }
    }
}
