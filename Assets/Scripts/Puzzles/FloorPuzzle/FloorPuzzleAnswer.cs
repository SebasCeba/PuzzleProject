using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloorPuzzleAnswer : MonoBehaviour
{
    private int rows = 5 , columns = 5;
    private bool[][] inputTable;
    private bool[][] answerKey;
    private GridRow[] gridRows;
    public UnityEvent<bool[], bool[]> submit;
  

    private void Awake()
    {
        inputTable = new bool[rows][];
        answerKey = new bool[rows][];
        gridRows = GetComponentsInChildren<GridRow>();
    }
    private void Start()
    {
        for (int i = 0; i < rows; i++) 
        {
            inputTable[i] = new bool[columns];
            answerKey[i] = new bool[columns];
        }
        GetAnswerKey();
    }
    private void SubscribeToButtons()
    {
        foreach (GridRow row in gridRows) 
        {
            foreach(PressurePad pad in row.pads)
            {
                pad.ButtonPressed.AddListener(UpdateInputTable);
            }
        }
    }
    private void GetAnswerKey()
    {

    }
    
    public bool CheckAnswer()
    {
        for (int rowNum = 0; rowNum < rows; rowNum++)
        {
            for (int colNum = 0; colNum < columns; colNum++)
            {
                if (inputTable[rowNum][colNum] != answerKey[rowNum][colNum])
                {
                    return false;
                }
            }
        }
        return true;
    }
    public void UpdateInputTable(bool pressed, int row, int col)
    {
        inputTable[row][col] = pressed;
    }
}
