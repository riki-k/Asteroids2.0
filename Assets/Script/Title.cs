using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Title : MonoBehaviour
{
    public TMP_Text press_any_key;
    private Animator myAnim;
    public bool transitionFinished;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        transitionFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch(FSM.fsm.state)
        {
            case FSM.gamestate.title :
                if (Input.anyKeyDown && !(Input.GetKey(KeyCode.Space)))
                {
                    FSM.fsm.state = FSM.gamestate.menu;
                    Main.main.comeFromTitle = true;
                }
                else if (Input.GetKey(KeyCode.Space))
                    myAnim.Play("FadeOut");
                break;
            case FSM.gamestate.menu :
                press_any_key.text = "";
                break;
        }

        if(transitionFinished)
            FSM.fsm.state = FSM.gamestate.credits;

    }
}
