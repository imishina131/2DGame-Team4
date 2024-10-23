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

    bool cooling = false;

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

        // inRange = IsInRange();

        
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

            if(hit.collider == null)
            {
  //              inRange = false;
            }
            else 
            {
//                inRange = true;
            }

            EnemyLogic();
        }
        else 
        {
            animation.SetBool("canWalk", false);
            StopAttack();

        }

/*
        if(inRange == true)
        {
            EnemyLogic();
        } 
        else 
        {
            animation.SetBool("canWalk", false);
            Debug.Log("before stop attack - 2");
            StopAttack();
        }
  */      

        /*
        if (cooling == true) {
            StopAttack();
            Debug.Log("cooling");
            cooling = false;
            animation.SetBool("canWalk", false);
            animation.SetBool("Attack", false);
            //StartCoroutine(Cooldown());
        }
        */


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
/*
        if (distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if (attackDistance >= distance)
        {
            Attack();
        }
    */

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
        if (attackMode == false) 
        {
            attackMode = true;    
            animation.SetBool("canWalk", false);
            animation.SetBool("Attack", true);
            
        }

    }

    void StopAttack()
    {
        if (attackMode == true) 
        {
            animation.SetBool("Attack", false);
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
        animation.SetBool("Attack", false);
        yield return new WaitForSeconds(4);
        if (ShouldAttack()) 
        {
            animation.SetBool("Attack", true);
        }
    }

}
