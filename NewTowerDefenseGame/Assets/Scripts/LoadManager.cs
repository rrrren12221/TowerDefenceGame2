using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    //ゲームシーンへ移動
    public void LoadGameScene(string GameScene)
    {
        SceneManager.LoadScene(GameScene);
    }

    //ゲームを終了
    public void EndGame()
    {
        Application.Quit();
    }

}
