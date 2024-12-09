using UnityEngine;

public class ClickCounter : MonoBehaviour
{
    [SerializeField] private GameObject targetObject; // �N���b�N�Ώۂ̃I�u�W�F�N�g
    [SerializeField] private int clickThreshold = 10; // �K�v�ȃN���b�N��
    [SerializeField] private string gameSceneName = "GameScene"; // �Q�[���V�[����
    [SerializeField] private string targetObjectName = "TargetObjectInGameScene"; // �Q�[���V�[�����̑ΏۃI�u�W�F�N�g��

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
        // �Q�[���V�[�������[�h���ăI�u�W�F�N�g���A�N�e�B�u��
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
