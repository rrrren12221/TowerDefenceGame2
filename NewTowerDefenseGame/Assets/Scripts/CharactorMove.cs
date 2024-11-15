using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMove : MonoBehaviour
{
    public enum TYPE
    {
        PLAYER,
        ENEMY,
    }

    public TYPE type = TYPE.PLAYER;

    float direction;
    Vector3 pos;

    bool isMove = true;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        switch (type)
        {
            case TYPE.PLAYER:
            //Playerの時の処理
                direction = -1;
                break;
            case TYPE.ENEMY:
            //Enemyの時の処理
                direction = 1;
                break;
        }
        pos = new Vector3(direction, 0, 0);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            transform.position += pos * Time.deltaTime;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //敵にぶつかったら(判定範囲に入ったら)移動を止める
        if (collision.gameObject.tag == "Enemy" && type == TYPE.PLAYER
            || collision.gameObject.tag == "Player" && type == TYPE.ENEMY)
        {
            isMove = false;
        }
        //攻撃をし始める
        //攻撃のアニメーションの再生
        anim.SetBool("Attack", true);
        //相手のHPを削る
        HitPoint hitPoint = collision.gameObject.GetComponent<HitPoint>();
        StartCoroutine(AttackAction(hitPoint));
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //判定範囲を抜けたら移動を再開する
        if (collision.gameObject.tag == "Enemy" && type == TYPE.PLAYER
            || collision.gameObject.tag == "Player" && type == TYPE.ENEMY)
        {
            isMove = true;
            anim.SetBool("Attack", false);
        }
    }

    IEnumerator AttackAction(HitPoint hitPoint)
    {
        while (hitPoint.hp > 0) 
        {
            yield return new WaitForSeconds(0.5f);
            hitPoint.Damage(1);
        }
    }
}
