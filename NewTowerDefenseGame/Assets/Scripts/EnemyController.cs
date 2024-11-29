using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] enemys;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());

    }

    IEnumerator EnemySpawn()
    {
        yield return new WaitForSeconds(5f);
        while (GameManager.instance.isGame) 
        {
            int r = Random.Range(0, enemys.Length);
            float y = Random.Range(-0.8f, -1.7f);
            SpriteRenderer enemy = Instantiate(enemys[r], new Vector3(-6.6f, y, 0), transform.rotation);
            enemy.sortingOrder = (int)(-y * 10);

            yield return new WaitForSeconds(10f);
        }
    }
}
