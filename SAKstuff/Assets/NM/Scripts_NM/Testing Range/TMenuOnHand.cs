using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// P3 Swiss Army Knife project
/// Namgar Mardvaeva
/// Group № 2 (Iman, Namgar, Torben)
/// Summary: 
/// 1) Responsible for position of Tool menu (above the right han)
/// 2) Has to be connceted with appropriate Canvas object with tool menu
/// 3) Right hand has to be assigned in inspector
/// </summary>
public class TMenuOnHand : MonoBehaviour
{
    private GameObject toolMenuPoint;
    private Vector3 toolMenuPos;
    private bool on = false;

    // Singleton for adventure
    public static TMenuOnHand ToolMenuCanvas { set; get; }

    private void Start()
    {
        // For signleton (helps us to save tool menu, when we go in adventure)
        if (ToolMenuCanvas == null)
        {
            ToolMenuCanvas = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        // Find the point above right hand
        toolMenuPoint = GameObject.FindGameObjectWithTag("TMPoint");
    }

    // if menu button on right controller was pressed - put tool menu on hand
    public void Positioning()
    {
        if(on == false)
        {
            on = true;
        } else
        {
            on = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(on == true)
        {
            // rotation
            this.transform.rotation = toolMenuPoint.transform.rotation;

            // transform
            toolMenuPos.x = toolMenuPoint.transform.position.x;
            toolMenuPos.y = toolMenuPoint.transform.position.y;
            toolMenuPos.z = toolMenuPoint.transform.position.z;
            this.transform.position = toolMenuPos;
        }
    }
}
