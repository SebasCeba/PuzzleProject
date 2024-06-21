using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCtrl : MonoBehaviour
{
    public GravityOrbit Gravity;
    private Rigidbody playerController;

    public float RotationSpeed = 20;
    public float gravityScale = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<Rigidbody>(); 
    }

    //Urgent - REvist the video 
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Gravity)
        {
            Vector3 gravityUp = Vector3.zero; 

            if(Gravity.FixedDirection)
            {
                gravityUp = Gravity.transform.up; 
            }
            else
            {
                gravityUp = (transform.position - Gravity.transform.forward).normalized;
            }

            gravityUp = (transform.position - Gravity.transform.position).normalized;

            Vector3 localUp = transform.up;

            Quaternion targetrotation = Quaternion.FromToRotation(localUp, gravityUp) * transform.rotation; 

            transform.up = Vector3.Lerp(transform.up, gravityUp, RotationSpeed * Time.deltaTime);

            Vector3 gravityForce = -gravityUp * Gravity.Gravity * gravityScale; 
            playerController.AddForce(gravityForce * Time.deltaTime); 
        }
    }
}
