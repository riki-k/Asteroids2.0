using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    private bool pressed;

    // Start is called before the first frame update
    void Start()
    {
        pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch(FSM.fsm.state)
        {
            case FSM.gamestate.title :
                if (Input.GetKeyDown(KeyCode.Space))
                    FSM.fsm.state = FSM.gamestate.menu;
                break;

        }
        
    }
}
