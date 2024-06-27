using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField] private Transform spawnpoint; 
    public GameObject playerPrefab;
    private Vector3 currentCheckpoint;
    HealthModule healthModule;

    private void Start()
    {
        currentCheckpoint = transform.position; //Initial checkpoint 
        healthModule = playerPrefab.GetComponent<HealthModule>();
    }

    public void SetCheckPoint(Vector3 newCheckpoint)
    {
        currentCheckpoint = newCheckpoint; 
    }

    public void RespawnPlayer()
    {
        playerPrefab.transform.localPosition = spawnpoint.position;
        if(healthModule != null )
        {
            healthModule.Resethealth();
        }       
    }
}
