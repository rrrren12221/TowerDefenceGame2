using UnityEngine;
using UnityEngine.UI;

public class MusicMenuController : MonoBehaviour
{
    public Button BuckTitleButton;  // メインメニューに戻るボタン
    public Button RestartButton;    // リスタートボタン
    public Button MusicButton;      // 音楽メニューを開くボタン
    public Button LoadMusicButton;  // 音楽をロードするボタン
    public Button StopAudioButton;  // 音楽を停止するボタン
    public Button PauseAudioButton; // 音楽を一時停止するボタン
    public Button ResumeAudioButton;// 音楽を再開するボタン
    public Button SelectMenuButton; // メインメニューに戻るボタン

    private bool isMusicMenuActive = false; // 音楽メニューがアクティブかどうか

    void Start()
    {
        // 初期状態の設定
        SetActiveMusicMenu(false);

        // 各ボタンにクリックイベントを登録
        MusicButton.onClick.AddListener(OnMusicButtonClicked);
        SelectMenuButton.onClick.AddListener(OnSelectMenuButtonClicked);
    }

    void Update()
    {
        // エスケープキーが押されたときの動作
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 音楽メニューを非アクティブにして、メインメニューをアクティブにする
            SetActiveMusicMenu(false);
            SetActiveMainMenu(true);
        }
    }

    // MusicButtonが押されたときの処理
    void OnMusicButtonClicked()
    {
        SetActiveMainMenu(false);
        SetActiveMusicMenu(true);
    }

    // SelectMenuButtonが押されたときの処理
    void OnSelectMenuButtonClicked()
    {
        SetActiveMusicMenu(false);
        SetActiveMainMenu(true);
    }

    // メインメニューのボタンを有効/無効にする
    void SetActiveMainMenu(bool isActive)
    {
        BuckTitleButton.gameObject.SetActive(isActive);
        RestartButton.gameObject.SetActive(isActive);
        MusicButton.gameObject.SetActive(isActive);

        if (isActive) isMusicMenuActive = false;
    }

    // 音楽メニューのボタンを有効/無効にする
    void SetActiveMusicMenu(bool isActive)
    {
        LoadMusicButton.gameObject.SetActive(isActive);
        StopAudioButton.gameObject.SetActive(isActive);
        PauseAudioButton.gameObject.SetActive(isActive);
        ResumeAudioButton.gameObject.SetActive(isActive);
        SelectMenuButton.gameObject.SetActive(isActive);

        isMusicMenuActive = isActive;
    }
}
