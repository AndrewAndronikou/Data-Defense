using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] Transform spawnPoint;

    [SerializeField] float timeBetweenSpawn = 3f;
    private float countdown = 2f;

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(spawnEnemy());
            countdown = timeBetweenSpawn;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
    }

    IEnumerator spawnEnemy()
    {
        GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPoint.position, spawnPoint.rotation);

        yield return new WaitForSeconds(timeBetweenSpawn);
    }
}
