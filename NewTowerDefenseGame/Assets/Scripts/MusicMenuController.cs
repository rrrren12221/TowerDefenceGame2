using UnityEngine;
using UnityEngine.UI;

public class MusicMenuController : MonoBehaviour
{
    public Button BuckTitleButton;  // ���C�����j���[�ɖ߂�{�^��
    public Button RestartButton;    // ���X�^�[�g�{�^��
    public Button MusicButton;      // ���y���j���[���J���{�^��
    public Button LoadMusicButton;  // ���y�����[�h����{�^��
    public Button StopAudioButton;  // ���y���~����{�^��
    public Button PauseAudioButton; // ���y���ꎞ��~����{�^��
    public Button ResumeAudioButton;// ���y���ĊJ����{�^��
    public Button SelectMenuButton; // ���C�����j���[�ɖ߂�{�^��

    private bool isMusicMenuActive = false; // ���y���j���[���A�N�e�B�u���ǂ���

    void Start()
    {
        // ������Ԃ̐ݒ�
        SetActiveMusicMenu(false);

        // �e�{�^���ɃN���b�N�C�x���g��o�^
        MusicButton.onClick.AddListener(OnMusicButtonClicked);
        SelectMenuButton.onClick.AddListener(OnSelectMenuButtonClicked);
    }

    void Update()
    {
        // �G�X�P�[�v�L�[�������ꂽ�Ƃ��̓���
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // ���y���j���[���A�N�e�B�u�ɂ��āA���C�����j���[���A�N�e�B�u�ɂ���
            SetActiveMusicMenu(false);
            SetActiveMainMenu(true);
        }
    }

    // MusicButton�������ꂽ�Ƃ��̏���
    void OnMusicButtonClicked()
    {
        SetActiveMainMenu(false);
        SetActiveMusicMenu(true);
    }

    // SelectMenuButton�������ꂽ�Ƃ��̏���
    void OnSelectMenuButtonClicked()
    {
        SetActiveMusicMenu(false);
        SetActiveMainMenu(true);
    }

    // ���C�����j���[�̃{�^����L��/�����ɂ���
    void SetActiveMainMenu(bool isActive)
    {
        BuckTitleButton.gameObject.SetActive(isActive);
        RestartButton.gameObject.SetActive(isActive);
        MusicButton.gameObject.SetActive(isActive);

        if (isActive) isMusicMenuActive = false;
    }

    // ���y���j���[�̃{�^����L��/�����ɂ���
    void SetActiveMusicMenu(bool isActive)
    {
        LoadMusicButton.gameObject.SetActive(isActive);
        StopAudioButton.gameObject.SetActive(isActive);
        PauseAudioButton.gameObject.SetActive(isActive);
        ResumeAudioButton.gameObject.SetActive(isActive);
        SelectMenuButton.gameObject.SetActive(isActive);

        isMusicMenuActive = isActive;
    }
}
