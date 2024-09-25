using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShot : MonoBehaviour
{
    [SerializeField] GameObject star;
    private float speed = 300;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject ball = (GameObject)Instantiate(star, transform.position, Quaternion.identity);
            Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
            ballRigidbody.AddForce(-transform.forward * speed);
        }
    }
}
