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

    [SerializeField] Slider gaugeBar;
    bool isclicked = false;

    private void Start()
    {
        priceText.text = price.ToString() + "�~";
    }

    private void Update()
    {
        if (wallet.nowCoin >= price && !isclicked) 
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
        isclicked = true;

        //�Q�[�W���o��
        StartCoroutine(SliderUpdate());
    }
    
    void PlayerSpawn()
    {
        float y = Random.Range(-0.8f, -1.7f);
        SpriteRenderer pl = Instantiate(player, new Vector3(6.6f, y, 0), transform.rotation);
        pl.sortingOrder = (int)(-y * 10);
    }

    IEnumerator SliderUpdate()
    {
        //�Q�[�W��\��
        gaugeBar.value = 0;
        gaugeBar.gameObject.SetActive(true);

        //���Ԍo�߂ŃQ�[�W��i�߂�
        while (gaugeBar.value < gaugeBar.maxValue)
        {
            gaugeBar.value++;
            yield return new WaitForSeconds(0.1f);
        }

        //�Q�[�W���\��
        gaugeBar.gameObject.SetActive(false);

        //�܂��{�^����������悤�ɂ���
        isclicked = false;
    }
}
