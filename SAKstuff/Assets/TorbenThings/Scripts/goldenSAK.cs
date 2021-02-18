/// P3 Swiss Army Knife project
/// Torben Storch
/// Group 2 (Iman, Namgar, Torben)
/// Summary: 
/// 1) Responsible for moving, rotation and scaling the golden SAK after the boolean is set to true 
/// 2) Has to be connceted with an animator which has an animation to open the sak -> animation I made is called goldenSAKanim

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldenSAK : MonoBehaviour
{
    Animator anim;

    [SerializeField]
    private Vector3 startPos;
    [SerializeField]
    private Vector3 startSize;

    [SerializeField]
    private float endPos;
    [SerializeField]
    private float speed;

    public ActivateFire activateFire;
    public bool activateGoldenSAK = false;


    private void Start()
    {
        anim = GetComponent<Animator>();
        transform.position = startPos;
        transform.localScale = startSize;
    }

    private void Update()
    {
        //transform.eulerAngles += Vector3.up * Time.deltaTime * (speed*30);
        if (activateGoldenSAK || activateFire.fireIsOn) //to debug - activateGoldenSAK
        {
            //transform.eulerAngles += Vector3.up * Time.deltaTime * (speed * 30);
            //if (transform.position.y <= endPos)
            //{
            //    transform.position += Vector3.up * Time.deltaTime * speed;
            //    transform.localScale += Vector3.one * 0.05f * Time.deltaTime;
            //}
            //else
            //{
            //    Invoke("openAnim", 0.5f);
            //}
            Invoke("sakAnim", 3f);
        }
    }

    void sakAnim()
    {
        transform.eulerAngles += Vector3.up * Time.deltaTime * (speed * 30);
        if (transform.position.y <= endPos)
        {
            transform.position += Vector3.up * Time.deltaTime * speed;
            transform.localScale += Vector3.one * 0.05f * Time.deltaTime;
        }
        else
        {
            Invoke("openAnim", 0.5f);
        }
    }

    void openAnim()
    {
        anim.SetTrigger("goldenSAKanimStart");
    }

}
