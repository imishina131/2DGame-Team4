using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//make a cooldown for attacks!!!

public class EnemyBehaviour : MonoBehaviour
{
    public Transform rayCast;
    public LayerMask rayCastMask;
    public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    public GameObject player;

    private RaycastHit2D hit;
    private GameObject target;
    private Animator animation;
    private float distance;
    bool attackMode;
    bool inRange;
    bool cooling;
    float intTimer;
    Vector3 scale;
    float scaleX;

    void Awake()
    {
        intTimer = timer;
        animation = GetComponent<Animator>();
        scale = transform.localScale;
        scaleX = scale.x;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("hit.collider" + hit.collider);
        Debug.Log("inRange" + inRange);
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
            RaycastDebugger();
        }

        if(hit.collider != null)
        {
            Debug.Log("hi");
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
        if(distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if(attackDistance >= distance && cooling == false)
        {
            Attack();
        }

        if(cooling)
        {
            CoolDown();
            animation.SetBool("Attack", false);
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
        timer = intTimer;
        attackMode = true;

        animation.SetBool("canWalk", false);
        animation.SetBool("Attack", true);
        CoolDown();
        Debug.Log("hello");
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        animation.SetBool("Attack", false);
    }

    void OnTriggerStay2D(Collider2D trigger)
    {
        if(trigger.gameObject.tag == "Player")
        {
            target = trigger.gameObject;
            inRange = true;
        }
    }

    void RaycastDebugger()
    {
        if(distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength,Color.red);
        }
        else if(distance < attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength,Color.green);
        }
    }

    void CoolDown()
    {
        timer -= Time.deltaTime;
        if(timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    public void TriggerCooling()
    {
        cooling = true;
    }
}
