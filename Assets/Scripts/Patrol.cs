using UnityEngine;

public class Patrol : MonoBehaviour
{
    public int size;
    public float speed=3;
    public float FollowDist = 12;
    public float RetreatDist = 10;
    private Transform target;
    private Vector3 Position;
    private Vector3 moveSpot;
    private float waitTime;
    public float StartWaitTime;
    private float boundary = 30;
    

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Position = transform.position;
        moveSpot = new Vector3(Random.Range(Position.x - boundary, Position.x + boundary), Position.y, Random.Range(Position.z - boundary, Position.z + boundary    ));
    }
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

        if (size >= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().size)
        {
            if (Vector3.Distance(transform.position, target.position) < FollowDist)
            {
                Vector3 move = Vector3.MoveTowards(transform.position, target.position, speed * .8f * Time.deltaTime);
                move.y = 0.7f * size;
                transform.position = move;
            }
            else
            {
                RandomMov();
            }
        }
        else if (size == 0)
        {
            if ((Vector3.Distance(transform.position, target.position) < RetreatDist))
            {
                Vector3 move = Vector3.MoveTowards(transform.position, target.position, -speed * .8f * Time.deltaTime);
                move.y = 0.6f;
                transform.position = move;
            }
            else
            {
                RandomMov();
            }
        }
        else if (size < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().size)
        {
            /*if (Vector3.Distance(transform.position, target.position) < 7)
            {
                Vector3 move = Vector3.MoveTowards(transform.position, target.position, -speed *.4f * Time.deltaTime);
                move.y = 0.7f * size;
                transform.position = move;
            }
            else*/ if ((Vector3.Distance(transform.position, target.position) < RetreatDist))
            {
                Vector3 move = Vector3.MoveTowards(transform.position, target.position, -speed *.8f* size * Time.deltaTime);
                move.y = 0.7f * size;
                transform.position = move;
            }
            else
            {
                RandomMov();
            }
        }
       
    }
    void RandomMov()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpot, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, moveSpot) < 0.2f)
        {
            if (waitTime <= 0)
            {
                moveSpot = new Vector3(Random.Range(Position.x - 50, Position.x + 50), Position.y, Random.Range(Position.z - 50, Position.z + 50));
                waitTime = StartWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
