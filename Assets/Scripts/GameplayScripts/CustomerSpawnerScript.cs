using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject[] customerPrefabs; 
    [SerializeField] int amountCustomersInLevel;
    [SerializeField] Vector3 spawnPosition;

    private float minSpawnTime = 10;
    private float maxSpawnTime = 15;
    private int spawnCount;

    // Start is called before the first frame update
    void Start()
    {

        spawnCount = 0;

        StartCoroutine(SpawnCustomers());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnCustomers()
    {
        while (spawnCount < amountCustomersInLevel)
        {
            //while (CountCustomersInScene() >= 1)
            //{
            //    yield return null;
            //}
            if (spawnCount < 1)
            {
                yield return new WaitForSeconds(1.0f);
            }
            else
            {
                yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            }

            if (spawnCount < amountCustomersInLevel)
            {
                GameObject customerPrefab = customerPrefabs[Random.Range(0, customerPrefabs.Length)];

                Instantiate(customerPrefab, spawnPosition, Quaternion.identity);

                spawnCount++;
            }
        }
    }
}
