using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public GameObject red;
    public GameObject blue;
    public GameObject redTarget;
    public GameObject blueTarget;
    public RedPlayer currentRedScore;
    public BluePlayer currentBlueScore;
    private float spawnTime = 2.5f;
    public bool gameOver;
    public TextMeshProUGUI gameOverText;
    public Button startButton;
    public Button nextTurnButton;
    public Button exitButton;
    public TextMeshProUGUI redScoreText;
    public TextMeshProUGUI blueScoreText;
   
    IEnumerator SpawnTarget()
    {
        while(!gameOver)
        {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(redTarget);
            Instantiate(blueTarget);
        }
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

    public void StartGame()
    {
        gameOver = false;
        SelectPlayer();
        StartCoroutine(SpawnTarget());
        startButton.gameObject.SetActive(false);
        redScoreText.text ="Red Score: " + MainManager.Instance.redScore;
        blueScoreText.text ="Blue Score: " + MainManager.Instance.blueScore;
    }

    public void GameOverRed()
    {
        gameOver = true;
        gameOverText.gameObject.SetActive(true);
        if(MainManager.Instance.gameCount >=1)
        {
            MainManager.Instance.redScore = currentRedScore.redScore;
            MainManager.Instance.SaveScores(MainManager.Instance.redScore, MainManager.Instance.blueScore);
            GameOver();
        }
        else
        {
            nextTurnButton.gameObject.SetActive(true);
        } 
    }
    public void GameOverBlue()
    {
        gameOver = true;
        gameOverText.gameObject.SetActive(true);
        if(MainManager.Instance.gameCount >=1)
        {
            MainManager.Instance.blueScore = currentBlueScore.blueScore;
            MainManager.Instance.SaveScores(MainManager.Instance.redScore, MainManager.Instance.blueScore);
            GameOver();
        }
        else
        {
            nextTurnButton.gameObject.SetActive(true);
        } 
    }
    public void GameOver()
    {
            if(MainManager.Instance.redScore < MainManager.Instance.blueScore)
            {
                gameOverText.text = "Blue Wins!";
                exitButton.gameObject.SetActive(true);
            }
            if(MainManager.Instance.redScore > MainManager.Instance.blueScore)
            {
                gameOverText.text = "Red Wins!";
                exitButton.gameObject.SetActive(true);
            }
            if(MainManager.Instance.redScore == MainManager.Instance.blueScore)
            {
                gameOverText.text = "It's a Tie!";
                exitButton.gameObject.SetActive(true);
            }    
    }

    public void NextTurn()
    {
    SceneManager.LoadScene(0);
    MainManager.Instance.gameCount +=1;
    MainManager.Instance.redScore = currentRedScore.redScore;
    MainManager.Instance.blueScore = currentBlueScore.blueScore;
    MainManager.Instance.SaveScores(MainManager.Instance.redScore, MainManager.Instance.blueScore);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
#if (UNITY_WEBGL)
    Application.Quit();
#endif
    }
// Edd_Luna
}
