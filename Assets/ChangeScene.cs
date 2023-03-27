using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //the index of the scenes is setted in BuildSetting of the project
    //0 --> MainMenu
    //1 --> NewGame

    public void LoadNewgame()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void QuitGame()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            Application.Quit();
        }
    }
}
