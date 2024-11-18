using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using SFB;  // StandaloneFileBrowserの名前空間

public class MusicLoader : MonoBehaviour
{
    public AudioSource audioSource;  // 音楽を再生するAudioSource
    public Button loadMusicButton;  // 音楽を読み込むボタン
    public Text statusText;  // ステータステキスト（ロード中の通知など）

    private bool isLoading = false;  // ロード中かどうかを示すフラグ

    void Start()
    {
        // ボタンにクリックイベントを登録
        loadMusicButton.onClick.AddListener(OpenFileExplorer);
    }

    // ファイル選択ダイアログを開く
    public void OpenFileExplorer()
    {
        if (isLoading)
        {
            Debug.Log("Already loading music.");
            return;
        }

        var paths = StandaloneFileBrowser.OpenFilePanel("Select Music File", "", "mp3", true);  // 拡張子をmp3に設定、複数ファイル選択を有効にする

        if (paths.Length > 0)
        {
            // ファイルが選ばれたら再生
            StartCoroutine(PlayMusic(paths));
        }
        else
        {
            Debug.Log("No file selected");
        }
    }

    // 複数ファイルの音楽を再生する
    IEnumerator PlayMusic(string[] filePaths)
    {
        if (filePaths.Length == 0) yield break;

        isLoading = true;
        statusText.text = "Loading music...";  // ステータス更新

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
        statusText.text = "Music loaded";  // ステータス更新
    }

    // 音楽を再生する
    IEnumerator LoadAudio(string filePath)
    {
        string url = "file://" + filePath;
        UnityWebRequest audioRequest = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG);  // AudioType.MPEGを使用

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
            statusText.text = "Error loading music: " + audioRequest.error;  // エラーステータス更新
        }
    }
}
