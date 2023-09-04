using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main main;

    public EventSystem Event;
    public Camera gameCamera;

    public bool camera_menu_position;
    public bool camera_game_position;

    // Start is called before the first frame update
    void Start()
    {
        main = this;
        camera_menu_position = false;
        camera_game_position = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (FSM.fsm.state)
        {
            case FSM.gamestate.menu :
                //Event.GetComponent<EventSystem>().enabled = false;
                Event.enabled = false;
                cameraMovement();
                break;
            case FSM.gamestate.play:
                Event.enabled = true;
                break;
        }
    }

    void cameraMovement()
    {
        if (gameCamera.transform.position.x > -25 || gameCamera.transform.position.y > -15)
        {
            if (gameCamera.transform.position.x != -25)
                gameCamera.transform.Translate(-0.1f, 0, 0);
            if (gameCamera.transform.position.y != -15)
                gameCamera.transform.Translate(0, -0.1f, 0);
        }
        else
            camera_menu_position = true;
    }
}
