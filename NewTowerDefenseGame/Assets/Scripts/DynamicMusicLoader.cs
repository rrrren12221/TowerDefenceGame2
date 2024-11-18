using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DynamicMusicLoader : MonoBehaviour
{
    public AudioSource audioSource;       // ���y���Đ�����AudioSource
    public string musicFolderPath;       // ���y�t�@�C���̕ۑ��t�H���_
    public Dropdown musicDropdown;       // �Ȃ�I�����邽�߂�Dropdown

    private string[] musicFiles;         // ���y�t�@�C���̃p�X���X�g

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (string.IsNullOrEmpty(musicFolderPath))
        {
            // �f�t�H���g�ŁuMusic�v�Ƃ����t�H���_���w��
            musicFolderPath = Path.Combine(Application.persistentDataPath, "Music");
        }

        // ���y�t�H���_�����݂��Ȃ���΍쐬
        if (!Directory.Exists(musicFolderPath))
        {
            Directory.CreateDirectory(musicFolderPath);
        }

        // ���y�t�@�C�����X�g���擾
        LoadMusicFiles();
    }

    // ���y�t�@�C����ǂݍ����Dropdown�ɕ\��
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

    // �I�����ꂽ���y���Đ�
    public void PlaySelectedMusic(int selectedIndex)
    {
        if (selectedIndex < 0 || selectedIndex >= musicFiles.Length)
        {
            Debug.LogWarning("Invalid music selection.");
            return;
        }

        StartCoroutine(LoadAndPlayAudio(musicFiles[selectedIndex]));
    }

    // ���y�t�@�C�������[�h���čĐ�
    private System.Collections.IEnumerator LoadAndPlayAudio(string filePath)
    {
        // ���[�J���t�@�C����Unity�Ŏg�p�ł���`���ɕϊ�
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
