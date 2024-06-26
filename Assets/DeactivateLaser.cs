using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DeactivateLaser : MonoBehaviour
{
    [SerializeField] private GameObject laserTurret;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") == laserTurret)
        {
            gameObject.SetActive(false);
            laserTurret.SetActive(false);

            Destroy(gameObject, 5f);
            Destroy(laserTurret, 5f); 
        }
    }
}
