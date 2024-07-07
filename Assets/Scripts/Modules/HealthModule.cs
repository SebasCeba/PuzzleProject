using UnityEngine;
using UnityEngine.Events; 
using System; 

public class HealthModule : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int currentHealth;

    public UnityEvent<int> OnUnityEventHealthChanged;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;


    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeductHealth(int health)
    {
        currentHealth -= health;
        OnUnityEventHealthChanged.Invoke(currentHealth);
        if (currentHealth <= 0)
        {
            Die(); 
        }
        Debug.Log("I lost health");
    }
    private void Die()
    {
        if(gameObject != null)
        {
            Destroy(gameObject);
            Debug.Log("Player has died");
        }
    }
}
