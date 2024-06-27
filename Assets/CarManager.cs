using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject carPrefab;
    [SerializeField] private float carAbilityTimer;

    public Vector3 rotationOffset;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(carAbility()); 
        }
    }
    private IEnumerator carAbility()
    {
        Quaternion carRotation = transform.rotation * Quaternion.Euler(rotationOffset);

        GameObject car = Instantiate(carPrefab, playerTransform.position, carRotation);
        playerPrefab.SetActive(false);
        yield return new WaitForSeconds(carAbilityTimer);
        playerPrefab.SetActive(true); 
        Destroy(car);
        //Create a manager that chooses between car and player 
    }
}
