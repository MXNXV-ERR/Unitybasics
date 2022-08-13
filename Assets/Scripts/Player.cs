using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool jumpKey;
    private float horizontalinput;
    private Rigidbody rigidBodyComp;
    private bool grounded;
    private int superJumpsRemaining=0;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask playerMask;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComp = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            jumpKey = true;
        horizontalinput = Input.GetAxis("Horizontal");
    }

    //fixed update is called every time physics update
    private void FixedUpdate()
    {
        rigidBodyComp.velocity = new Vector3(horizontalinput, rigidBodyComp.velocity.y, 0);
        if (Physics.OverlapSphere(groundCheck.position, 0.1f,playerMask).Length==0)
            return;

        if (jumpKey)
        {
            float jumppower = 5f;
            if (superJumpsRemaining > 0)
            {
                jumppower *= 2;
                superJumpsRemaining--;
            }
           rigidBodyComp.AddForce(Vector3.up * jumppower, ForceMode.VelocityChange);
            jumpKey = false;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
            superJumpsRemaining++;
        }
    }



}
