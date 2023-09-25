using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class GameSceneManager : MonoBehaviour
{
    public TMP_Text title;
    public TMP_Text press_any_key;
    public EventSystem press_to_menu;
    public GameObject sky;

    private Scene load;
    //the index of the scenes is setted in BuildSetting of the project
    //0 --> MainScene
    //1 --> Title Scene
    //2 --> MainMennu
    //3 --> GameScene

    //bool space_pressed = false;

    /*
    public enum menu_state
    {
        Title,
        ToMainMenu,
        MainMenu,
        ToGame
    }

    public menu_state state;*/

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
