using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class ChangeScene : MonoBehaviour
{
    public TMP_Text press_any_key;
    public EventSystem press_to_menu;
    public GameObject sky;

    //the index of the scenes is setted in BuildSetting of the project
    //0 --> MainScene
    //1 --> MainMennu
    //2 --> GameScene

    bool space_pressed = false;

    public enum menu_state
    {
        Title,
        ToMainMenu,
        MainMenu,
        ToGame
    }

    public menu_state state;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //inibire tasto space
        //finche non finita transazione "camera" non cambio scena

        switch (state)
        {
            case menu_state.Title:
                if (!space_pressed)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        press_any_key.text = "";
                        press_to_menu.GetComponent<EventSystem>().enabled = false;
                        state = menu_state.ToMainMenu;
                    }
                }
                break;
            case menu_state.ToMainMenu:
                //move sky and change scene
                if (sky.transform.position.x > 0 && sky.transform.position.y > 0)
                {
                    SceneManager.LoadScene(1, LoadSceneMode.Additive);
                    state = menu_state.MainMenu;
                    break;
                }
                else
                {
                    sky.transform.Translate(0.1f, 0, 0);
                    sky.transform.Translate(0, 0.1f, 0);
                }
                break;
            case menu_state.ToGame:
                sky = FindObjectOfType<GameObject>().gameObject;
                if(sky.transform.position.y < 15)
                {
                    sky.transform.Translate(0, 0.1f, 0);
                }
                else
                {
                    SceneManager.UnloadSceneAsync(1);
                    SceneManager.LoadScene(2, LoadSceneMode.Additive);
                }
                break;
        }

    }

    public void LoadNewgame()
    {
        state = menu_state.ToGame;
    }

    public void QuitGame()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            Application.Quit();
        }
    }
}
