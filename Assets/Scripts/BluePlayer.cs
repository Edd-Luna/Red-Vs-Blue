using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BluePlayer : Player //INHERITANCE
{
    public TextMeshProUGUI blueScoreText;
    public int m_blueScore;
    public int blueScore  //ENCAPSULATION
{
    get { return m_blueScore; } // getter returns backing field
    set 
    {
    if (value < 0)
    {
            
            Debug.LogError("You can't set a negative score!");
    }
    else
    {
            m_blueScore = value; // original setter now in if/else statement
    }
    }
}


    private void OnCollisionEnter(Collision collision) // POLYMORPHISM
    {
        if(collision.gameObject.CompareTag("Blue") && !Manager.gameOver)
        {
            Debug.Log("Player has collied with enemy.");
            blueScore += 1;
            Destroy(collision.gameObject);
        }
        
        if(collision.gameObject.CompareTag("Red") && !Manager.gameOver)
        {
            Debug.Log("Player has collied with enemy.");
            //Destroy(collision.gameObject);
            Manager.GameOverBlue();
        }
    }
    protected override void PlayerScore()// POLYMORPHISM
    {
        Debug.Log("score blue = " + blueScore);
        blueScoreText.text ="Blue Score: " + blueScore;
    }

}
