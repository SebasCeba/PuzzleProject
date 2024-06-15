using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform laserAim; 
    public float range = 5;
    public int damage = 10; //Amount of damage to deal to the player 
    public float damageInterval = 1f; //Creates an interval between each damage 
    private float lastDamageTime; 

    private HealthModule playerHealth;
    void Start()
    {
        playerHealth = FindObjectOfType<HealthModule>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = laserAim.forward;
        Ray laserRay = new Ray(laserAim.position, direction);

        if(Physics.Raycast(laserRay, out RaycastHit hit, range))
        {
            if (hit.collider.CompareTag("Player") && Time.time - lastDamageTime >= damageInterval)
            {
                playerHealth.DeductHealth(damage); 
                lastDamageTime = Time.time;
            }
            else if(hit.collider.CompareTag(tag))
            {
                Debug.Log("you are lucky that you aren't a player");
            }
            Debug.DrawRay(laserAim.position, direction * hit.distance, Color.red);
        }
        else
        {
            Debug.DrawRay(laserAim.position, direction * range, Color.green); 
        }
    }
}
