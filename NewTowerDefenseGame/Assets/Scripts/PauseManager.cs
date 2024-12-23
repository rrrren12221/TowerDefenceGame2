using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuCanvas; // PauseMenuPanelを設定
    private bool isPaused;

    void Start()
    {
        // 初期状態を設定
        isPaused = pauseMenuCanvas.activeSelf;
        UpdateTimeScale();
    }

    void Update()
    {
        // pauseMenuCanvasのアクティブ状態が変化した場合にのみポーズを切り替え
        if (pauseMenuCanvas.activeSelf != isPaused)
        {
            isPaused = pauseMenuCanvas.activeSelf;
            UpdateTimeScale();
        }
    }

    void UpdateTimeScale()
    {
        if (isPaused)
        {
            Time.timeScale = 0f; // ゲームを一時停止
            PauseUIAnimations();
        }
        else
        {
            Time.timeScale = 1f; // ゲームを再開
            ResumeUIAnimations();
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
