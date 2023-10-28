using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Title : MonoBehaviour
{
    public TMP_Text press_any_key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(FSM.fsm.state)
        {
            case FSM.gamestate.title :
                if (Input.anyKeyDown)
                    FSM.fsm.state = FSM.gamestate.menu;
                break;
            case FSM.gamestate.menu :
                press_any_key.text = "";
                break;
        }
    }
}
