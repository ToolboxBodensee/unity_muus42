using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 20f;
    public float rotationSpeed = 200f;
    public float jumpForce = 50f;

    private bool canJump = true;
    
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject theRealMouse = GameObject.Find("maus+animations");
        animator = theRealMouse.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        
        float axisHorizontal = Input.GetAxis ("Horizontal");
        float axisVertical = Input.GetAxis ("Vertical");
        
        transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * axisHorizontal * rotationSpeed);
        
        rb.AddForce(transform.forward * walkSpeed * axisVertical);
        
        if (Mathf.Abs(axisVertical) > 0.05)
            animator.SetBool("walking", true);
        else
            animator.SetBool("walking", false);
        
        if (Input.GetButton("Fire1") && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
            animator.SetBool("jumping", true);
        }
        
        RaycastHit rh;
        Physics.Raycast(transform.position, Vector3.down, out rh);
        
        if (rh.distance <= 0.55)
        {
            canJump = true;
            animator.SetBool("jumping", false);
        }
            
        Debug.DrawRay(transform.position, Vector3.down * rh.distance, Color.yellow);
    }
}
