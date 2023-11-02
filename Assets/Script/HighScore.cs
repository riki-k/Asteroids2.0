using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using TMPro;


public class HighScore : MonoBehaviour
{
    public static HighScore highscore;
    [SerializeField] private GameData score = new GameData();
    
    string path = "C:/Users/ricca/OneDrive/Progetti/Asteroids/Asteroids2.0/Assets";
    string filename = "savedata";

    public TMP_Text Time_1;
    public TMP_Text Time_2;
    public TMP_Text Time_3;
    public TMP_Text Time_4;
    public TMP_Text Time_5;

    public TMP_Text Name_1;
    public TMP_Text Name_2;
    public TMP_Text Name_3;
    public TMP_Text Name_4;
    public TMP_Text Name_5;

    public bool fadeOutTransitionCompleted;
    private Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        highscore = this;
        fadeOutTransitionCompleted = false;
        myAnim = GetComponent<Animator>();

        //load the value from the file into a list/array
        Load();

        //write the list into the scene
        WriteInScene(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeOutTransitionCompleted)
            FSM.fsm.state = FSM.gamestate.menu;
    }

    public void ReturnToMenu()
    {
        FSM.fsm.state = FSM.gamestate.menu;
    }
    public void backButton()
    {
        myAnim.Play("FadeOut");
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

    void WriteInScene()
    {
        for(int i = 0; i < score.playerInfo.Count; i++)
        {
            switch(i)
            {
                case 0:
                    Name_1.text = score.playerInfo[i].value.ToString();
                    Time_1.text = score.playerInfo[i].text;
                    break;
                case 1:
                    Name_2.text = score.playerInfo[i].value.ToString();
                    Time_2.text = score.playerInfo[i].text;
                    break;
                case 2:
                    Name_3.text = score.playerInfo[i].value.ToString();
                    Time_3.text = score.playerInfo[i].text;
                    break;
                case 3:
                    Name_4.text = score.playerInfo[i].value.ToString();
                    Time_4.text = score.playerInfo[i].text;
                    break;
                case 4:
                    Name_5.text = score.playerInfo[i].value.ToString();
                    Time_5.text = score.playerInfo[i].text;
                    break;
            }
        }
    }

}
