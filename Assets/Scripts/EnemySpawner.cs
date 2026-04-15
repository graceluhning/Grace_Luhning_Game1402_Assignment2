using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject slimeEnemy;
    public GameObject spikeEnemy;
    public GameObject bossEnemy;

    public Transform[] spawnPoints;

    void Start()
    {
        StartCoroutine(SpawnSlime());
        StartCoroutine(SpawnSpike());
        StartCoroutine(SpawnBoss());


    }

    private IEnumerator SpawnSlime()
    {
        while (true)
        {
            {
                Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                Instantiate(slimeEnemy, randomPoint.position, randomPoint.rotation);
                yield return new WaitForSeconds(10f);
                Debug.Log("Spawned Slime!");
            }
        }
    }

    private IEnumerator SpawnSpike()
    {
            while (true)
            {
                Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                Instantiate(spikeEnemy, randomPoint.position, randomPoint.rotation);
                yield return new WaitForSeconds(10f);
                Debug.Log("Spawned Spike!");
            }
    }

    private IEnumerator SpawnBoss()
    {
        while (true)
        {
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(bossEnemy, randomPoint.position, randomPoint.rotation);
            yield return new WaitForSeconds(30f);
            Debug.Log("Spawned Boss!");
        
        }
    }
}
