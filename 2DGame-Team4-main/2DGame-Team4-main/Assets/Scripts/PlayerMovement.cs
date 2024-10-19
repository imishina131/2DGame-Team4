using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float moveSpeed = 5;
    Rigidbody2D playerRigidBody;
    float jump = 250;
    Vector3 characterScale;
    float characterScaleX;
    // Start is called before the first frame update
    void Start()
    {

        playerRigidBody = GetComponent<Rigidbody2D>();
        characterScale = transform.localScale;
        characterScaleX = characterScale.x;
    }

    // Update is called once per frame
    void Update()
    {

        /*if (Input.GetKey(KeyCode.D))
        {
            characterScale.x = 10;
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.A))
        {
            characterScale.x = -10;
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
        */

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
        }

        // the player attack with a fireball
    }
}
