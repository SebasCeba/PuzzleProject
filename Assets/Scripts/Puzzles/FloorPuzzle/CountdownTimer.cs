
using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private TextMeshPro[] timers;
    [Header("Max Time")]
    public int minutes;
    public int seconds;

    private int maxInSeconds;
    private float currentTime;
    public UnityEvent OnTimerReset;

    private void Start()
    {
        maxInSeconds = (minutes * 60) + seconds;
        PrintTime(maxInSeconds);
        currentTime = maxInSeconds;
    }
    private void FixedUpdate()
    {
        if (currentTime <= 0)
        {
            ResetTimer();
        }
        currentTime -= Time.fixedDeltaTime;
        PrintTime(Mathf.RoundToInt(currentTime));

       
    }
    private void PrintTime(int seconds)
    {
        foreach (TextMeshPro timer in timers)
        {
            int mins = seconds / 60;
            int secs = seconds % 60;
            timer.text = (LeadingZero(mins) + ":" + LeadingZero(secs));
        }
    }

    private string LeadingZero(int time)
    {
        if (time < 10)
        {
            return ("0" + time.ToString());
        }
        else if (time > 59)
        {
            return "00";
        }
        else
        {
            return (time.ToString());   
        }
    }
    public void ResetTimer()
    {
        currentTime = maxInSeconds;
        OnTimerReset.Invoke();
    }

}
