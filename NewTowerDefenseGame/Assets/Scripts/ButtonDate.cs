using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDate : MonoBehaviour
{
    [SerializeField] SpriteRenderer player;
    //�{�^�����������Ƃ��ɌĂ΂��֐�
    public void OnClick()
    {
        //Player�̏���
        PlayerSpawn();
        //�{�^���������Ȃ��悤�ɂ���

        //�Q�[�W���o��
    }
    
    void PlayerSpawn()
    {
        float y = Random.Range(-0.8f, -1.7f);
        SpriteRenderer pl = Instantiate(player, new Vector3(6.6f, y, 0), transform.rotation);
        pl.sortingOrder = (int)(-y * 10);
    }
}
