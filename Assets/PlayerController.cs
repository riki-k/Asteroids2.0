using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectile;
    private GameObject gun;

    private Rigidbody2D playerRb2;
    private float rotation_dir;
    private float rotation_speed;

    // Start is called before the first frame update
    void Start()
    {
        //velocity = Vector2.zero;
        playerRb2 = GetComponent<Rigidbody2D>();
        rotation_dir = 0;
        rotation_speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.zero);

        if (Input.GetKeyDown(KeyCode.W))
        {
            playerRb2.AddForce(transform.right, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rotation_dir = 0.2f * rotation_speed * Time.deltaTime;
            playerRb2.AddTorque(rotation_dir, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rotation_dir = -0.2f * rotation_speed * Time.deltaTime;
            playerRb2.AddTorque(rotation_dir, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gun = this.gameObject.transform.GetChild(0).gameObject;
            Instantiate(projectile, gun.transform.position, gun.transform.rotation);
        }

        //maybe add a command to stabilize the ship

        if (Input.GetKey(KeyCode.T))
        {
            teleport();
        }

        toroidal_space();
    }

    void toroidal_space()
    {
        Vector3 borders = Camera.main.ScreenToWorldPoint(new Vector3( Screen.width, Screen.height, 0));

        if (transform.position.x < -borders.x)
        {
            transform.position = new Vector3(borders.x, transform.position.y, transform.position.z);
        }

        if (transform.position.x > borders.x)
        {
            transform.position = new Vector3(-borders.x, transform.position.y, transform.position.z);
        }

        if (transform.position.y > borders.y)
        {
            transform.position = new Vector3(transform.position.x, -borders.y, transform.position.z);
        }

        if (transform.position.y < -borders.y)
        {
            transform.position = new Vector3(transform.position.x, borders.y, transform.position.z);
        }
    }

    void teleport()
    {
        transform.position = new Vector3(Random.Range(10, Screen.width), Random.Range(10, Screen.height - 10), -1);
        Debug.Log(Random.Range(10, Screen.width));
    }

}
