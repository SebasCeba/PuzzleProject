using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGenerator : MonoBehaviour
{
    private bool[][] answerKey;
    private AnswerGraphic answerGraphic;
    void Awake()
    {
        if (answerGraphic == null)
        {
            answerGraphic = FindAnyObjectByType<AnswerGraphic>();
        }
        CreateBlankKey();
        GenerateRandomKey();
        answerGraphic.RequestAnswerKey.AddListener(SendAnswerKey);
            
    }

    private void CreateBlankKey()
    {
        answerKey = new bool[5][];
        for (int i = 0; i < 5; i++)
        {
            answerKey[i] = new bool[5];
            for (int j = 0; j < 5; j++)
            {
                answerKey[i][j] = new bool();
            }
        }
    }
    private void GenerateRandomKey()
    {
        for(int i = 0;i < answerKey.Length;i++)
        {
            for (int j = 0; j < answerKey[i].Length;j++)
            {
                answerKey[i][j] = (Random.value > 0.5f);
            }
        }
    }
   private void SendAnswerKey()
    {
        if (answerGraphic == null)
        {
            Debug.Log("null graphic, searching now");
            answerGraphic = FindAnyObjectByType<AnswerGraphic>();
        }
        answerGraphic.SetAnswerKey(answerKey);
    }
}
