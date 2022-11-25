using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float xRange = 14.5f;
    private float zRange= 14.5f;
    private float ySpawnPos = 1f;
    private Vector3 position;
    private GameObject redPlayer;
    private GameObject bluePlayer;
    // Start is called before the first frame update
    void Start()
    {    
        redPlayer = GameObject.Find("Red");
        bluePlayer = GameObject.Find("Blue");
         if(MainManager.Instance.redPlayer == 1)
         {
            RandomSpawnPos();
            SpawnRed();
            
         }

         if(MainManager.Instance.bluePlayer == 1)
        {
            RandomSpawnPos();
            SpawnBlue();
        
        }

    Vector3 RandomSpawnPos()
    {
        position = new Vector3(Random.Range(-xRange, xRange) , ySpawnPos, Random.Range(-zRange, zRange));
        return position;
    }

     void SpawnRed()
    {
        if( position.x == redPlayer.transform.position.x && position.z ==redPlayer.transform.position.z ||
            position.x == redPlayer.transform.position.x + 2 && position.z == redPlayer.transform.position.z ||
            position.x == redPlayer.transform.position.x - 2 && position.z == redPlayer.transform.position.z ||
            position.x == redPlayer.transform.position.x && position.z == redPlayer.transform.position.z + 2 ||
            position.x == redPlayer.transform.position.x && position.z == redPlayer.transform.position.z - 2 )
            {
                RandomSpawnPos();
                SpawnRed();
            }
            else 
            {
                transform.position = position;
            }
    }

     void SpawnBlue()
    {
        if( position.x == bluePlayer.transform.position.x && position.z == bluePlayer.transform.position.z ||
            position.x == bluePlayer.transform.position.x + 2 && position.z == bluePlayer.transform.position.z ||
            position.x == bluePlayer.transform.position.x - 2 && position.z == bluePlayer.transform.position.z ||
            position.x == bluePlayer.transform.position.x && position.z == bluePlayer.transform.position.z + 2 ||
            position.x == bluePlayer.transform.position.x && position.z == bluePlayer.transform.position.z - 2 )
            {
                RandomSpawnPos();
                SpawnBlue();
            }

            else 
            {
                transform.position = position;
            } 
    }

    }



// Edd_Luna
}
