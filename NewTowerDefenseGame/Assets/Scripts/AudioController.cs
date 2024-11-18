using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; // �Đ����̃I�[�f�B�I�\�[�X
    [SerializeField] private Button stopButton;       // Stop�{�^��
    [SerializeField] private Button pauseButton;      // Pause�{�^��
    [SerializeField] private Button resumeButton;     // Resume�{�^��

    private void Start()
    {
        // �{�^���Ƀ��X�i�[��o�^
        if (audioSource != null)
        {
            if (stopButton != null)
                stopButton.onClick.AddListener(StopAudioSource);

            if (pauseButton != null)
                pauseButton.onClick.AddListener(PauseAudioSource);

            if (resumeButton != null)
                resumeButton.onClick.AddListener(ResumeAudioSource);
        }
        else
        {
            Debug.LogError("AudioSource ���ݒ肳��Ă��܂���B");
        }
    }

    private void StopAudioSource()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
            Debug.Log("Audio stopped.");
        }
    }

    private void PauseAudioSource()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
            Debug.Log("Audio paused.");
        }
    }

    private void ResumeAudioSource()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.UnPause();
            Debug.Log("Audio resumed.");
        }
    }
}
