using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoxToRabit_LookAt : MonoBehaviour
{

    [Range(0.0f, 1.0f)]
    public float speed = 1.0f;
    public float rotationSpeed = 100.0f;
    public bool showline = true;
    public GameObject target;
    bool clockwise = false;

    float stoppingDistance = 0.1f;

    Vector3 vDirection;
    // Start is called before the first frame update
    void Start()
    {

        vDirection = target.transform.position - this.transform.position;
        Coords dirNormal = ERMath.GetNormal(new Coords(vDirection));
        vDirection = dirNormal.ToVector();

        this.transform.forward = ERMath.LookAt2D(new Coords(this.transform.forward), 
                                                 new Coords(this.transform.position), 
                                                 new Coords(target.transform.position)).ToVector();
        
                // show the vector
        if (showline)
        {
            Coords.DrawLine(new Coords(this.transform.position), new Coords(target.transform.position), 0.2f, Color.red);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, target.transform.position) > stoppingDistance)
        {
            // move to target, but now with scalar product to slow down...
            this.transform.position += vDirection * speed * Time.deltaTime;

        }
    }
}

