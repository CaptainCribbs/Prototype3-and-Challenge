using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    private AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float gravityModifier = 1.5f;
    public float jumpForce = 10.0f;
    public bool isOnGround = true;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver){
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            isOnGround = false;
            dirtParticle.Stop();
            audioSource.PlayOneShot(jumpSound, 1.0f);
        }
        
    }

    private void OnCollisionEnter(Collision collision){

        if (collision.gameObject.CompareTag("Ground")){
          isOnGround = true;  
          dirtParticle.Play();
        }
        
        if (collision.gameObject.CompareTag("Obstacle")){
            explosionParticle.Play();
            dirtParticle.Stop();
            Debug.Log("Game Over!");
            gameOver = true;  
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            audioSource.PlayOneShot(crashSound, 1.0f);
        }
    }
}
