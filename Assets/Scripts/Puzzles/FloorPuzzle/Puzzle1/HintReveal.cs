using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HintReveal : MonoBehaviour
{
    [SerializeField] private GameObject instructions;
    private void Start()
    {
        instructions.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            instructions.SetActive(true) ;
        }
    }

}
