using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MusicDropHandler : MonoBehaviour
{
    public Button loadMusicButton;  // Musicファイルをロードするボタン
    public AudioSource audioSource;  // 音楽を再生するAudioSource
    public Text musicFileNameText;  // 読み込まれた音楽ファイル名を表示するテキスト

    void Start()
    {
        if (loadMusicButton != null)
        {
            loadMusicButton.onClick.AddListener(LoadMusicFile);  // ボタンにイベントを追加
        }
    }

    // 音楽ファイルを読み込んで再生するメソッド
    public void LoadMusicFile()
    {
        string filePath = ShowFilePicker();  // ファイルピッカーでファイル選択
        if (!string.IsNullOrEmpty(filePath))
        {
            PlayMusic(filePath);  // 音楽再生
        }
    }

    // 音楽を再生するメソッド
    void PlayMusic(string filePath)
    {
        if (audioSource != null && File.Exists(filePath))
        {
            StartCoroutine(LoadAndPlayMusic(filePath));  // コルーチンで音楽を非同期で読み込んで再生
        }
        else
        {
            Debug.LogWarning("AudioSource is not set or file does not exist.");
        }
    }

    // 非同期で音楽を読み込んで再生するコルーチン
    IEnumerator LoadAndPlayMusic(string filePath)
    {
        UnityWebRequest audioRequest = UnityWebRequestMultimedia.GetAudioClip($"file://{filePath}", AudioType.WAV);  // 音楽ファイル形式を指定
        yield return audioRequest.SendWebRequest();  // 非同期でファイルを読み込む

        if (audioRequest.result == UnityWebRequest.Result.Success)
        {
            AudioClip clip = DownloadHandlerAudioClip.GetContent(audioRequest);  // 音声データを取得
            audioSource.clip = clip;  // AudioSourceにセット
            audioSource.Play();  // 音楽を再生
            if (musicFileNameText != null)
            {
                musicFileNameText.text = $"Now Playing: {Path.GetFileName(filePath)}";  // ファイル名をUIに表示
            }
        }
        else
        {
            Debug.LogError($"Failed to load music: {audioRequest.error}");
        }
    }

    // ファイルダイアログを表示して音楽ファイルを選択するメソッド
    string ShowFilePicker()
    {
        // ここでファイル選択ダイアログを実装します。
        // 実際にはプラットフォームに応じた方法でファイルを選択できるようにします。
        // Unityの標準機能にはファイル選択ダイアログはないため、プラグイン等を使用する必要があります。

        // ここでは仮にファイルパスを指定する方法を記載します。
        // 実際のゲームでは、ファイルピッカーを使用して選択されたパスを取得します。
        string filePath = "C:/Users/YourUserName/Music/song.wav";  // 適当なパスに置き換えてください
        return filePath;
    }
}
