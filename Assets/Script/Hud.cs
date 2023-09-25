/*Hud deve mostrare punteggio, numero di vite del giocatore, tempo di gioco
 * 
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hud : MonoBehaviour
{
    public static Hud hud;

    public TMP_Text times;
    public TMP_Text points;

    public int point;

    
    // Start is called before the first frame update
    void Start()
    {
        hud = this;
        point = 0;
    }

    // Update is called once per frame
    void Update()
    {
        times.text = Time.realtimeSinceStartup.ToString();
        points.text = point.ToString();
    }
}
