using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class DoorButton : MonoBehaviour, IInteracterable 
{
    [SerializeField] private UnityEvent OnInteracted;
    [SerializeField] private Material highlightedMaterial;
    [SerializeField] private Animator animator;

    private MeshRenderer mesh; 
    private Material originalMaterial; 

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        originalMaterial = mesh.material; 
    }
    public void OnHoverEnter()
    {
        mesh.material = highlightedMaterial;    
        Debug.Log("Why are you looking at me?"); 
    }

    public void OnHoverExit()
    {
        mesh.material = originalMaterial; 
        Debug.Log("Please come back! I want you to look at me! "); 
    }

    public void OnInteract(InteractModule interactModule)
    {
        OnInteracted.Invoke();
        Debug.Log("Are you gonna hit on me?"); 
    }
}
