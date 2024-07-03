using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PressurePad : MonoBehaviour
{   public int row , col ; 
    [SerializeField] private float pressedDownYPosition;
    [SerializeField] private Material[] buttonPressed;
    [SerializeField] private MeshRenderer mesh;
    public bool state = false;
    public UnityEvent<bool, int, int> ButtonPressed; 

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            transform.position += new Vector3(0, -pressedDownYPosition, 0);
            mesh.materials = buttonPressed;
            state = true;
            ButtonPressed.Invoke(state, row, col);
        }
    }
}
