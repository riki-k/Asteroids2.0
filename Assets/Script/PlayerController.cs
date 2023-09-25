using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectile;
    private GameObject gun;
    public Animator myAnim;

    private Rigidbody2D playerRb2;
    private SpriteRenderer playersprite;
    Vector3 borders;
    private float rotation_dir;
    private float rotation_speed;
    private float half_x_size_camera;
    private float half_y_size_camera;
    private float x_left_borders;
    private float y_bottom_borders;

    // Start is called before the first frame update
    void Start()
    {
        playerRb2 = GetComponent<Rigidbody2D>();
        playersprite = GetComponent<SpriteRenderer>();
        myAnim = GetComponent<Animator>();
        rotation_dir = 0;
        rotation_speed = 5;

        //adjust the scale and the rotation speed based on texture
        //if the texture is spaceship.png
        //0.2-->x 0.15-->y
        if(playersprite.sprite.texture.name == "Spaceship")
        {
            transform.localScale = new Vector3(0.2f, 0.15f, 1f);
            rotation_speed = 0.5f;
        }

        //if the texture is player rectangle least the transform scale


        borders = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        half_x_size_camera = (Main.main.gameCamera.transform.position.x - borders.x);
        half_y_size_camera = (Main.main.gameCamera.transform.position.y - borders.y);
        x_left_borders = Main.main.gameCamera.transform.position.x + half_x_size_camera;
        y_bottom_borders = Main.main.gameCamera.transform.position.y + half_y_size_camera;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.zero);
        //move forward
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerRb2.AddForce(transform.right, ForceMode2D.Impulse);
        }

        //right rotation
        if (Input.GetKey(KeyCode.A))
        {
            rotation_dir = 0.1f * rotation_speed * Time.deltaTime;
            playerRb2.AddTorque(rotation_dir, ForceMode2D.Impulse);
        }

        //left rotation
        if (Input.GetKey(KeyCode.D))
        {
            rotation_dir = -0.1f * rotation_speed * Time.deltaTime;
            playerRb2.AddTorque(rotation_dir, ForceMode2D.Impulse);
        }

        //shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gun = this.gameObject.transform.GetChild(0).gameObject;
            Instantiate(projectile, gun.transform.position, gun.transform.rotation);
        }

        //stabilize the ship
        if (Input.GetKeyDown(KeyCode.P))
        {
            playerRb2.velocity = Vector2.zero;
            playerRb2.angularVelocity = 0;
        }

        //teleport the ship
        if (Input.GetKey(KeyCode.T))
        {
            teleport();
        }

        toroidal_space();
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

    void teleport()
    {
        transform.position = new Vector3(Random.Range(10, Screen.width), Random.Range(10, Screen.height - 10), -1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroids"))
        {
            //remove life
            myAnim.Play("Destroy");
            Destroy(gameObject, 1);
            
        }
    }

}
