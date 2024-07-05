using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyHealth, maxHealth;
    public UnityEvent OnTurretDestoryed; 

    private void Start()
    {
        enemyHealth = maxHealth; 
    }

    public void TakeDamage(float damageAmount)
    {
        enemyHealth -= damageAmount; 

        if(enemyHealth <= 0)
        {
            OnTurretDestoryed?.Invoke();
            Destroy(gameObject);
        }
    }
}
