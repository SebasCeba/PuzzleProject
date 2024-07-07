using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private CutsceneStartType startType; 
    [SerializeField] private PlayableDirector director; 
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Singleton.OnUnityLevelStart.AddListener(StartCutscene);
        GameManager.Singleton.OnActionLevelStart += StartCutscene; 
     
    }
    private void StartCutscene()
    {
        GameManager.Singleton.LockPlayerInput();
        director.Play();
    }
    public void OnCutsceneEnd()
    {
        GameManager.Singleton.UnlockPlayerInput();
        GameManager.Singleton.OnUnityLevelStart.RemoveListener(StartCutscene);
        GameManager.Singleton.OnActionLevelStart -= StartCutscene;

        Destroy(gameObject); 
    }
}

public enum CutsceneStartType
{
    OnLevelStart, OnLevelFinish
}
