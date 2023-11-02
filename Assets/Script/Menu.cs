using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    private Animator myAnim;
    public bool transitionTerminated;
    enum gamestate
    {
        menu,
        loadNewGame,
        loadHighScore,
        loadHowTo
    }

    gamestate state;

    // Start is called before the first frame update
    void Start()
    {
        state = gamestate.menu;
        myAnim = GetComponent<Animator>();
        transitionTerminated = true;
        if (!Main.main.comeFromTitle)
            myAnim.Play("FadeIn");
        else
        {
            myAnim.Play("ShowMenu");
            Main.main.comeFromTitle = false;
        }  
    }

    // Update is called once per frame
    void Update()
    {
        if (transitionTerminated)
        {
            switch (state)
            {
                case gamestate.loadNewGame:
                    FSM.fsm.state = FSM.gamestate.play;
                    break;
                case gamestate.loadHighScore:
                    FSM.fsm.state = FSM.gamestate.highScore;
                    break;
                case gamestate.loadHowTo:
                    FSM.fsm.state = FSM.gamestate.howTo;
                    break;
            }
        }
    }

    public void LoadNewgame()
    {
        state = gamestate.loadNewGame;
        myAnim.Play("Fade");
    }

    public void HighScoreScene()
    {
        state = gamestate.loadHighScore;
        myAnim.Play("Fade");
    }

    public void HowToPlay()
    {
        state = gamestate.loadHowTo;
        myAnim.Play("Fade");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
