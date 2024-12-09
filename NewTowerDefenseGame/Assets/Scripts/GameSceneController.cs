using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    [SerializeField] private GameObject Slime_Button; // ゲームシーンのボタン

    // ゲームシーン開始時に呼ばれる
    void Start()
    {
        int slimeUnlocked = PlayerPrefs.GetInt("SlimeUnlocked", 0); // フラグを取得
        Debug.Log($"[GameSceneController] SlimeUnlocked flag: {slimeUnlocked}"); // デバッグログで確認


        // PlayerPrefs に保存されているフラグを確認
        if (PlayerPrefs.GetInt("SlimeUnlocked", 0) == 1)
        {
            Slime_Button.SetActive(true); // フラグが 1 ならボタンをアクティブ化
            Debug.Log("[GameSceneController] Slime_Button is now active.");
        }
        else
        {
            Debug.Log("[GameSceneController] Slime_Button is not active.");
        }
    }
}
