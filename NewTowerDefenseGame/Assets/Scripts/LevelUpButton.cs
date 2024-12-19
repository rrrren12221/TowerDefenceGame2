using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelUpButton : MonoBehaviour
{
    Wallet wallet => Wallet.instance;

    [SerializeField] Text levelText;
    [SerializeField] Text priceText;

    int level = 1;
    [SerializeField] int[] price;

    Button button => GetComponent<Button>();

    bool isMax = false;

    // Start is called before the first frame update
    void Start()
    {
        levelText.text = "Level" + level.ToString();
        priceText.text = price[level - 1].ToString() + "�~";
    }

    // Update is called once per frame
    void Update()
    {
        if(!isMax)
        {
            if (wallet.nowCoin >= price[level - 1])
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
        
    }

    public void OnClick()
    {
        if (level >= price.Length) 
        {
            //MAX�ɂȂ�Ƃ��̏���
            isMax = true;
            priceText.text = "MAX";
            levelText.gameObject.SetActive(false);
            button.interactable = true;
            button.enabled = false;
        }
        else
        {
            //�K�v�ȋ��z�̏���
            wallet.nowCoin -= price[level - 1];

            //���x�����グ��
            level++;

            //�R�C���̃X�s�[�h���グ��
            wallet.coinSpeed += 6;

            //text�\����ύX
            levelText.text = "Level" + level.ToString();
            priceText.text = price[level - 1].ToString() + "�~";

            //���z��MaxCoin��ύX
            wallet.coinLevel++;
        }
        
    }
}
