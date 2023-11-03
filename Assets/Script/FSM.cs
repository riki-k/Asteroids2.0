using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    public enum gamestate
    {
        title,
        menu,
        play,
        dead,
        pause,
        gameOver,
        highScore,
        howTo,
        credits
    }

    public gamestate state;
    public static FSM fsm;

    // Start is called before the first frame update
    void Start()
    {
        fsm = this;
        state = gamestate.title;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
