using UnityEngine;

public class TapSoundPlayer : MonoBehaviour
{
    // サウンドを再生するためのAudioSource
    private AudioSource audioSource;

    // 再生するサウンドエフェクト
    public AudioClip tapSound;

    void Start()
    {
        // AudioSourceコンポーネントを追加または取得
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        // サウンドを再生
        if (tapSound != null)
        {
            audioSource.PlayOneShot(tapSound);
        }
    }
}
