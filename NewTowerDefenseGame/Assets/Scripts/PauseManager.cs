using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        // Escape�L�[�������ꂽ��|�[�Y��؂�ւ�
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1f; // ���Ԃ�ʏ�ɖ߂�
            isPaused = false;

            // �K�v�ɉ�����UI��A�j���[�V�����̍ĊJ������ǉ�
            ResumeUIAnimations();
        }
        else
        {
            Time.timeScale = 0f; // ���Ԃ��~����
            isPaused = true;

            // �K�v�ɉ�����UI��A�j���[�V�����̒�~������ǉ�
            PauseUIAnimations();
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
