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
        priceText.text = price.ToString() + "円";
    }

    private void Update()
    {
        if (wallet.nowCoin >= price) 
        {
            //ボタンを押せる
            button.interactable = true;
        }
        else
        {
            //ボタンが押せない
            button.interactable = false;
        }
    }

    //ボタンを押したときに呼ばれる関数
    public void OnClick()
    {
        //お金の支払い
        wallet.nowCoin -= price;

        //Playerの召喚
        PlayerSpawn();
        //ボタンを押せないようにする

        //ゲージを出す
    }
    
    void PlayerSpawn()
    {
        float y = Random.Range(-0.8f, -1.7f);
        SpriteRenderer pl = Instantiate(player, new Vector3(6.6f, y, 0), transform.rotation);
        pl.sortingOrder = (int)(-y * 10);
    }
}
