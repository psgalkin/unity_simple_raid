using System;
using System.Collections.Generic;
public class EventManager : SingletonMonoBehaviour<EventManager>
{
    private Dictionary<EventId, List<Action>> subscribers = new Dictionary<EventId, List<Action>>();

    public void SendEvent(EventId eventId)
    {
        List<Action> subs;
        if (subscribers.TryGetValue(eventId, out subs))
        {
            foreach(Action action in subs)
            {
                action.Invoke();
            }
        }
    }

    public void Sub(EventId eventId, Action action)
    {
        List<Action> subs;
        if (!subscribers.TryGetValue(eventId, out subs)) {
            subs = new List<Action>();
            subscribers[eventId] = subs;
        }

        subs.Add(action);
    }

    public void Unsub(EventId eventId, Action action)
    {
        List<Action> subs = subscribers[eventId];
        subs.Remove(action);
    }

}
