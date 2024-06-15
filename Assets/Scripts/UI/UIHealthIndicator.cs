using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIHealthIndicator : MonoBehaviour 
{
    public TextMeshProUGUI healthText; 
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<HealthModule>().OnUnityEventHealthChanged.AddListener(SetHealthText); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetHealthText(int healthValue)
    {
        healthText.text = healthValue.ToString();

        //"health: " + value.toString();
        //healthText.text = "HEALTH: " + value
    }
}
