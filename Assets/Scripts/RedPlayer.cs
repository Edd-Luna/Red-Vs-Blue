using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayer : Player //INHERITANCE
{
    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag("Red"))
        {
            Debug.Log("Player has collied with enemyred.");
            score += 1;
            Destroy(collision.gameObject);

        }
    }

    protected override void PlayerScore()
    {
        Debug.Log("score red = " + score);
    }
   
}
