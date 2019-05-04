using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 20f;
    public float rotationSpeed = 200f;
    public float jumpForce = 50f;

    private bool canJump = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        
        float axisHorizontal = Input.GetAxis ("Horizontal");
        float axisVertical = Input.GetAxis ("Vertical");
        
        transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * axisHorizontal * rotationSpeed);
        
        rb.AddForce(transform.forward * walkSpeed * axisVertical);
        
        if (Input.GetButton("Fire1") && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
        }
        
        RaycastHit rh;
        Physics.Raycast(transform.position, Vector3.down, out rh);
        
        if (rh.distance <= 0.55)
            canJump = true;
            
        Debug.Log("can jump: " + canJump);
            
        Debug.DrawRay(transform.position, Vector3.down * rh.distance, Color.yellow);
    }
}
