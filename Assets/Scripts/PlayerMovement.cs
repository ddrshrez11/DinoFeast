using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public int size;
    public int count;
    public Text DieText;
    private Rigidbody rb;
    public float MoveForce;
    private bool moveRight;
    private bool moveLeft;
    private bool moveForward;
    private bool moveBackward;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        size = 1;
        count = 0;
        DieText.text = "";
    }

    private void Update()
    {
        moveForward = false;
        moveBackward = false;
        moveLeft = false;
        moveRight = false;
        if (Input.GetKey("w"))
        {
            moveForward = true;
        }
        if (Input.GetKey("s"))
        {
            moveBackward = true;
        }
        if (Input.GetKey("d"))
        {
            moveRight = true;
        }
        if (Input.GetKey("a"))
        {
            moveLeft = true;
        }
    }
    void FixedUpdate()
    {
        if (moveForward)
        {
            rb.AddForce(0, 0, MoveForce * Time.deltaTime,ForceMode.VelocityChange);
        }
        if (moveBackward)
        {
            rb.AddForce(0, 0, -MoveForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (moveRight)
        {
            rb.AddForce(MoveForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (moveLeft)
        {
            rb.AddForce(-MoveForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (rb.position.y < -1f)
        {
            Debug.Log("Game Over");
            DieText.text = "You Are Dead!";
            //FindObjectOfType<GameManager>().EndGame();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            if(other.GetComponent<Patrol>().size < size)
            {
                 other.gameObject.SetActive(false);
                 count++;
                 if (count ==2)
                {
                    size++;
                    transform.localScale = new Vector3(1 * size, 1 * size, 1 * size);
                    count = 0;
                }
            }
            else
            {
                gameObject.SetActive(false);
                DieText.text = "You Are Dead!";
            }
            
        }
    }
}
