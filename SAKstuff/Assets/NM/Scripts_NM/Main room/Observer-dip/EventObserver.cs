using UnityEngine.Events;
using UnityEngine;

/// <summary>
/// P3 Swiss Army Knife project
/// Namgar Mardvaeva
/// Group № 2 (Iman, Namgar, Torben)
/// Summary: 
/// 1) Interface for observers
/// 2) For flipping: has to be connected with big swiss army knife (because he is observer)
/// 3) Part of the observer pattern.
/// </summary>

[System.Serializable]
public class UnityGameObjectEvent : UnityEvent<GameObject> { }

public class EventObserver : MonoBehaviour
{
    public UnityEvent currentEvent;
    public UnityGameObjectEvent response = new UnityGameObjectEvent();

    // When enabled, enroll it in corresponding event
    private void OnEnable()
    {
        currentEvent.Enroll(this);
    }

    // When disabled, unenroll it in corresponding event
    private void OnDisable()
    {
        currentEvent.Unenroll(this);
    }

    // When event took place, start corresponding method 
    public void OnEventOccurs()
    {
        response.Invoke(this.gameObject);
    }
}
