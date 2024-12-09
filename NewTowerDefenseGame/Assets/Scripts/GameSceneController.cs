using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    [SerializeField] private GameObject Slime_Button; // �Q�[���V�[���̃{�^��

    // �Q�[���V�[���J�n���ɌĂ΂��
    void Start()
    {
        int slimeUnlocked = PlayerPrefs.GetInt("SlimeUnlocked", 0); // �t���O���擾
        Debug.Log($"[GameSceneController] SlimeUnlocked flag: {slimeUnlocked}"); // �f�o�b�O���O�Ŋm�F


        // PlayerPrefs �ɕۑ�����Ă���t���O���m�F
        if (PlayerPrefs.GetInt("SlimeUnlocked", 0) == 1)
        {
            Slime_Button.SetActive(true); // �t���O�� 1 �Ȃ�{�^�����A�N�e�B�u��
            Debug.Log("[GameSceneController] Slime_Button is now active.");
        }
        else
        {
            Debug.Log("[GameSceneController] Slime_Button is not active.");
        }
    }
}
