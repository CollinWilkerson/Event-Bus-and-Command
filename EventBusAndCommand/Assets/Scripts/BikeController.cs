using UnityEngine;

public class BikeController : MonoBehaviour
{
    private void OnEnable()
    {
        RaceEventBus.Subscribe(RaceEventType.COUNTDOWN, StartTimer);
    }

}
