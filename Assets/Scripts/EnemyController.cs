using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] enemys;

    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    // 一定間隔で出てくるようにしたい
    IEnumerator EnemySpawn()
    {
        yield return new WaitForSeconds(5f);

        while (GameManager.instance.isGame)
        {
            int r = Random.Range(0, enemys.Length);
            float y = Random.Range(-0.9f, -1.7f);
            SpriteRenderer enemy = Instantiate(enemys[r], new Vector3(-6.4f, y, 0), transform.rotation);
            enemy.sortingOrder = (int)(-y * 10);

            yield return new WaitForSeconds(10f);
        }
    }
}
