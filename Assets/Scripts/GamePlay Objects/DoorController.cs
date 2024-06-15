using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    //This needs to be in two different scripts, one with keys and the other without. 
    //Or not, just change the methods. 
    [SerializeField]
    private Animator animator;

    private bool isKeyCollected;
    [SerializeField]
    private bool needskey; 

    public void OpenDoor()
    {
        animator.SetBool("DoorOpen", true);
    }

    public void OpenWithKey()
    {
        if (needskey && !isKeyCollected)
        {
            animator.SetBool("DoorOpen", true);
        }
        else
        {
            animator.SetBool("DoorOpen", false);
        }
    }

    public void CloseDoor()
    {
        animator.SetBool("DoorOpen", false);
    }
    public void SetKeyCollected(bool collected)
    {
        isKeyCollected = collected;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnTriggerStay(Collider other) //Treated as the same as the UPdate()
    {
        //Debug.Log("Inside the trigger"); 
    }
    private void OnTriggerExit(Collider other)
    {
         
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
