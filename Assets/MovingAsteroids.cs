using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAsteroids : MonoBehaviour
{
    private float speed;
    public int asteroids_counter;
    private float half_x_size_camera;
    private float half_y_size_camera;
    private float x_left_borders;
    private float y_bottom_borders;
    private bool destroy_anim;

    private SpriteRenderer playersprite;
    private Animation destroyAnimation;

    Vector3 borders;

    // Start is called before the first frame update
    void Start()
    {
        borders = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        half_x_size_camera = (Main.main.gameCamera.transform.position.x - borders.x);
        half_y_size_camera = (Main.main.gameCamera.transform.position.y - borders.y);
        x_left_borders = Main.main.gameCamera.transform.position.x + half_x_size_camera;
        y_bottom_borders = Main.main.gameCamera.transform.position.y + half_y_size_camera;
        playersprite = GetComponent<SpriteRenderer>();
        destroyAnimation = GetComponent<Animation>();
        speed = Random.Range(5, 10);
        destroy_anim = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        toroidal_space();
        //destroyOnEndAnimation();
    }

    void toroidal_space()
    {
        if (transform.position.x + (playersprite.size.x / 2) < x_left_borders)
        {
            transform.position = new Vector3(borders.x + (playersprite.size.x / 2), transform.position.y, transform.position.z);
        }

        if (transform.position.x - (playersprite.size.x / 2) > borders.x)
        {
            transform.position = new Vector3(x_left_borders - (playersprite.size.x / 2), transform.position.y, transform.position.z);
        }

        if (transform.position.y - (playersprite.size.x / 2) > borders.y)
        {
            transform.position = new Vector3(transform.position.x, y_bottom_borders - (playersprite.size.x / 2), transform.position.z);
        }

        if (transform.position.y + (playersprite.size.x / 2) < y_bottom_borders)
        {
            transform.position = new Vector3(transform.position.x, borders.y + (playersprite.size.x / 2), transform.position.z);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            //destroy_anim = true;
            destroyAnimation.Play();
            FindObjectOfType<SpawnManager>().asteroids_counter--;
            Hud.hud.point += 100;
        }

        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }

    private void destroyOnEndAnimation()
    {
        if (destroy_anim)
        {
            destroyAnimation.Play();
            if (!destroyAnimation.isPlaying)
            {
                Destroy(gameObject);
                destroy_anim = false;
            }
        }
    }

}
