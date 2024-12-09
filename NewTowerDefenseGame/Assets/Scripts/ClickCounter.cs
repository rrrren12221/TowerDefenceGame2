using UnityEngine;
using UnityEngine.SceneManagement; // �V�[���J�ڗp

public class ClickCounter : MonoBehaviour
{
    [SerializeField] private int clickThreshold = 10; // �N���b�N����臒l
    private int clickCount = 0; // ���݂̃N���b�N��

    // �I�u�W�F�N�g���N���b�N���ꂽ���ɌĂяo�����
    public void OnMouseDown()
    {
        clickCount++;
        Debug.Log($"[ClickCounter] Click count: {clickCount}/{clickThreshold}");

        if (clickCount >= clickThreshold)
        {
            // �N���b�N����臒l�ɒB������t���O��ۑ�
            PlayerPrefs.SetInt("SlimeUnlocked", 1);
            PlayerPrefs.Save();
            Debug.Log("[ClickCounter] SlimeUnlocked flag set to 1");
        }
    }
}
