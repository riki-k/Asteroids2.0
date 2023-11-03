using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameData score = new GameData();
    public scoringStruct valueContainer;

    string path = "C:/Users/ricca/OneDrive/Progetti/Asteroids/Asteroids2.0/Assets";
    string filename = "savedata";

    public TMP_Text Title;
    public GameObject InputField;
    public GameObject newGameButton;
    public GameObject highScoreButton;
    public GameObject exitButton;
    public GameObject saveButton;
    private Animator myAnim;
    public bool newGametransitionFinished;
    public bool mainMenuTransitionFinished;
    public bool change;

    // Start is called before the first frame update
    void Start()
    {
        newGameButton.SetActive(false);
        highScoreButton.SetActive(false);
        exitButton.SetActive(false);

        saveButton.SetActive(true);
        Title.enabled = true;
        InputField.SetActive(true);

        myAnim = GetComponent<Animator>();
        newGametransitionFinished = false;
        mainMenuTransitionFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(newGametransitionFinished)
            FSM.fsm.state = FSM.gamestate.play;
        if (mainMenuTransitionFinished)
            FSM.fsm.state = FSM.gamestate.menu;

        if (change)
            InternalChange();
    }

    public void LoadNewgame()
    {
        myAnim.Play("FadeOut");
    }
    public void LoadMainMenu()
    {
        myAnim.Play("FadeOutMenu");
    }

    public void Savedata()
    {
        Main.main.playerName = InputField.GetComponent<TMP_InputField>().text;
        saveToFile();

        myAnim.Play("Internal");
    }

    void InternalChange()
    {
        saveButton.SetActive(false);
        Title.enabled = false;
        InputField.SetActive(false);

        newGameButton.SetActive(true);
        highScoreButton.SetActive(true);
        exitButton.SetActive(true);
    }

    void saveToFile()
    {
        //load the value from the file into a list/array
        Load();

        //add point
        valueContainer.text = Main.main.playerName;
        valueContainer.value = Main.main.playerPoint;
        score.playerInfo.Add(valueContainer);

        //sort the list - 
        //score.playerInfo.Reverse();
        //score.playerInfo = score.playerInfo.OrderByDescending(x => score.playerInfo.).ToList();
        sortingList();

        //if score.lenght > 5, erase the last element
        if (score.playerInfo.Count > 5)
            score.playerInfo.RemoveAt(5);

        //save data into file
        Save();
        resetAll();
    }

    void sortingList()
    {
        int listIndex = 0;
        scoringStruct temp;
        for (int i = 0; i < score.playerInfo.Count; i++)
        {
            int max = 0;
            listIndex = i;
            for (int j = i; j < score.playerInfo.Count; j++)
            {
                if (score.playerInfo[j].value > max)
                {
                    max = score.playerInfo[j].value;
                    listIndex = j;
                }

            }
            temp = score.playerInfo[i];
            score.playerInfo[i] = score.playerInfo[listIndex];
            score.playerInfo[listIndex] = temp;
        }
    }

    void Save()
    {
        //gameData.score = score;
        string fullPath = Path.Combine(path, filename);
        //string dataToStore = JsonUtility.ToJson(gameData, true);
        string dataToStore = JsonUtility.ToJson(score);
        using (FileStream stream = new FileStream(fullPath, FileMode.OpenOrCreate))
        {
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(dataToStore);
            }
        }
    }

    void resetAll()
    {
        Main.main.playerName = "";
        valueContainer.text = "";
        
        valueContainer.value = 0;
        Main.main.playerPoint = 0;
    }

    void Load()
    {
        int count = 0;
        string fullPath = Path.Combine(path, filename);
        if (File.Exists(fullPath))
        {
            //load the serialized data from file
            string dataToLoad = "";
            using (FileStream stream = new FileStream(fullPath, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    dataToLoad = reader.ReadToEnd();
                }
            }

            if (dataToLoad != "")
            {
                foreach (char c in dataToLoad)
                    if (c == '}' || c == '{')
                        count++;

                if (count % 2 != 0)
                    dataToLoad = dataToLoad.Remove(dataToLoad.Length - 1);

                //convert the serialized data into unity object
                //GameData gamedata = JsonUtility.FromJson<GameData>(dataToLoad);
                GameData gamedata = JsonUtility.FromJson<GameData>(dataToLoad);
                score = gamedata;
            }
        }
        else
            Debug.Log("The file don't exsist");
    }
}
