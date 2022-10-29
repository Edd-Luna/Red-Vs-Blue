using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayer : Player //INHERITANCE
{
    protected override void PlayerScore()
    {
        Debug.Log("score blue = " + score);
    }

}
