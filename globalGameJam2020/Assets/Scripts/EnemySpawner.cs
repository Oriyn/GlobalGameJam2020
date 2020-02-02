using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform enemyStart;
    int randomSpawnPoint;
    int enemiesOnScreen;
    int randomSpawnMonster;
    float timer = 0.0f;
    float minTime = 3.0f;
    float maxTime = 10.0f;

    void Start()
    {
        timer = Random.Range(minTime, maxTime);
    }



    void Update()
    {
        //enemiesOnScreen = GameObject.FindGameObjectsWithTag("Enemy").Length;
        timer -= Time.deltaTime;
        //Debug.Log(enemiesOnScreen);
        //Debug.Log(timer);
        if (timer <= 0.0f && enemiesOnScreen <= 12)
        {
            SpawnMonster();
            timer = Random.Range(minTime, maxTime);
        } else if (timer <= 0.0f && enemiesOnScreen > 12)
        {
            timer = Random.Range(minTime, maxTime);
        }
    }

    void SpawnMonster()
    {
        Debug.Log("Hit spawn monster");
        Instantiate(enemy, transform.position, transform.rotation);
    }
}
