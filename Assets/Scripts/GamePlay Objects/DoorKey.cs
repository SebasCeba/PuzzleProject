using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorKey : MonoBehaviour
{
    //This should be used for the script that requires key. 
    [SerializeField] private UnityEvent OnInteracted;
    private DoorController doorController;

    private MeshRenderer keyRenderer;
    private CapsuleCollider keyCollider;
    private void Start()
    {
        doorController = GetComponent<DoorController>();
        if(doorController != null)
        {
            Debug.LogError("DoorController is not assigned in the DoorKey script on " + gameObject.name); 
        }

        keyRenderer = GetComponent<MeshRenderer>();
        keyCollider = GetComponent<CapsuleCollider>();

        if(keyRenderer == null)
        {
            Debug.LogError("Renderer component is missing on " + gameObject.name);
        }
        if (keyCollider == null)
        {
            Debug.LogError("Collider component is missing on " + gameObject.name);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            OnInteracted.Invoke();
            if (doorController != null)
            {
                doorController.SetKeyCollected(true);
            }
            HideKey();
        }
    }

    private void HideKey()
    {
        if(keyRenderer != null)
        {
            keyRenderer.enabled = false;
        }
        if(keyCollider != null)
        {
            keyCollider.enabled = false;
        }
    }
}
