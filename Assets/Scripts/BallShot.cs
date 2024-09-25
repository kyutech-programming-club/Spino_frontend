using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShot : MonoBehaviour
{
    [SerializeField] GameObject star;
    private float speed = 300;
    public Transform player_pos;

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
         Death();
         Debug.Log("cv");
        }
 
    }
    public void Death()
    {
            GameObject ball =Instantiate(star, player_pos.transform.position +new Vector3(0,0,100), Quaternion.identity);
            Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
            ballRigidbody.velocity = new Vector3(0,0,-100);
    }
}
