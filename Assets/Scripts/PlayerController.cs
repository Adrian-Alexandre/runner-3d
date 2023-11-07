using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRG; //corpo rigido do player
    private Animator playerAnim; //controla a animação 
    private AudioSource playerAudioSource;//sons do player

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public float jumpForce = 10f; //força do pulo
    public float gravityModifier = 1f; //gravidade do game
    public bool isonGround = true;//verifica se o player esta no chão
    public AudioClip jumpSound;
    public AudioClip crashSound;

    // Start is called before the first frame update
    void Start()
    {
        playerRG = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        float space = Input.GetAxis("Jump");
        if(space != 0 && isonGround == true && !GameController.gameOver)
        {
            playerAudioSource.PlayOneShot(jumpSound);
            playerAnim.SetTrigger("Jump_trig");
            playerRG.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isonGround = false;
            dirtParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isonGround = true;
            dirtParticle.Play();
        }else if(collision.gameObject.CompareTag("Obstacles"))
        {
            GameController.gameOver = true;
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudioSource.PlayOneShot(crashSound,0.5f);
            Invoke("GoToGameOver", 5f);
        }
        
    }

    void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
