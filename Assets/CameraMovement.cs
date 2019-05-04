using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player = null;
    public float smoothTime = 0.5f;
    private Vector3 velocity = Vector3.zero;
    
    public Vector3 nearPos = new Vector3(0, 0, 0);
    public Vector3 farPos = new Vector3(0, 0, -5);
    
    private Vector3 slerpVector = new Vector3(0, 0, 0);
    
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
            player = GameObject.Find("mouse");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        float z = player.transform.position.z;
        */
        
        Vector3 vel = player.GetComponent<Rigidbody>().velocity;
        //Debug.Log("velocity " + vel);
        
        
        float velxz = Mathf.Abs(vel.x) + Mathf.Abs(vel.z);
        
        if (velxz > 0.5f && velxz < 20.0f)
        {
            slerpVector.x = farPos.x;
            slerpVector.y = farPos.y;
            slerpVector.z = farPos.z;
            Debug.Log("so isch es");
        }
        else if (velxz >= 20.0f)
        {
            slerpVector.x = nearPos.x;
            slerpVector.y = nearPos.y;
            slerpVector.z = nearPos.z;
            Debug.Log("jetzt ischs anders");
        }

        Debug.Log(slerpVector);
        transform.localPosition = Vector3.Slerp(transform.localPosition, slerpVector, Time.deltaTime * 5.0f);
        
        /*
        Vector3 relpos = new Vector3(0f, 3f, -10f);
        relpos = player.transform.rotation * relpos;
        Vector3 newpos = player.transform.position + relpos;
        
        //transform.position = Vector3.SmoothDamp(transform.position, newpos, ref velocity, smoothTime);
        transform.position = Vector3.Lerp(transform.position, newpos, Time.deltaTime * 5.0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, 5.0f);
        */
    }
}
