using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject red;
    public GameObject blue;
    public GameObject redTarget;
    public GameObject blueTarget;
    private float spawnRangeX, spawnRangeZ = 15f;
    private float redSpawnY = 1f;
    private float blueSpawnY= 0.3f;
    private float startDelay = 1f;
    private float spawnTime = 5f;


    void Start()
    {
        InvokeRepeating("SpawnRedTarget", startDelay, spawnTime);
        InvokeRepeating("SpawnBlueTarget", startDelay, spawnTime);

    }

    // Update is called once per frame
    void Update()
    {
        SelectPlayer();
    }

        void SelectPlayer()
        {
        if (MainManager.Instance.redPlayer == 1)
        {
            red.gameObject.SetActive(true);
            blue.gameObject.SetActive(false);
        }

        if (MainManager.Instance.bluePlayer == 1)
        {
            blue.gameObject.SetActive(true);
            red.gameObject.SetActive(false);
        }
        }

    void SpawnRedTarget()
    {
        float randomX = Random.Range( -spawnRangeX, spawnRangeX);
        float randomZ = Random.Range(-spawnRangeZ, spawnRangeZ);
        
        Vector3 spawnPos = new Vector3(randomX, redSpawnY, randomZ);

        Instantiate(redTarget, spawnPos, redTarget.gameObject.transform.rotation);
    }    

        void SpawnBlueTarget()
    {
        float randomX = Random.Range( -spawnRangeX, spawnRangeX);
        float randomZ = Random.Range(-spawnRangeZ, spawnRangeZ);
        
        Vector3 spawnPos = new Vector3(randomX, blueSpawnY, randomZ);

        Instantiate(blueTarget, spawnPos, blueTarget.gameObject.transform.rotation);
    } 
}
