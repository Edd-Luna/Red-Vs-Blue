using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour //INHERITANCE
{
    private float speed= 40f;
    private Rigidbody playerRb;
    public int score = 0;
    public bool hit = false;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        MovePlayer(); //ABSTRACTION
        /*
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
        */
        PlayerScore();
        
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag("Blue"))
        {
            Debug.Log("Player has collied with enemy.");
            score += 1;
            Destroy(collision.gameObject);
        }
    }

    protected abstract void PlayerScore();
  
}

