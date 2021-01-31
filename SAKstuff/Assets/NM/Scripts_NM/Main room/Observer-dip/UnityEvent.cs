using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// P3 Swiss Army Knife project
/// Namgar Mardvaeva
/// Group № 2 (Iman, Namgar, Torben)
/// Summary: 
/// 1) Interface for event (and partly for button itself?)
/// 2) For flipping: - (because scriptable object)
/// 3) Part of the observer pattern.
/// </summary>

[CreateAssetMenu(fileName = "New Event", menuName = "Unity Event", order = 52)]
public class UnityEvent : ScriptableObject
{
    private List<EventObserver> eobservers = new List<EventObserver>();

    // When observer appeared, put him in a list
    public void Enroll(EventObserver observer)
    {
        eobservers.Add(observer);
    }

    // When observer went out, put out him from the list
    public void Unenroll(EventObserver observer)
    {
        eobservers.Remove(observer);
    }

    // Looping throught registered observers and triggers the corresponding method
    public void Occured()
    {
        for (int counter = 0; counter < eobservers.Count; counter++)
        {
            eobservers[counter].OnEventOccurs();
        }
    }
}