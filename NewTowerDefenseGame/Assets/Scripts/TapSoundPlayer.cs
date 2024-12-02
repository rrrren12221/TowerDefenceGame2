using UnityEngine;

public class TapSoundPlayer : MonoBehaviour
{
    // �T�E���h���Đ����邽�߂�AudioSource
    private AudioSource audioSource;

    // �Đ�����T�E���h�G�t�F�N�g
    public AudioClip tapSound;

    void Start()
    {
        // AudioSource�R���|�[�l���g��ǉ��܂��͎擾
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        // �T�E���h���Đ�
        if (tapSound != null)
        {
            audioSource.PlayOneShot(tapSound);
        }
    }
}
