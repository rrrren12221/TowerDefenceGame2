using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        // Escapeキーが押されたらポーズを切り替え
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1f; // 時間を通常に戻す
            isPaused = false;

            // 必要に応じてUIやアニメーションの再開処理を追加
            ResumeUIAnimations();
        }
        else
        {
            Time.timeScale = 0f; // 時間を停止する
            isPaused = true;

            // 必要に応じてUIやアニメーションの停止処理を追加
            PauseUIAnimations();
        }
    }

    void PauseUIAnimations()
    {
        // UIの停止処理（例: Animatorの速度を0にする）
        foreach (Animator animator in FindObjectsOfType<Animator>())
        {
            animator.speed = 0;
        }
    }

    void ResumeUIAnimations()
    {
        // UIの再開処理（例: Animatorの速度を元に戻す）
        foreach (Animator animator in FindObjectsOfType<Animator>())
        {
            animator.speed = 1;
        }
    }
}
