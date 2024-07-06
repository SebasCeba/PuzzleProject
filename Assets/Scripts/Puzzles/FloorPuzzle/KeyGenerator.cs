using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyGenerator : MonoBehaviour
{
    private bool[][] answerKey;
    public UnityEvent<bool[][]> NewKeyAvailable;
    [SerializeField] private CountdownTimer timer;
    void Awake()
    {
        if (timer == null)
        {
            timer = FindAnyObjectByType<CountdownTimer>();
        }
        timer.OnTimerReset.AddListener(GenerateRandomKey);
        CreateBlankKey();
        GenerateRandomKey();
        
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
        NewKeyAvailable.Invoke(answerKey);
    }
   public bool[][] GetAnswerKey()
    {
        return answerKey;
    }
}
