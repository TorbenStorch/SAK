using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdventureIcon : MonoBehaviour
{
    private bool SwitchOn;
    // Start is called before the first frame update
    void Start()
    {
        SwitchOn = this.GetComponent<ReactableIcon>().switchOn;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchOn = this.GetComponent<ReactableIcon>().switchOn;
        if (SwitchOn == true)
        {
            SceneManager.LoadScene(1);
        }
    }
}
