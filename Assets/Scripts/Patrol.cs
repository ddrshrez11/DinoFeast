using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public int size;
    public float speed;
    public float FollowDist;
    public float RetreatDist;
    private Transform target;

/*    private float waitTime;
    private float StartWaitTime;
    public Transform[] moveSpots;
    private int randomSpot;*/

    void Start()
    {
        /*randomSpot = Random.Range(0,moveSpots.Length);*/
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        /*transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, moveSpots[randomSpot].position)<0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = StartWaitTime;
            }
            else
            {
                waitTime += Time.deltaTime;
            }
        }*/
        if (size >= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().size)
        {
            if (Vector3.Distance(transform.position, target.position) < FollowDist)
            {
                Vector3 move = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                move.y = 0;
                transform.position = move;
            }
        }
        else if (size == 0)
        {
            if ((Vector3.Distance(transform.position, target.position) < RetreatDist) && (Vector3.Distance(transform.position, target.position)) > 3)
            {
                Vector3 move = Vector3.MoveTowards(transform.position, target.position, -speed * 0.6f * Time.deltaTime);
                move.y = 0;
                transform.position = move;
            }
        }
        else if (size < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().size)
        {
            if (Vector3.Distance(transform.position, target.position) < 3)
            {
                Vector3 move = Vector3.MoveTowards(transform.position, target.position, -speed * 0.7f * Time.deltaTime);
                move.y = 0;
                transform.position = move;
            }
            else if ((Vector3.Distance(transform.position, target.position) < RetreatDist))
            {
                Vector3 move = Vector3.MoveTowards(transform.position, target.position, -speed * 0.5f * size * Time.deltaTime);
                move.y = 0;
                transform.position = move;
            }
        }
    }
}
