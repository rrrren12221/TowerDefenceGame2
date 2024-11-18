using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using SFB;  // StandaloneFileBrowserの名前空間

public class MusicLoader : MonoBehaviour
{
    public AudioSource audioSource; // 音楽を再生するAudioSource
    public Button loadMusicButton;  // 音楽を読み込むボタン

    void Start()
    {
        // ボタンにクリックイベントを登録
        loadMusicButton.onClick.AddListener(OpenFileExplorer);
    }

    // ファイル選択ダイアログを開く
    public void OpenFileExplorer()
    {
        var paths = StandaloneFileBrowser.OpenFilePanel("Select Music File", "", "", false);

        if (paths.Length > 0)
        {
            string filePath = paths[0]; // 選択されたファイルのパスを取得
            PlayMusic(filePath); // 音楽を再生
        }
        else
        {
            Debug.Log("No file selected");
        }
    }

    // 音楽を再生する
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

    // AudioClipを非同期で読み込む
    IEnumerator LoadAudio(string filePath)
    {
        string url = "file://" + filePath;
        UnityWebRequest audioRequest = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG);  // AudioType.MPEGに変更
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
