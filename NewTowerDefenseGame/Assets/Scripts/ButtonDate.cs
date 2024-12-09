using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDate : MonoBehaviour
{
    Wallet wallet => Wallet.instance;

    [SerializeField] SpriteRenderer player;

    [SerializeField] int price;
    [SerializeField] Text priceText;

    Button button => GetComponent<Button>();

    private void Start()
    {
        priceText.text = price.ToString() + "�~";
    }

    private void Update()
    {
        if (wallet.nowCoin >= price) 
        {
            //�{�^����������
            button.interactable = true;
        }
        else
        {
            //�{�^���������Ȃ�
            button.interactable = false;
        }
    }

    //�{�^�����������Ƃ��ɌĂ΂��֐�
    public void OnClick()
    {
        //�����̎x����
        wallet.nowCoin -= price;

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
