using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SAKMovement : MonoBehaviour
{
    private Animator SAKanim;
    // Start is called before the first frame update
    void Start()
    {
        SAKanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //AnimatorStateInfo stateInfo = SAKanim.GetCurrentAnimatorStateInfo(0);
    }

    public void ButtonPressed()
    {
        Flip();
    }

    public void ButtonRepressed()
    {
        Unflip();
    }

    public void Flip()
    {
        Debug.Log("Flipped");
        SAKanim.SetBool("Open", true);
    }

    public void Unflip()
    {
        Debug.Log("Unflipped");
        SAKanim.SetBool("Open", false);
    }
}
