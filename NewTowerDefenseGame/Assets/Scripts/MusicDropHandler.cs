using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MusicDropHandler : MonoBehaviour
{
    public Button loadMusicButton;  // Music�t�@�C�������[�h����{�^��
    public AudioSource audioSource;  // ���y���Đ�����AudioSource
    public Text musicFileNameText;  // �ǂݍ��܂ꂽ���y�t�@�C������\������e�L�X�g

    void Start()
    {
        if (loadMusicButton != null)
        {
            loadMusicButton.onClick.AddListener(LoadMusicFile);  // �{�^���ɃC�x���g��ǉ�
        }
    }

    // ���y�t�@�C����ǂݍ���ōĐ����郁�\�b�h
    public void LoadMusicFile()
    {
        string filePath = ShowFilePicker();  // �t�@�C���s�b�J�[�Ńt�@�C���I��
        if (!string.IsNullOrEmpty(filePath))
        {
            PlayMusic(filePath);  // ���y�Đ�
        }
    }

    // ���y���Đ����郁�\�b�h
    void PlayMusic(string filePath)
    {
        if (audioSource != null && File.Exists(filePath))
        {
            StartCoroutine(LoadAndPlayMusic(filePath));  // �R���[�`���ŉ��y��񓯊��œǂݍ���ōĐ�
        }
        else
        {
            Debug.LogWarning("AudioSource is not set or file does not exist.");
        }
    }

    // �񓯊��ŉ��y��ǂݍ���ōĐ�����R���[�`��
    IEnumerator LoadAndPlayMusic(string filePath)
    {
        UnityWebRequest audioRequest = UnityWebRequestMultimedia.GetAudioClip($"file://{filePath}", AudioType.WAV);  // ���y�t�@�C���`�����w��
        yield return audioRequest.SendWebRequest();  // �񓯊��Ńt�@�C����ǂݍ���

        if (audioRequest.result == UnityWebRequest.Result.Success)
        {
            AudioClip clip = DownloadHandlerAudioClip.GetContent(audioRequest);  // �����f�[�^���擾
            audioSource.clip = clip;  // AudioSource�ɃZ�b�g
            audioSource.Play();  // ���y���Đ�
            if (musicFileNameText != null)
            {
                musicFileNameText.text = $"Now Playing: {Path.GetFileName(filePath)}";  // �t�@�C������UI�ɕ\��
            }
        }
        else
        {
            Debug.LogError($"Failed to load music: {audioRequest.error}");
        }
    }

    // �t�@�C���_�C�A���O��\�����ĉ��y�t�@�C����I�����郁�\�b�h
    string ShowFilePicker()
    {
        // �����Ńt�@�C���I���_�C�A���O���������܂��B
        // ���ۂɂ̓v���b�g�t�H�[���ɉ��������@�Ńt�@�C����I���ł���悤�ɂ��܂��B
        // Unity�̕W���@�\�ɂ̓t�@�C���I���_�C�A���O�͂Ȃ����߁A�v���O�C�������g�p����K�v������܂��B

        // �����ł͉��Ƀt�@�C���p�X���w�肷����@���L�ڂ��܂��B
        // ���ۂ̃Q�[���ł́A�t�@�C���s�b�J�[���g�p���đI�����ꂽ�p�X���擾���܂��B
        string filePath = "C:/Users/YourUserName/Music/song.wav";  // �K���ȃp�X�ɒu�������Ă�������
        return filePath;
    }
}
