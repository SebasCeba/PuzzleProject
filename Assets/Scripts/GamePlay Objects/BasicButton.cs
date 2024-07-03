using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class  BasicButton : MonoBehaviour , IInteracterable
{
    [SerializeField] private UnityEvent OnInteracted;
    [SerializeField] private Material highlightedMaterial;

    private MeshRenderer mesh;
    private Material[] originalMaterial;
    private Material[] highlightedMaterials;

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        originalMaterial = mesh.materials;
        highlightedMaterials = mesh.materials;
        highlightedMaterials[1] = highlightedMaterial;
    }
    public void OnHoverEnter()
    {
        mesh.materials = highlightedMaterials;
        Debug.Log("Why are you looking at me?");
    }

    public void OnHoverExit()
    {
        mesh.materials = originalMaterial;
        Debug.Log("Please come back! I want you to look at me! ");
    }

    public virtual void OnInteract(InteractModule interactModule)
    {
        OnInteracted.Invoke();
        Debug.Log("Are you gonna hit on me?");
    }
}
