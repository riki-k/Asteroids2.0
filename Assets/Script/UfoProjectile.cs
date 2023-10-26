using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoProjectile : MonoBehaviour
{
    public GameObject target;

    private float half_x_size_camera;
    private float half_y_size_camera;
    public Vector3 borders;
    private Vector3 initialPos;

    float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        borders = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        half_x_size_camera = (Main.main.gameCamera.transform.position.x - borders.x);
        half_y_size_camera = (Main.main.gameCamera.transform.position.y - borders.y);
        transform.parent = null;

        /*
        Vector3 look = transform.InverseTransformPoint(target.transform.position);
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;

        transform.Rotate(0, 0, angle);*/

        //initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 look = transform.InverseTransformPoint(target.transform.position);
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;

        transform.Rotate(0, 0, angle);

        transform.Translate(Vector3.right * Time.deltaTime * speed);*/

        transform.position = Vector2.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, Time.deltaTime * speed);

        Debug.Log(target.transform.position);

        destroyOnPlayerDead();
        destroyOutLimits();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }

    void destroyOnPlayerDead()
    {
        if (FSM.fsm.state == FSM.gamestate.dead)
        {
            Destroy(gameObject);
        }
    }

    void destroyOutLimits()
    {
        if (transform.position.x < (Main.main.gameCamera.transform.position.x + half_x_size_camera) || transform.position.x > borders.x || transform.position.y > borders.y || transform.position.y < (Main.main.gameCamera.transform.position.y + half_y_size_camera))
        {
            Destroy(gameObject);
        }

    }
}
