using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class UnityGameObjectEvent : UnityEvent<GameObject> { }

public class EventObserver : MonoBehaviour
{
    public UnityEvent currentEvent;
    public UnityGameObjectEvent response = new UnityGameObjectEvent();

    private void OnStart()
    {
        currentEvent.Register(this);
    }

    private void OnEnd()
    {
        currentEvent.Unregister(this);
    }

    public void OnEventOccurs()
    {
        response.Invoke(this.gameObject);
    }

    public void OnEventReoccurs()
    {

    }
}
