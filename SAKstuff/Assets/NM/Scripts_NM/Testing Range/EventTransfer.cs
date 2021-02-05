using UnityEngine.Events;
using UnityEngine;

public class EventTransfer : MonoBehaviour
{
    public UnityEvent currentEvent;
    public UnityGameObjectEvent response = new UnityGameObjectEvent();

    // When enabled, enroll it in corresponding event
    private void OnEnable()
    {
        currentEvent.Register(this);
    }

    // When disabled, unenroll it in corresponding event
    private void OnDisable()
    {
        currentEvent.Unregister(this);
    }

    // When event took place, start corresponding method 
    public void OnEventTransfers(string toolName)
    {
        response.Invoke(this.gameObject);
    }
}
