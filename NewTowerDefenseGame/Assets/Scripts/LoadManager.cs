using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    //�Q�[���V�[���ֈړ�
    public void LoadGameScene(string GameScene)
    {
        SceneManager.LoadScene(GameScene);
    }

    //�Q�[�����I��
    public void EndGame()
    {
        Application.Quit();
    }

}
