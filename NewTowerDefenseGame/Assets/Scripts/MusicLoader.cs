using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using SFB;  // StandaloneFileBrowser�̖��O���

public class MusicLoader : MonoBehaviour
{
    public AudioSource audioSource; // ���y���Đ�����AudioSource
    public Button loadMusicButton;  // ���y��ǂݍ��ރ{�^��

    void Start()
    {
        // �{�^���ɃN���b�N�C�x���g��o�^
        loadMusicButton.onClick.AddListener(OpenFileExplorer);
    }

    // �t�@�C���I���_�C�A���O���J��
    public void OpenFileExplorer()
    {
        var paths = StandaloneFileBrowser.OpenFilePanel("Select Music File", "", "", false);

        if (paths.Length > 0)
        {
            string filePath = paths[0]; // �I�����ꂽ�t�@�C���̃p�X���擾
            PlayMusic(filePath); // ���y���Đ�
        }
        else
        {
            Debug.Log("No file selected");
        }
    }

    // ���y���Đ�����
    void PlayMusic(string filePath)
    {
        if (File.Exists(filePath))
        {
            StartCoroutine(LoadAudio(filePath));
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
    }

    // AudioClip��񓯊��œǂݍ���
    IEnumerator LoadAudio(string filePath)
    {
        string url = "file://" + filePath;
        UnityWebRequest audioRequest = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG);  // AudioType.MPEG�ɕύX
        yield return audioRequest.SendWebRequest();

        if (audioRequest.result == UnityWebRequest.Result.Success)
        {
            AudioClip clip = DownloadHandlerAudioClip.GetContent(audioRequest);
            audioSource.clip = clip;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Error loading audio file: " + audioRequest.error);
        }
    }



}
