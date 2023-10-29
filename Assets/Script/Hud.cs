/*Hud deve mostrare punteggio, numero di vite del giocatore, tempo di gioco
 * 
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hud : MonoBehaviour
{
    public static Hud hud;

    public TMP_Text times;
    public TMP_Text points;
    public TMP_Text pressToRestart;
    public Image imageLife_1;
    public Image imageLife_2;
    public Image imageLife_3;

    public int point;
    PlayerController Player;
    
    // Start is called before the first frame update
    void Start()
    {
        hud = this;
        point = 0;
        pressToRestart.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        times.text = Time.realtimeSinceStartup.ToString();
        points.text = Main.main.playerPoint.ToString();
        switch(FSM.fsm.state)
        {
            case FSM.gamestate.play :
                pressToRestart.enabled = false;
                break;
            case FSM.gamestate.dead:
                if(Main.main.deadAnimationFinished)
                    pressToRestart.enabled = true;
                switch (FindObjectOfType<PlayerController>().life)
                {
                    case 3:
                        break;
                    case 2:
                        imageLife_1.enabled = false;
                        break;
                    case 1:
                        imageLife_2.enabled = false;
                        break;
                    case 0:
                        imageLife_3.enabled = false;
                        break;
                }
                
                break;
        }
    }
}
