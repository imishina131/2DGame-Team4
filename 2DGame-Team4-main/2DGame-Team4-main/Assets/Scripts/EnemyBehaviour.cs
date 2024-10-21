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
        playerInstance = new Player();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 scale = transform.localScale;
        if(inRange)
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

        if(hit.collider != null)
        {
            EnemyLogic();
        }
        
        else if(hit.collider == null)
        {
            inRange = false;
        }

        if(inRange == false)
        {
            animation.SetBool("canWalk", false);
            StopAttack();
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        if (distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if (attackDistance >= distance)
        {
            Attack();
        }

    }

    void Move()
    {
        animation.SetBool("canWalk", true);
        if(!animation.GetCurrentAnimatorStateInfo(0).IsName("Goblin_attack"))
        {
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition,moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        attackMode = true;
        animation.SetBool("canWalk", false);
        animation.SetBool("Attack", true);
        playerInstance.TakeDamage();

    }

    void StopAttack()
    {
        animation.SetBool("Attack", false);
        attackMode = false;
    }

    void OnTriggerStay2D(Collider2D trigger)
    {
        if(trigger.gameObject.tag == "Player")
        {
            target = trigger.gameObject;
            inRange = true;
        }
    }

    public void TriggerCooling()
    {
        //create cooldown here
    }

}
