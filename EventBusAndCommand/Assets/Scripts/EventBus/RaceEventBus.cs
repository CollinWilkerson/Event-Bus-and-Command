using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public enum RaceEventType
{
    COUNTDOWN,
    START,
    RESTART,
    PAUSE,
    STOP,
    FINISH,
    QUIT
}
public class RaceEventBus
{
    private static readonly IDictionary<RaceEventType, UnityEvent> Events =
        new Dictionary<RaceEventType, UnityEvent>();

    public static void Subscribe(RaceEventType eventType, UnityAction listener)
    {
        UnityEvent thisEvent;
        //attaches a listener to an event, creates a new event if the event does not exist
        if (Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Events.Add(eventType, thisEvent);
        }
    }

    /// <summary>
    /// removes listener from the event
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="listener"></param>
    public static void Unsubscribe(RaceEventType eventType, UnityAction listener)
    {
        UnityEvent thisEvent;

        if(Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    /// <summary>
    /// calls all subscribers to do the event
    /// </summary>
    /// <param name="eventType"></param>
    public static void Publish(RaceEventType eventType)
    {
        UnityEvent thisEvent;

        if (Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}
