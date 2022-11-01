using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerTurns : MonoBehaviour
{
    public Button redButton;
    public Button blueButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MainManager.Instance.redPlayer == 1 && MainManager.Instance.bluePlayer == 0 && MainManager.Instance.gameCount == 1)
        {
            redButton.gameObject.SetActive(false);
        }

        if(MainManager.Instance.redPlayer == 0 && MainManager.Instance.bluePlayer == 1 && MainManager.Instance.gameCount == 1)
        {
            blueButton.gameObject.SetActive(false);
        }
    }
// Edd_Luna
}
