using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    private float speed;
    private float half_x_size_camera;
    private float half_y_size_camera;
    public Vector3 borders;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        borders = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        half_x_size_camera = (Main.main.gameCamera.transform.position.x - borders.x);
        half_y_size_camera = (Main.main.gameCamera.transform.position.y - borders.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        destroyOutLimits();
    }

    void destroyOutLimits()
    {
        if (transform.position.x < (Main.main.gameCamera.transform.position.x + half_x_size_camera) || transform.position.x > borders.x || transform.position.y > borders.y || transform.position.y < (Main.main.gameCamera.transform.position.y + half_y_size_camera))
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroids"))
        {
            Destroy(gameObject);
        }
    }
}
