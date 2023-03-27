using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private SpriteRenderer background;
    public GameObject bkg;
    public GameObject bkg_2;
    public GameObject bkg_3;

    private float offset;
    private float width;
    private Vector3 initial_pos;

    // Start is called before the first frame update
    void Start()
    {
        bkg = this.gameObject.transform.GetChild(0).gameObject;
        bkg_2 = this.gameObject.transform.GetChild(1).gameObject;
        bkg_3 = this.gameObject.transform.GetChild(2).gameObject;

        background = bkg.GetComponent<SpriteRenderer>();
        width = background.sprite.bounds.size.x * 1.2f;
        offset = transform.position.x + width;
        //initial_pos = bkg_3.transform.position;

        bkg_2.transform.position = bkg.transform.position + new Vector3(width - 0.5f, 0, 0);
        bkg_3.transform.position = bkg_2.transform.position + new Vector3(width - 0.5f, 0, 0);

        initial_pos = bkg_3.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        bkg.transform.Translate(new Vector3 (-0.002f, 0, 0));
        bkg_2.transform.Translate(new Vector3(-0.002f, 0, 0));
        bkg_3.transform.Translate(new Vector3(-0.002f, 0, 0));

        if (bkg.transform.position.x + width < 0)
        {
            bkg.transform.position = initial_pos;
        }

        if(bkg_2.transform.position.x + offset < 0)
        {
            bkg_2.transform.position = initial_pos;
        }

        if(bkg_3.transform.position.x + offset < 0)
        {
            bkg_3.transform.position = initial_pos;
        }
    }
}
