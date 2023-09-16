using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveBackground : MonoBehaviour
{
    //game dynamic background
    public GameObject bkg;
    public GameObject bkg_2;
    public GameObject bkg_3;

    private float switch_x_coordinate;
    private float offset;
    private float highest_x;
    public int background_num = 3;
    public GameObject [] righterSprite;
    public Vector3 borders;

    // Start is called before the first frame update
    void Start()
    {
        //init parallax background
        bkg = this.gameObject.transform.GetChild(0).gameObject;
        bkg_2 = this.gameObject.transform.GetChild(1).gameObject;
        bkg_3 = this.gameObject.transform.GetChild(2).gameObject;

        offset = 2f;
        highest_x = 0;

        righterSprite = new GameObject[background_num];

        try
        {
            righterSprite[0] = bkg;
            righterSprite[1] = bkg_2;
            righterSprite[2] = bkg_3;
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

        borders = Main.main.gameCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Main.main.transform.position.z));
        switch_x_coordinate = (Main.main.gameCamera.transform.position.x - borders.x);

        bkg_2.transform.position = new Vector3(bkg.transform.position.x + (bkg.GetComponent<SpriteRenderer>().size.x), bkg_2.transform.position.y, bkg_2.transform.position.z);
        bkg_3.transform.position = new Vector3(bkg_2.transform.position.x + (bkg_2.GetComponent<SpriteRenderer>().size.x), bkg_3.transform.position.y, bkg_3.transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        //switch()
        bkg.transform.Translate(new Vector3(-0.002f, 0, 0));
        bkg_2.transform.Translate(new Vector3(-0.002f, 0, 0));
        bkg_3.transform.Translate(new Vector3(-0.002f, 0, 0));
        
        for (int i = 0; i < righterSprite.Length; i++)
        {
            if (i > 0)
                if (righterSprite[i].transform.position.x > righterSprite[i - 1].transform.position.x)
                    highest_x = righterSprite[i].transform.position.x + (righterSprite[i].GetComponent<SpriteRenderer>().size.x / 2);
                else
                    { }
            else
            {
                if (highest_x < (righterSprite[0].transform.position.x + (righterSprite[0].GetComponent<SpriteRenderer>().size.x / 2)))
                    highest_x = righterSprite[0].transform.position.x + (righterSprite[0].GetComponent<SpriteRenderer>().size.x / 2);
            }
                

            if ((righterSprite[i].transform.position.x + (righterSprite[i].GetComponent<SpriteRenderer>().size.x / 2)) < (Main.main.gameCamera.transform.position.x + switch_x_coordinate) - offset)
            {
                righterSprite[i].transform.position = new Vector3(highest_x + (righterSprite[i].GetComponent<SpriteRenderer>().size.x / 2), righterSprite[i].transform.position.y, righterSprite[i].transform.position.z);
                Debug.Log("switch position");
            }
                
        }
    }
}
