using UnityEngine;

public class ClickCounter : MonoBehaviour
{
    [SerializeField] private GameObject targetObject; // クリック対象のオブジェクト
    [SerializeField] private int clickThreshold = 10; // 必要なクリック数
    [SerializeField] private string gameSceneName = "GameScene"; // ゲームシーン名
    [SerializeField] private string targetObjectName = "TargetObjectInGameScene"; // ゲームシーン内の対象オブジェクト名

    private int clickCount = 0;

    void Start()
    {
        if (targetObject == null)
        {
            Debug.LogError("Target Object is not assigned!");
        }
    }

    public void OnObjectClicked()
    {
        clickCount++;
        Debug.Log($"Clicked {clickCount}/{clickThreshold} times");

        if (clickCount >= clickThreshold)
        {
            ActivateObjectInGameScene();
        }
    }

    private void ActivateObjectInGameScene()
    {
        // ゲームシーンをロードしてオブジェクトをアクティブ化
        var scene = UnityEngine.SceneManagement.SceneManager.GetSceneByName(gameSceneName);
        if (scene.isLoaded)
        {
            GameObject[] rootObjects = scene.GetRootGameObjects();
            foreach (GameObject obj in rootObjects)
            {
                if (obj.name == targetObjectName)
                {
                    obj.SetActive(true);
                    Debug.Log($"Activated object: {targetObjectName}");
                    return;
                }
            }
        }
        else
        {
            Debug.LogError("Game scene is not loaded!");
        }
    }
}
