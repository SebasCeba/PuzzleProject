using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField] private GameObject _electricityVFX;

    public void ElectricityLeakageOn()
    {
        _electricityVFX.SetActive(true);
    }

    public void ElectricityLeakageOff()
    {
        _electricityVFX.SetActive(false);
    }
}
