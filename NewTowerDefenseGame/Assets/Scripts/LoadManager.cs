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

    //�^�C�g���V�[���ֈړ�
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

    // ���Z�b�g�{�^���ȂǂŌĂяo�����\�b�h
    public void ResetPreferences()
    {
        // PlayerPrefs�̑S�Ẵf�[�^���폜
        PlayerPrefs.DeleteAll();

        // ���Z�b�g���ꂽ���Ƃ����O�ŕ\��
        Debug.Log("PlayerPrefs has been reset.");

        // ���Z�b�g��ɕK�v�ȏ�����ǉ��ł��܂��B
        // �Ⴆ�΁A�Q�[���̍ċN���⏉���������Ȃ�
    }


    //�Q�[�����I��
    public void EndGame()
    {
        Application.Quit();
    }

}
