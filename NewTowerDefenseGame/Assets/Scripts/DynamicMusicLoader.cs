using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DynamicMusicLoader : MonoBehaviour
{
    public AudioSource audioSource;       // 音楽を再生するAudioSource
    public string musicFolderPath;       // 音楽ファイルの保存フォルダ
    public Dropdown musicDropdown;       // 曲を選択するためのDropdown

    private string[] musicFiles;         // 音楽ファイルのパスリスト

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (string.IsNullOrEmpty(musicFolderPath))
        {
            // デフォルトで「Music」というフォルダを指定
            musicFolderPath = Path.Combine(Application.persistentDataPath, "Music");
        }

        // 音楽フォルダが存在しなければ作成
        if (!Directory.Exists(musicFolderPath))
        {
            Directory.CreateDirectory(musicFolderPath);
        }

        // 音楽ファイルリストを取得
        LoadMusicFiles();
    }

    // 音楽ファイルを読み込んでDropdownに表示
    public void LoadMusicFiles()
    {
        musicFiles = Directory.GetFiles(musicFolderPath, "*.mp3");

        if (musicDropdown != null)
        {
            musicDropdown.ClearOptions();
            foreach (var file in musicFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                musicDropdown.options.Add(new Dropdown.OptionData(fileName));
            }
            musicDropdown.RefreshShownValue();
        }
    }

    // 選択された音楽を再生
    public void PlaySelectedMusic(int selectedIndex)
    {
        if (selectedIndex < 0 || selectedIndex >= musicFiles.Length)
        {
            Debug.LogWarning("Invalid music selection.");
            return;
        }

        StartCoroutine(LoadAndPlayAudio(musicFiles[selectedIndex]));
    }

    // 音楽ファイルをロードして再生
    private System.Collections.IEnumerator LoadAndPlayAudio(string filePath)
    {
        // ローカルファイルをUnityで使用できる形式に変換
        using (var www = new WWW("file://" + filePath))
        {
            yield return www;

            AudioClip clip = www.GetAudioClip(false, true);
            if (clip != null)
            {
                audioSource.clip = clip;
                audioSource.Play();
            }
            else
            {
                Debug.LogError("Failed to load audio: " + filePath);
            }
        }
    }
}
