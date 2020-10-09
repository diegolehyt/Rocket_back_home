using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    Rigidbody rigidbody;
    AudioSource audioSource;
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 10f;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        Thrust();
        Rotate();
	}

    void OnCollisionEnter(Collision collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("SAFE");
                break;
            case "Dead":
                print("DEAD");
                break;
        }
    }

    void Rotate()
    {
        rigidbody.freezeRotation = true;
        float rotationFrame = rcsThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
           
            transform.Rotate(Vector3.forward * rotationFrame);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationFrame);
        }
        rigidbody.freezeRotation = false;
    }

    void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up * mainThrust);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
}
