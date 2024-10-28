using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    static bool hasKey;

    public SpriteRenderer spriteRendererButton;
    public SpriteRenderer spriteRendererChest;
    public Image imageKey;
    
    public Sprite chestOpen;
    public Sprite buttonClicked;
    public Sprite buttonUnclicked;
    public Sprite keyAcquired;
    public Sprite keyMissing;

    public GameObject key;
    public GameObject portal;


    //sound effects
    public AudioClip attack;
    private AudioSource audioSource;
    public AudioClip doorOpens;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Level01")
        {
            imageKey.sprite = keyMissing;
            key.gameObject.SetActive(false);
            portal.gameObject.SetActive(false);
        }
        else if(SceneManager.GetActiveScene().name == "Level02")
        {
            imageKey.sprite = keyAcquired;
        }
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
        if(SceneManager.GetActiveScene().name == "Level01")
        {
            if(hasKey && player.enemiesKilled == 5)
            {
                portal.gameObject.SetActive(true);
            }
        }
 
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
            animator.SetBool("jumping", true);
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
            animator.SetBool("attack", true);
            StartCoroutine(Cooldown());
        }

    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("attack", false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            animator.SetBool("jumping", false);
        }

        if(other.gameObject.tag == "Button")
        {
            spriteRendererButton.sprite = buttonClicked;
            isGrounded = true;
            spriteRendererChest.sprite = chestOpen;
            key.gameObject.SetActive(true);
        }

        if(other.gameObject.tag == "Spikes")
        {
            player.TakeDamage(10);
        }

        if(other.gameObject.tag == "Door")
        {
            imageKey.sprite = keyMissing;
            hasKey = false;
            audioSource.clip = doorOpens;
            audioSource.Play();
            StartCoroutine(DestroyDoor(other.gameObject));

        }
    }

    IEnumerator DestroyDoor(GameObject other)
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(other.gameObject);
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }

        if(other.gameObject.tag == "Button")
        {
            spriteRendererButton.sprite = buttonUnclicked;
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
            Debug.Log("died");
            player.TriggerDeath();
        }

        if(other.gameObject.tag == "SetHealth")
        {
            player.SetHealthForBoss();
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Key")
        {
            hasKey = true;
            Destroy(other.gameObject);
            imageKey.sprite = keyAcquired;
        }

    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
