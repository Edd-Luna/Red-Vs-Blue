using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour //INHERITANCE
{
    private float speed= 15f;
    private Rigidbody playerRb;
    public GameManager Manager;
    public ParticleSystem scoreParticle;
    public ParticleSystem failParticle;
    public AudioSource playerAudio;
    public AudioClip failSound;
    public AudioClip scoreSound;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        MovePlayer(); //ABSTRACTION
        PlayerScore();
    }

    void MovePlayer()
    {
        if(Manager.gameOver == false)
        {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
        }
    }

    protected abstract void PlayerScore();// POLYMORPHISM
// Edd_Luna
}

