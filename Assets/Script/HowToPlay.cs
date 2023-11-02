using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    private Animator myAnim;
    public bool fadeInTransitionTerminated;
    public bool fadeOutTransitionTerminated;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        myAnim.Play("FadeIn");
        fadeInTransitionTerminated = false;
        fadeOutTransitionTerminated = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (fadeOutTransitionTerminated)
            FSM.fsm.state = FSM.gamestate.menu;
    }

    public void backToMenu()
    {
        myAnim.Play("FadeOut");
    }
}
