using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerColor : MonoBehaviour
{
public void StartNew() //ABSTRACTION
{
    SceneManager.LoadScene(1);
}

public void SaveRed()
 {
    MainManager.Instance.redPlayer = 1;
    MainManager.Instance.bluePlayer = 0;
    MainManager.Instance.SaveColorPlayer(MainManager.Instance.redPlayer, MainManager.Instance.bluePlayer);
    StartNew(); //ABSTRACTION
 }

public void SaveBlue()
 {
    MainManager.Instance.redPlayer = 0;
    MainManager.Instance.bluePlayer = 1;
    MainManager.Instance.SaveColorPlayer(MainManager.Instance.redPlayer, MainManager.Instance.bluePlayer);
    StartNew(); //ABSTRACTION
 }
// Edd_Luna
}
