using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipeScript : MonoBehaviour
{
    public GameObject pipePrefab;
    public GameObject cloudPrefab; 

    private float lowestPipePoint; 
    private float highestPipePoint; 

    private float timer = 0;
    private float spawnRate = 3;
    private float cloudTimer = 0;
    private float cloudSpawnRate = 1; 

    private float heightOffset = 10; 

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        spawnRate = 3;
        cloudTimer = 0;
        cloudSpawnRate = 1;

        heightOffset = 10;
        lowestPipePoint = transform.position.y - heightOffset;
        highestPipePoint = transform.position.y + heightOffset;
        SpawnPipe();
        SpawnCloud(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (cloudTimer < cloudSpawnRate)
        {
            cloudTimer += Time.deltaTime;
        }
        else
        {
            SpawnCloud();
            cloudTimer = 0;
        }
        
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            timer = 0;
        }
    }

    private void SpawnPipe()
    {
        Instantiate(pipePrefab, new Vector3(transform.position.x, Random.Range(lowestPipePoint, highestPipePoint), transform.position.z), transform.rotation);
    }

    private void SpawnCloud()
    {
        float randomValue = Mathf.Round(Random.Range(1.00f, 2.00f) * 100.0f) / 100.0f;

        GameObject cloudObject = Instantiate(cloudPrefab, new Vector3(transform.position.x, Random.Range(lowestPipePoint - 8f, highestPipePoint + 8f), Random.Range(-0.3f, 0.3f)), transform.rotation);
        cloudObject.transform.localScale = new Vector3(randomValue, randomValue, randomValue);
    }
}
