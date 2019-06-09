using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public int size;
    public int count;
    public Text DieText;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        size = 1;
        count = 0;
        DieText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            if(other.GetComponent<PickupMovement>().size < size)
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
