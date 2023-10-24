using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo : MonoBehaviour
{
    //direction 0 = right, 1 = left
    bool direction;
    float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x > -20)
            direction = false;
        else
            direction = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (direction)
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        else
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        destroyOuterBounds();
    }

    void destroyOuterBounds()
    {
        if (transform.position.x < -37 || transform.position.x > -15)
            Destroy(gameObject);
    }
}
