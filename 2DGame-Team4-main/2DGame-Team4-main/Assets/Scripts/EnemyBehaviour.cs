using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


//make a cooldown for attacks!!!

public class EnemyBehaviour : MonoBehaviour
{
    public Transform rayCast;
    public LayerMask rayCastMask;
    public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    public GameObject player;
    public float inRangeDistance;

    private RaycastHit2D hit;
    private GameObject target;
    private Animator animation;
    private float distance;
    bool attackMode;
    bool inRange;
    Vector3 scale;
    float scaleX;
    Player playerInstance;

    void Awake()
    {
        animation = GetComponent<Animator>();
        scale = transform.localScale;
        scaleX = scale.x;
    }
    // Update is called once per frame
    void Update()
    {

        Vector3 scale = transform.localScale;


        if(target != null && IsInRange())
        {
            if(player.transform.position.x > transform.position.x)
            {
                scale.x = -scaleX;
                hit = Physics2D.Raycast(rayCast.position, Vector2.right, rayCastLength, rayCastMask);
            }
            else
            {
                scale.x = scaleX;
                hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, rayCastMask);
            }
            transform.localScale = scale;
        }

        else 
        {
            animation.SetBool("isWalking", false);
            StopAttack();

        }
    }


    bool ShouldAttack()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        return attackDistance >= distance;
    }

    bool IsInRange()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        return inRangeDistance >= distance;
    }


    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        if (ShouldAttack())
        {
            Attack();
        }
        else 
        {
            Move();
            StopAttack();
        }

    }

    void Move()
    {
        animation.SetBool("isWalking", true);
        if(!animation.GetCurrentAnimatorStateInfo(0).IsName("Goblin_attack"))
        {
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition,moveSpeed * Time.deltaTime);
        }
    }
    

    void Attack()
    {
        if (attackMode == false) 
        {
            attackMode = true;    
            animation.SetBool("isWalking", false);
            animation.SetBool("isAttacking", true);
            
        }

    }

    void StopAttack()
    {
        if (attackMode == true) 
        {
            animation.SetBool("isAttacking", false);
            attackMode = false;
        }
    }

    
    void OnTriggerStay2D(Collider2D trigger)
    {
        if(trigger.gameObject.tag == "Player")
        {
            target = trigger.gameObject;
        }
    }
    

    public void TriggerCooling()
    {
        StartCoroutine(Cooldown());//create cooldown here
    }

    IEnumerator Cooldown()
    {
        animation.SetBool("isAttacking", false);
        yield return new WaitForSeconds(4);
        if (ShouldAttack()) 
        {
            animation.SetBool("isAttacking", true);
        }
    }
}
