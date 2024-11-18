using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // 表示・非表示を切り替える対象
    [SerializeField] private GameObject PauseMenuObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseMenuObject != null)
            {
                // PauseMenuObjectがアクティブ状態かを確認して切り替え
                if (PauseMenuObject.activeSelf)
                {
                    PauseMenuObject.SetActive(false); // 非アクティブに設定
                    Debug.Log("PauseMenuObject has been deactivated.");
                }
                else
                {
                    PauseMenuObject.SetActive(true); // アクティブに設定
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
