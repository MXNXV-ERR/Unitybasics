using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool jumpKey;
    private float horizontalinput;
    private Rigidbody rigidBodyComp;
    private bool grounded;
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
        if(!grounded)
            return;

        if (jumpKey)
        {
           rigidBodyComp.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jumpKey = false;
        }
        rigidBodyComp.velocity = new Vector3(horizontalinput, rigidBodyComp.velocity.y, 0);
    }

    private void OnCollisionEnter(Collision collision)=> grounded = true;

    private void OnCollisionExit(Collision collision) => grounded = false;
    
}
