using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RedPlayer : Player //INHERITANCE
{
    public TextMeshProUGUI redScoreText;
    public int m_redScore;
    public int redScore  //ENCAPSULATION
{
    get { return m_redScore; } // getter returns backing field
    set 
    {
    if (value < 0)
    {
            
            Debug.LogError("You can't set a negative score!");
    }
    else
    {
            m_redScore = value; // original setter now in if/else statement
    }
    }
}

    private void OnCollisionEnter(Collision collision) // POLYMORPHISM
    {
        if(collision.gameObject.CompareTag("Red") && !Manager.gameOver)
        {
            Debug.Log("Player has collied with enemyred.");
            redScore += 1;
            Destroy(collision.gameObject);
            Instantiate(scoreParticle, transform.position, scoreParticle.transform.rotation);
            playerAudio.PlayOneShot(scoreSound, 1.0f);
        }

        if(collision.gameObject.CompareTag("Blue") && !Manager.gameOver)
        {
            Debug.Log("Player has collied with enemy.");
            Manager.GameOverRed();
            Instantiate(failParticle, transform.position, failParticle.transform.rotation);
            playerAudio.PlayOneShot(failSound, 1.0f);
        }
    }

    protected override void PlayerScore()// POLYMORPHISM
    {
        Debug.Log("score red = " + redScore);
        redScoreText.text ="Red Score: " + redScore;

    }
// Edd_Luna
}
