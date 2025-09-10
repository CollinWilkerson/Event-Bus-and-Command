using UnityEngine;

public class ClientEventBus : MonoBehaviour
{
    private bool _isButtonEnabled;
    [SerializeField] GameObject button;
    void Start()
    {
        gameObject.AddComponent<HUDController>();
        gameObject.AddComponent<CountdownTimer>();
        gameObject.AddComponent<BikeController>();
        _isButtonEnabled = true;
    }
    void OnEnable()
    {
        RaceEventBus.Subscribe(
        RaceEventType.STOP, Restart);
    }
    void OnDisable()
    {
        RaceEventBus.Unsubscribe(
        RaceEventType.STOP, Restart);
    }
    private void Restart()
    {
        button.SetActive(true);
    }
    //some gui error comes from here
    public void OnStartcountdown()
    {
        if (_isButtonEnabled)
        {
                button.SetActive(false);
                RaceEventBus.Publish(RaceEventType.COUNTDOWN);
           
        }
    }
}
