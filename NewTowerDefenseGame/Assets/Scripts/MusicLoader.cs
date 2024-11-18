using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using SFB;  // StandaloneFileBrowser�̖��O���

public class MusicLoader : MonoBehaviour
{
    public AudioSource audioSource;  // ���y���Đ�����AudioSource
    public Button loadMusicButton;  // ���y��ǂݍ��ރ{�^��
    public Text statusText;  // �X�e�[�^�X�e�L�X�g�i���[�h���̒ʒm�Ȃǁj

    private bool isLoading = false;  // ���[�h�����ǂ����������t���O

    void Start()
    {
        // �{�^���ɃN���b�N�C�x���g��o�^
        loadMusicButton.onClick.AddListener(OpenFileExplorer);
    }

    // �t�@�C���I���_�C�A���O���J��
    public void OpenFileExplorer()
    {
        if (isLoading)
        {
            Debug.Log("Already loading music.");
            return;
        }

        var paths = StandaloneFileBrowser.OpenFilePanel("Select Music File", "", "mp3", true);  // �g���q��mp3�ɐݒ�A�����t�@�C���I����L���ɂ���

        if (paths.Length > 0)
        {
            // �t�@�C�����I�΂ꂽ��Đ�
            StartCoroutine(PlayMusic(paths));
        }
        else
        {
            Debug.Log("No file selected");
        }
    }

    // �����t�@�C���̉��y���Đ�����
    IEnumerator PlayMusic(string[] filePaths)
    {
        if (filePaths.Length == 0) yield break;

        isLoading = true;
        statusText.text = "Loading music...";  // �X�e�[�^�X�X�V

        foreach (var filePath in filePaths)
        {
            if (File.Exists(filePath))
            {
                Debug.Log("Loading: " + filePath);
                yield return StartCoroutine(LoadAudio(filePath));
            }
            else
            {
                Debug.LogError("File not found: " + filePath);
            }
        }

        isLoading = false;
        statusText.text = "Music loaded";  // �X�e�[�^�X�X�V
    }

    // ���y���Đ�����
    IEnumerator LoadAudio(string filePath)
    {
        string url = "file://" + filePath;
        UnityWebRequest audioRequest = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG);  // AudioType.MPEG���g�p

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
            statusText.text = "Error loading music: " + audioRequest.error;  // �G���[�X�e�[�^�X�X�V
        }
    }
}
