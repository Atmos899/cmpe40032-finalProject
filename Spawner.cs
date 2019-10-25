using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePatterns;

    private float timeBtwnSpawn;
    public float startTimeBtwnSpawn;
    public float decreaseTime;
    public float minTime = 1.25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwnSpawn <= 0)
        {
            int random = Random.Range(0, obstaclePatterns.Length);
            Instantiate(obstaclePatterns[random], transform.position, Quaternion.identity);
            timeBtwnSpawn = startTimeBtwnSpawn;
            if (startTimeBtwnSpawn > minTime)
            {
                startTimeBtwnSpawn -= decreaseTime;
            }

        }
        else
        {
            timeBtwnSpawn -= Time.deltaTime;
        }
    }
}
