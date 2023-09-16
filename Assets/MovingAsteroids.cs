using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAsteroids : MonoBehaviour
{
    private float speed;
    public int asteroids_counter;
    private float half_x_size_camera;
    private float half_y_size_camera;

    Vector3 borders;

    // Start is called before the first frame update
    void Start()
    {
        borders = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        half_x_size_camera = (Main.main.gameCamera.transform.position.x - borders.x);
        half_y_size_camera = (Main.main.gameCamera.transform.position.y - borders.y);
        speed = Random.Range(5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        if ((transform.position.x + 10) < (Main.main.gameCamera.transform.position.x + half_x_size_camera) || 
            (transform.position.x - 10) > borders.x || 
            (transform.position.y - 10) > borders.y || 
            (transform.position.y + 10) < (Main.main.gameCamera.transform.position.y + half_y_size_camera))
        {
            Destroy(gameObject);
            FindObjectOfType<SpawnManager>().asteroids_counter--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);

            FindObjectOfType<SpawnManager>().asteroids_counter--;
            Hud.hud.point += 100;
        }
    }

}
