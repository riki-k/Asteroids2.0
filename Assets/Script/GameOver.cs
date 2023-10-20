using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TMP_Text Title;
    public GameObject InputField;
    public GameObject newGameButton;
    public GameObject highScoreButton;
    public GameObject exitButton;
    public GameObject saveButton;


    // Start is called before the first frame update
    void Start()
    {
        newGameButton.SetActive(false);
        highScoreButton.SetActive(false);
        exitButton.SetActive(false);

        saveButton.SetActive(true);
        Title.enabled = true;
        InputField.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadNewgame()
    {
        FSM.fsm.state = FSM.gamestate.play;
    }
    public void HighScoreScene()
    {
        FSM.fsm.state = FSM.gamestate.highScore;
    }

    public void Savedata()
    {
        Main.main.playerName = InputField.GetComponent<TMP_InputField>().text;
        saveButton.SetActive(false);
        Title.enabled = false;
        InputField.SetActive(false);

        newGameButton.SetActive(true);
        highScoreButton.SetActive(true);
        exitButton.SetActive(true);
    }
}
