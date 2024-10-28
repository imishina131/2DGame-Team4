using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardShooting : MonoBehaviour
{
    public GameObject orb;
    public Transform orbPos;
    private GameObject player;

    private float timer;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        int time = Random.Range(2,6);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);
        if (distance < 35)
        {
            timer += Time.deltaTime;
            if(timer > time)
            {
                timer = 0;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(orb, orbPos.position, Quaternion.identity);
        time = Random.Range(2,6);
    }
}
