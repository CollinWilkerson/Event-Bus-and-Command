using System.Collections;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{

    private float _currentTime;
    private float duration = 3.0f;

    private void OnEnable()
    {
        RaceEventBus.Subscribe(RaceEventType.COUNTDOWN, StartTimer);
    }

    private void OnDisable()
    {
        RaceEventBus.Unsubscribe(RaceEventType.COUNTDOWN, StartTimer);
    }

    private void StartTimer()
    {
        StartCoroutine(Countdown());
    }

    //start race after duration seconds
    private IEnumerator Countdown()
    {
        _currentTime = duration;

        while(_currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            _currentTime--;
        }

        RaceEventBus.Publish(RaceEventType.START);
    }
}
