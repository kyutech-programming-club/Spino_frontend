using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private float speed = 5.0f;
    private Quaternion originalRotation;
    private Rigidbody rd;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        Vector3 force = new Vector3(0.0f, 0.0f, 100.0f);    // 力を設定
        rd.AddForce(force);  // 力を加える
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Operation();
    }
    //     
    void Operation()
    {

        // 上
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection += new Vector3(0f, 0.05f, 0f);
            Invoke("Stop", 2);
        }

        // 下
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection += new Vector3(0f, -0.05f, 0f);
            Invoke("Stop", 2);
        }
        // 右
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection += new Vector3(0.05f, 0f, 0f);
            Invoke("Stop", 2);
        }
        // 左
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection += new Vector3(-0.05f, 0f, 0f);
            Invoke("Stop", 2);
        }
        // 斜め移動（上右）
        if (Input.GetKey(KeyCode.E))
        {
            moveDirection += new Vector3(0.05f, 0.05f, 0f);
            Invoke("Stop", 2);
        }
        // 斜め移動（上左）
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += new Vector3(-0.05f, 0.05f, 0f);
            Invoke("Stop", 2);
        }
        // 斜め移動（下右）
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += new Vector3(0.05f, -0.05f, 0f);
            Invoke("Stop", 2);
        }
        // 斜め移動（下左）
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += new Vector3(-0.05f, -0.05f, 0f);
            Invoke("Stop", 2);
        }
        if ((Input.GetKey(KeyCode.Z)))
        {
            moveDirection += new Vector3(0f, 0.1f, 0f);
            Invoke("Stop", 2);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            // オブジェクトを左に傾ける
            transform.Rotate(45f, 0, 0);
            moveDirection += new Vector3(-0.05f, 0f, 0f);
            Invoke("Flat", 2);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            // オブジェクトを右に傾ける
            transform.Rotate(-45, 0, 0f);
            moveDirection += new Vector3(0.05f, 0f, 0f);
            Invoke("Flat", 2);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            // オブジェクトを半回転
            transform.Rotate(0, 0, 180f);
            Invoke("Flat", 2);
        }
        // 最終的な移動
        transform.position += moveDirection * speed * Time.deltaTime;
    }
    void Stop()
    {
        moveDirection = Vector3.zero;
    }
    void Flat()
    {
        transform.rotation = originalRotation;
        moveDirection = Vector3.zero;
    }
}
