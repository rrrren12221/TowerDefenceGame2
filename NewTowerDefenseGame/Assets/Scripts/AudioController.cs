using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; // 再生中のオーディオソース
    [SerializeField] private Button stopButton;       // Stopボタン
    [SerializeField] private Button pauseButton;      // Pauseボタン
    [SerializeField] private Button resumeButton;     // Resumeボタン

    private void Start()
    {
        // ボタンにリスナーを登録
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
            Debug.LogError("AudioSource が設定されていません。");
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
