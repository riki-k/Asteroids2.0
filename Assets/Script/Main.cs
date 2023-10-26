using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

[System.Serializable]
public class scoringStruct
{
    public string text;
    public int value;
}

//game data class
[System.Serializable]
public class GameData
{
    public List<scoringStruct> playerInfo;
}

public class Main : MonoBehaviour
{
    public static Main main;
    public AudioSource Music;

    public EventSystem Event;
    public Camera gameCamera;

    public bool camera_menu_position;
    public bool camera_game_position;

    public string playerName;
    public int playerPoint;

    public bool deadAnimationFinished;

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
                if (Music.volume > 0.5f)
                    Music.volume -= 0.001f;
                break;
        }
    }

    void cameraMovement()
    {
        if (gameCamera.transform.position.x > -25 || gameCamera.transform.position.y > -25)
        {
            if (gameCamera.transform.position.x > -25)
                gameCamera.transform.Translate(-0.1f, 0, 0);
            if (gameCamera.transform.position.y >-25)
                gameCamera.transform.Translate(0, -0.1f, 0);
        }
        else
            camera_menu_position = true;
    }
}
