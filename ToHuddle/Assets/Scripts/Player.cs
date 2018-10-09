using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] Animator playerAnimator;
    [SerializeField] int forceJump;
    

    //Variables used to check ground contact
    public Transform groundCheck;
    public bool isGrounded;
    public LayerMask ground;

    //collider
    public Transform collider;

    //sound
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audios;

    //Score
    public UnityEngine.UI.Text txtScore;
    public static int score;





    // Use this for initialization
    void Start () {
        score = 0;
    }

    // Update is called once per frame
    void Update () {
        Moviment();
        txtScore.text = score.ToString();
    }

    void Moviment() {

        //verifica se o player (GroundCheck) esta em contato com o chão (objeto com a layer)
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, ground);

        //jump condition 
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            playerRigidbody.AddForce(new Vector2(0, forceJump));
            audioSource.PlayOneShot(audios[0]);
        }

        //jump animation
        playerAnimator.SetBool("jump", !isGrounded);

        //slide condition and animation
        if (Input.GetMouseButtonDown(1) && isGrounded)
        {
            playerAnimator.SetTrigger("slide");
            collider.position = new Vector3(collider.position.x, collider.position.y - 0.6f, collider.position.z);
            StartCoroutine(SlideBack());
            audioSource.PlayOneShot(audios[1], 0.3f);
        }
        
        
    }

    //method to up the the collider after dash's finished
    private IEnumerator SlideBack()
    {
        yield return new WaitForSeconds(1.1f);
        collider.position = new Vector3(collider.position.x, collider.position.y + 0.6f, collider.position.z);
    }

    //method to GameOver plus set score
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            if (other.tag == "Objects")
            {
                PlayerPrefs.SetInt("Score", score);    // set current score
                if(score > PlayerPrefs.GetInt("HighScore")) //compare the current score whith high score
                {
                    PlayerPrefs.SetInt("HighScore", score); // if the player make a new record, set the new high score
                }

                SceneManager.LoadScene(1);  // change to GameOver scene
            }
        }
    }

}
