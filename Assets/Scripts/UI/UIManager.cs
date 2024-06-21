using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Health UI")]
    [SerializeField] private HealthModule _playerHealthModule;
    [SerializeField] private TextMeshProUGUI _healthText;

    private void Start()
    {
        _playerHealthModule.OnUnityEventHealthChanged.AddListener(UpdateHealthUI);
        UpdateHealthUI(_playerHealthModule.GetMaxHealth());
    }

    private void UpdateHealthUI(int health)
    {
        _healthText.text = "Health : " + health.ToString();
    }
}
