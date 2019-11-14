using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeMove : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    

    void Update()
    {
        // Set the speed of rigidbody
        float h = Input.GetAxis("Horizontal") * 5;
        float v = Input.GetAxis("Vertical") * 5;

        Vector3 velocity = rb.velocity;
        velocity.x = h;
        velocity.z = v;
        rb.velocity = velocity;
		
		if (Input.GetKeyDown("space"))
		{
			Debug.Log(rb.transform.position);
		}
    }
}
