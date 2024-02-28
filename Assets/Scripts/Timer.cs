using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimerUI;
    [SerializeField] int seconds;
    [SerializeField] GameEvents gameEvents;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartTimer());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnValidate()
    {
        TimerUI.SetText(TimeSpan.FromSeconds(seconds).ToString(@"mm\:ss"));
    }

    IEnumerator StartTimer()
    {
        while (seconds != 0)
        {
            seconds -= 1;
            TimerUI.SetText(TimeSpan.FromSeconds(seconds).ToString(@"mm\:ss"));
            yield return new WaitForSeconds(1);
        }
        gameEvents.GameOver();
    }
}
