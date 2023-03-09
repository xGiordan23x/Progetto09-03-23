using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        movement.Normalize();

        rb.velocity = movement * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Pickupable pickupable= other.GetComponent<Pickupable>();
        if(pickupable!= null)
        {
            IncreaseSize();
            Destroy(pickupable.gameObject);
        }
    }

    private void IncreaseSize()
    {
        transform.localScale = new Vector3(transform.localScale.x + 1, transform.localScale.y + 1, transform.localScale.z + 1);
    }
}
