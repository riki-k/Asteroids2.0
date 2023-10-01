using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class GameSceneManager : MonoBehaviour
{
    private Scene load;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (FSM.fsm.state)
        {
            case FSM.gamestate.title :
                load = SceneManager.GetSceneByName("Title");
                if (load.name == null)
                    SceneManager.LoadScene(1, LoadSceneMode.Additive);
                break;
            case FSM.gamestate.menu :
                load = SceneManager.GetSceneByName("MainMenu");
                if (load.name == null)
                    if(Main.main.camera_menu_position)
                    {
                        SceneManager.LoadScene(2, LoadSceneMode.Additive);
                        SceneManager.UnloadSceneAsync(1);
                    }        
                break;
            case FSM.gamestate.play :
                load = SceneManager.GetSceneByName("NewGameScene");
                if (load.name == null)
                {
                    SceneManager.LoadScene(3, LoadSceneMode.Additive);
                    SceneManager.UnloadSceneAsync(2);
                }
                break;
            case FSM.gamestate.gameOver:
                load = SceneManager.GetSceneByName("GameOver");
                if(load.name == null)
                {
                    SceneManager.LoadScene(4, LoadSceneMode.Additive);
                    SceneManager.UnloadSceneAsync(3);
                }
                break;
        }
    }

    public void LoadNewgame()
    {
        FSM.fsm.state = FSM.gamestate.play;
    }

    public void QuitGame()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            Application.Quit();
        }
    }
}
