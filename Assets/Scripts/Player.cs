using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour //INHERITANCE
{
    private float speed= 25f;
    private Rigidbody playerRb;
    public GameManager Manager;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        MovePlayer(); //ABSTRACTION
        PlayerScore();
        
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    protected abstract void PlayerScore();// POLYMORPHISM
  
}

