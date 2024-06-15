using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorKey : MonoBehaviour
{
    //This should be used for the script that requires key. 
    [SerializeField] private UnityEvent OnInteracted;
    private DoorController doorController; 

    private void Start()
    {
        doorController = GetComponent<DoorController>();
    }
    public void OnTriggerEnter(Collider other)
    {
        OnInteracted.Invoke();
        doorController.SetKeyCollected(true);
        //Destroy(gameObject);
    }
}
