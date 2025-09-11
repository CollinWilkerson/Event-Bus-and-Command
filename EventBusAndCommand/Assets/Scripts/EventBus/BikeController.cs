using UnityEngine;

public class BikeController : MonoBehaviour
{
    private string _status;
    
    //subscribe to events on start
    void OnEnable()
    {
        RaceEventBus.Subscribe(
        RaceEventType.START, StartBike);
        RaceEventBus.Subscribe(
        RaceEventType.STOP, StopBike);
    }

    //unsubscribe on stop
    void OnDisable()
    {
        RaceEventBus.Unsubscribe(
        RaceEventType.START, StartBike);
        RaceEventBus.Unsubscribe(
        RaceEventType.STOP, StopBike);
    }

    //the events to be triggered by the bus
    private void StartBike()
    {
        _status = "Started";
    }
    private void StopBike()
    {
        _status = "Stopped";
    }

    //the overlay for the game
    void OnGUI()
    {
        GUI.color = Color.green;
        GUI.Label(
        new Rect(10, 60, 200, 20),
        "BIKE STATUS: " + _status);
    }

}
