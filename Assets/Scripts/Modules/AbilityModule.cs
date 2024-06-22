using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityModule : MonoBehaviour
{
    [SerializeField] private float carAbilityTimer; 
    public GameObject carPrefab;
    public Vector3 rotationOffset;

    private GameObject instantiatedCar; 

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(carAbility()); 
        }
    }

    public IEnumerator carAbility()
    {
        Quaternion carRotation = transform.rotation * Quaternion.Euler(rotationOffset);

        instantiatedCar = Instantiate(carPrefab, transform.position, carRotation);
        gameObject.SetActive(false);
        yield return new WaitForSeconds(carAbilityTimer); 

        if(instantiatedCar != null)
        {
            Destroy(instantiatedCar); 
        }
         
        gameObject.SetActive(true);
    }
}
