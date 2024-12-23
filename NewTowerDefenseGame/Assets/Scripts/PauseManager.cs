using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuCanvas; // PauseMenuPanel��ݒ�
    private bool isPaused;

    void Start()
    {
        // ������Ԃ�ݒ�
        isPaused = pauseMenuCanvas.activeSelf;
        UpdateTimeScale();
    }

    void Update()
    {
        // pauseMenuCanvas�̃A�N�e�B�u��Ԃ��ω������ꍇ�ɂ̂݃|�[�Y��؂�ւ�
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
            Time.timeScale = 0f; // �Q�[�����ꎞ��~
            PauseUIAnimations();
        }
        else
        {
            Time.timeScale = 1f; // �Q�[�����ĊJ
            ResumeUIAnimations();
        }
    }

    void PauseUIAnimations()
    {
        // UI�̒�~�����i��: Animator�̑��x��0�ɂ���j
        foreach (Animator animator in FindObjectsOfType<Animator>())
        {
            animator.speed = 0;
        }
    }

    void ResumeUIAnimations()
    {
        // UI�̍ĊJ�����i��: Animator�̑��x�����ɖ߂��j
        foreach (Animator animator in FindObjectsOfType<Animator>())
        {
            animator.speed = 1;
        }
    }
}
