using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleRoom : MonoBehaviour
{
    [SerializeField] private bool isCompleted;
    [SerializeField] private bool isCurrentPuzzle;
    [SerializeField] private UnityEvent OnCompletedPuzzle; 
    private void OnTriggerEnter(Collider other)
    {
        isCurrentPuzzle = true;
        //Start Counting the timer 
    }
    private void OnTriggerExit(Collider other)
    {
        if(isCompleted && isCurrentPuzzle)
        {
            ExitAndFinishPuzzle();
        }
        isCurrentPuzzle = false;
    }
    public void ExitAndFinishPuzzle()
    {
        //Stop counting the timer 
        //Send timer to gameManager
            //gamemanager 
        OnCompletedPuzzle.Invoke();
        Destroy(gameObject);
    }
}
