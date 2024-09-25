using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody[] ragdollRb;
    private Collider boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        ragdollRb = GetComponentsInChildren<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        SetRagdollState(true);
    }

    private void SetRagdollState(bool isKinematic)
    {
        foreach (Rigidbody rigidbody in ragdollRb)
        { rigidbody.isKinematic = isKinematic; }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(boxCollider);
            SetRagdollState(false);
        }
    }
}