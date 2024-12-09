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

    // リセットボタンなどで呼び出すメソッド
    public void ResetPreferences()
    {
        // PlayerPrefsの全てのデータを削除
        PlayerPrefs.DeleteAll();

        // リセットされたことをログで表示
        Debug.Log("PlayerPrefs has been reset.");

        // リセット後に必要な処理を追加できます。
        // 例えば、ゲームの再起動や初期化処理など
    }


    //ゲームを終了
    public void EndGame()
    {
        Application.Quit();
    }

}
