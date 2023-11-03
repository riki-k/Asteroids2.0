using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class GameSceneManager : MonoBehaviour
{
    private Scene load;
    private Scene unload;

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
                {
                    unload = SceneManager.GetSceneByName("Credits");
                    if (!(unload.name == null))
                        SceneManager.UnloadSceneAsync(7);
                    SceneManager.LoadScene(1, LoadSceneMode.Additive);
                }              
                break;

            case FSM.gamestate.credits:
                load = SceneManager.GetSceneByName("Credits");
                if (load.name == null)
                {
                    SceneManager.LoadScene(7, LoadSceneMode.Additive);
                    SceneManager.UnloadSceneAsync(1);
                }
                break;

            case FSM.gamestate.menu :
                load = SceneManager.GetSceneByName("MainMenu");
                if (load.name == null)
                    if(Main.main.camera_menu_position)
                    {
                        unload = SceneManager.GetSceneByName("Title");
                        if(!(unload.name == null))
                            SceneManager.UnloadSceneAsync(1);
                        unload = SceneManager.GetSceneByName("HighScore");
                        if (!(unload.name == null))
                            SceneManager.UnloadSceneAsync(5);
                        unload = SceneManager.GetSceneByName("HowToPlay");
                        if (!(unload.name == null))
                            SceneManager.UnloadSceneAsync(6);
                        unload = SceneManager.GetSceneByName("GameOver");
                        if (!(unload.name == null))
                            SceneManager.UnloadSceneAsync(4);

                        SceneManager.LoadScene(2, LoadSceneMode.Additive);
                    }        
                break;

            case FSM.gamestate.play :
                load = SceneManager.GetSceneByName("NewGameScene");
                if (load.name == null)
                {
                    unload = SceneManager.GetSceneByName("GameOver");
                    if(!(unload.name == null))
                        SceneManager.UnloadSceneAsync(4);
                    SceneManager.LoadScene(3, LoadSceneMode.Additive);
                    unload = SceneManager.GetSceneByName("MainMenu");
                    if (!(unload.name == null))
                        SceneManager.UnloadSceneAsync(2);
                }
                break;

            case FSM.gamestate.gameOver:
                load = SceneManager.GetSceneByName("GameOver");
                if(load.name == null)
                {
                    if (Main.main.deadAnimationFinished)
                    {
                        SceneManager.LoadScene(4, LoadSceneMode.Additive);
                        SceneManager.UnloadSceneAsync(3);
                    }
                }
                break;

            case FSM.gamestate.highScore:
                load = SceneManager.GetSceneByName("HighScore");
                if(load.name == null)
                {
                    unload = SceneManager.GetSceneByName("MainMenu");
                    if (!(unload.name == null))
                        SceneManager.UnloadSceneAsync(2);
                    SceneManager.LoadScene(5, LoadSceneMode.Additive);
                }
                break;

            case FSM.gamestate.howTo:
                load = SceneManager.GetSceneByName("HowToPlay");
                if (load.name == null)
                {
                    unload = SceneManager.GetSceneByName("MainMenu");
                    if (!(unload.name == null))
                        SceneManager.UnloadSceneAsync(2);
                    SceneManager.LoadScene(6, LoadSceneMode.Additive);
                }
                break;
        }

    }

    public void BackToMenu()
    {
        FSM.fsm.state = FSM.gamestate.menu;
    }
}
