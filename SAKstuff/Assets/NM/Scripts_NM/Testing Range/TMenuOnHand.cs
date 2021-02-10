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
    public Transform rightHand;
    private Vector3 toolMenuPos;
    private bool on = false;

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
            this.transform.rotation = rightHand.transform.rotation;

            // transform
            toolMenuPos.x = rightHand.transform.position.x;
            toolMenuPos.y = rightHand.transform.position.y;
            toolMenuPos.z = rightHand.transform.position.z;
            this.transform.position = toolMenuPos;
        }
    }
}
