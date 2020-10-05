using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        ProcessInput();
	}

    void ProcessInput()
    {   
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up);
            // print("Space pressed TRUST");
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(Vector3.left);
            print("turn LEFT");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(Vector3.right);
            print("turn RIGHT");
        }
    }
}
