using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMovement : MonoBehaviour
{
    public int size;
    //float timeCounter = 0;

    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        /*timeCounter += Input.GetAxis("Horizontal") * Time.deltaTime; // multiply all this with some speed variable (* speed);
        float x = Mathf.Cos(timeCounter);
        float y = Mathf.Sin(timeCounter);
        float z = 0;
        transform.position = new Vector3(x, y, z);*/
    }

}