using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject DeathScreen;

    [SerializeField] private HealthModule healthModule;

    private void Start()
    {
        healthModule.OnPlayerDeath.AddListener(ShowDeathScreen); 
    }
    private void ShowDeathScreen()
    {
        DeathScreen.SetActive(true);
    }

    private void HideDeathScreen()
    {
        DeathScreen.SetActive(false); 
    }
}
