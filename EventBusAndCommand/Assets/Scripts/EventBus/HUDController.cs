using UnityEngine;

public class HUDController : MonoBehaviour
{
    private bool _isDisplayOn;
    void OnEnable()
    {
        RaceEventBus.Subscribe(
        RaceEventType.START, DisplayHUD);
    }
    void OnDisable()
    {
        RaceEventBus.Unsubscribe(
        RaceEventType.START, DisplayHUD);
    }
    //when the race starts, display this
    private void DisplayHUD()
    {
        _isDisplayOn = true;
    }

    //create a stop race event to publish the STOP event
    void OnGUI()
    {
        if (_isDisplayOn)
        {
            if (GUILayout.Button("Stop Race"))
            {
                _isDisplayOn = false;
            }
            RaceEventBus.Publish(RaceEventType.STOP);
        }
    }
}
