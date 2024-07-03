using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class GridRow : MonoBehaviour
{
    [SerializeField] private int rowNumber;
    [SerializeField] private bool[] states;
    public PressurePad[] pads;

    private void Awake()
    {
        pads = GetComponentsInChildren<PressurePad>();
        AssignID();
    }
    private void AssignID()
    {
        for (int secondIndex = 0; secondIndex < pads.Length - 1; secondIndex++)
        {
            for (int index = 0; index < pads.Length - 1 - secondIndex; index++)
            {

                if (pads[index].gameObject.transform.position.y > pads[index + 1].gameObject.transform.position.y)
                {
                    PressurePad temp = pads[index];
                    pads[index] = pads[index + 1];
                    pads[index].col = pads[index +1].col;   
                    pads[index + 1] = temp;
                    pads[index + 1].col = temp.col;
                }

            }
        }
        AssignRowID();
    }
   private void AssignRowID()
    {
        foreach (PressurePad pad in pads)
        {
            pad.row = rowNumber;
        }
    }
}
