using UnityEngine;
using UnityEngine.SceneManagement; // シーン遷移用

public class ClickCounter : MonoBehaviour
{
    [SerializeField] private int clickThreshold = 10; // クリック数の閾値
    private int clickCount = 0; // 現在のクリック数

    // オブジェクトがクリックされた時に呼び出される
    public void OnMouseDown()
    {
        clickCount++;
        Debug.Log($"[ClickCounter] Click count: {clickCount}/{clickThreshold}");

        if (clickCount >= clickThreshold)
        {
            // クリック数が閾値に達したらフラグを保存
            PlayerPrefs.SetInt("SlimeUnlocked", 1);
            PlayerPrefs.Save();
            Debug.Log("[ClickCounter] SlimeUnlocked flag set to 1");
        }
    }
}
