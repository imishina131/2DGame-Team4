using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    float moveSpeed = 5;
    Rigidbody2D playerRigidBody;
    float jump = 400;
    Vector3 characterScale;
    float characterScaleX;
    private Animator animator;
    bool isGrounded;
    public Player player;
    string sceneName;


    //sound effects
    public AudioClip attack;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {

        playerRigidBody = GetComponent<Rigidbody2D>();
        characterScale = transform.localScale;
        characterScaleX = characterScale.x;
        animator = GetComponent<Animator>();
        Scene scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
 
        transform.Translate(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f);

        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -characterScaleX;
            if(isGrounded)
            {
                animator.SetBool("canWalk", true);
            }
            else
            {
                animator.SetBool("canWalk", false);
            }
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = characterScaleX;
            if(isGrounded)
            {
                animator.SetBool("canWalk", true);

            }
            else
            {
                animator.SetBool("canWalk", false);
            }

        }
        else
        {
            animator.SetBool("canWalk", false);
        }

        


        transform.localScale = characterScale;

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            animator.SetTrigger("jump");
            playerRigidBody.AddForce(new Vector2(playerRigidBody.velocity.x, jump));
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("blocking", true);//make it stop at a frame in next milestone
            player.Block();
        }

        if(Input.GetKeyUp(KeyCode.F))
        {
            animator.SetBool("blocking", false);
            player.Unshield();
        }

        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "AugmentHealth")
        {
            player.GainHealth();
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Portal")
        {
            LoadNextLevel();
        }

        if(other.gameObject.tag == "Deathzone")
        {
            player.TriggerDeath();
        }
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
