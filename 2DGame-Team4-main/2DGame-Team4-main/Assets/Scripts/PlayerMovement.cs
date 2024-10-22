using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float moveSpeed = 5;
    Rigidbody2D playerRigidBody;
    float jump = 400;
    Vector3 characterScale;
    float characterScaleX;
    private Animator animator;
    bool keyAIsHeld;
    bool keyDIsHeld;
    // Start is called before the first frame update
    void Start()
    {

        playerRigidBody = GetComponent<Rigidbody2D>();
        characterScale = transform.localScale;
        characterScaleX = characterScale.x;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
 
        transform.Translate(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f);

        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -characterScaleX;
        }
        

        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = characterScaleX;
        }


        transform.localScale = characterScale;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidBody.AddForce(new Vector2(playerRigidBody.velocity.x, jump));
            //animator.Play()
        }

        // the player attack with a fireball
    }
}
