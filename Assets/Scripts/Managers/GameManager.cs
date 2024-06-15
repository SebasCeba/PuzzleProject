using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System; 

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton {  get; private set; }

    public UnityEvent OnUnityLevelStart = new UnityEvent();
    public Action OnActionLevelStart; 

    public UnityEvent OnUnityLevelEnds = new UnityEvent();
    public Action OnActionLevelEnds;

    private InputController player; 
    private void Awake()
    {
        if(Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
    }
    private void Start()
    {
        StartLevel();
    }
    public void StartLevel() //StartLevel needs to be called every time a scene transition happens 
    {
        player = FindObjectOfType<InputController>();

        //Start Countdown
        OnUnityLevelStart?.Invoke();
        OnActionLevelStart?.Invoke(); 
    }
    public void FinishLevel()
    {
        OnUnityLevelEnds?.Invoke(); 
        OnActionLevelEnds?.Invoke();
    }
    public void PlayerDied()
    {

    }
    public void LockPlayerInput()
    {
        player.enabled = false;
    }
    public void UnlockPlayerInput()
    {
        player.enabled = true;
    }
}
