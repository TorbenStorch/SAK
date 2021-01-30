using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Unity Event", order = 52)]
public class UnityEvent : ScriptableObject
{
    private List<EventObserver> eobservers = new List<EventObserver>();

    public void Register(EventObserver observer)
    {
        eobservers.Add(observer);
    }

    public void Unregister(EventObserver observer)
    {
        eobservers.Remove(observer);
    }

    // Looping throught registered observers and triggers the method
    public void Occured()
    {
        for (int counter = 0; counter < eobservers.Count; counter++)
        {
            eobservers[counter].OnEventOccurs();
        }
    }

    public void Reoccured()
    {
        for (int counter = 0; counter < eobservers.Count; counter++)
        {
            eobservers[counter].OnEventReoccurs();
        }
    }

}