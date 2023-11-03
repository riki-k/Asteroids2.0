using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    private Animator myAnim;
    public bool tranistionFinished;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        tranistionFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (tranistionFinished)
            FSM.fsm.state = FSM.gamestate.title;
    }

    public void returnToTitle()
    {
        myAnim.Play("FadeOut");
    }

    //ended
}
