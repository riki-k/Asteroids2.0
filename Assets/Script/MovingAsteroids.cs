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

    private SpriteRenderer playersprite;
    private CircleCollider2D colliderCircle;
    public Animator myAnim;
    private AudioSource effects;
    [SerializeField] AudioClip destruction;


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
        myAnim = GetComponent<Animator>();
        colliderCircle = GetComponent<CircleCollider2D>();
        effects = GetComponent<AudioSource>();
        speed = Random.Range(5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        toroidal_space();
        destroyOnPlayerDead();
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

    void destroyOnPlayerDead()
    {
        if (FSM.fsm.state == FSM.gamestate.dead)
        {
            myAnim.Play("Destroy");
            Destroy(gameObject, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            colliderCircle.enabled = false;
            myAnim.Play("Destroy");
            Destroy(gameObject, 1);
            FindObjectOfType<SpawnManager>().asteroids_counter--;
            Main.main.playerPoint += 100;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            myAnim.Play("Destroy");
            Destroy(gameObject, 1);
        }

        effects.clip = destruction;
        effects.Play();
    }
}
