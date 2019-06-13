using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PickupMovement : MonoBehaviour
{
    public int size;
    float timeCounter = 0;

    float speed=2;
    float width;
    Vector3 PUPosition;
    void Start()
    {
        speed = 3;
        width = 4;
        PUPosition = transform.position;
    }
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        timeCounter += Time.deltaTime*size; // multiply all this with some speed variable (* speed);
        float x = Mathf.Cos(timeCounter*Mathf.Pow(-1,size)) * width;
        float y = 0;
        float z = Mathf.Sin(timeCounter *Mathf.Pow(-1,size))  * width;
        transform.position = PUPosition + new Vector3(x, y, z);
    }

}