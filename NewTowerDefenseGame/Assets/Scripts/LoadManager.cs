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

    //タイトルシーンへ移動
    public void LoadTitleScene(string TitleScene)
    {
        SceneManager.LoadScene(TitleScene);
    }

    public void LoadSceneRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Loadnishi(string NishiScene)
    {
        SceneManager.LoadScene(NishiScene);
    }

    //ゲームを終了
    public void EndGame()
    {
        Application.Quit();
    }

}
