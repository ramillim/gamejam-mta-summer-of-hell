using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public int totalEnemies;
    public int spawnRadius;
    public float spawnDelay = 2f;

    private float elapsedTime = 0f;
    private int spawnCounter = 0;

    private void Update()
    {
        if (spawnCounter < totalEnemies)
        {
            if (elapsedTime > spawnDelay)
            {
                Spawn();
            }
            else
            {
                elapsedTime += Time.deltaTime;
            }
        }
    }

    private void Spawn()
    {
        var position = new Vector3(Random.Range(spawnRadius * -1, spawnRadius), 0, Random.Range(spawnRadius * -1, spawnRadius));
        Instantiate(prefab, position, Quaternion.identity);
        spawnCounter += 1;
    }
}
