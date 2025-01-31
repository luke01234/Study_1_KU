using System.Collections;
using UnityEngine;

public class FallingRockSpawner : MonoBehaviour
{
    //this is a script for the new rock falling system that simply spawns a bunch of rock prefabs in succession at the objects current position
    public float disableAfterTime = 10f; // Time in seconds after which the game object will be disabled
    public float spawnInterval = 2f; // Interval in seconds at which falling rocks will be spawned
    public GameObject fallingRock; // The prefab to be spawned

    private float elapsedTime = 0f; // Track the elapsed time

    void Start()
    {
        // Start the spawning coroutine
        StartCoroutine(SpawnFallingRocks());
    }

    void Update()
    {
        // Update the elapsed time
        elapsedTime += Time.deltaTime;

        // Check if the elapsed time has reached or exceeded the disable time
        if (elapsedTime >= disableAfterTime)
        {
            // Disable the game object
            gameObject.SetActive(false);
        }
    }

    private IEnumerator SpawnFallingRocks()
    {
        // Wait for a random amount of time between 0 and 1 second
        yield return new WaitForSeconds(Random.Range(0f, 1f));

        while (true)
        {
            // Instantiate the falling rock prefab at the spawner's position with no rotation
            GameObject spawnedRock = Instantiate(fallingRock, transform.position, Quaternion.identity);

            // Set a random scale between 0.5 and 2
            float randomScale = Random.Range(0.5f, 1.5f);
            spawnedRock.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

            // Wait for the spawn interval before spawning the next rock
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
