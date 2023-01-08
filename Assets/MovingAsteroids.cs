using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAsteroids : MonoBehaviour
{
    private float speed;
    private bool move;

    private Rigidbody2D body2d;

    Vector3 borders;

    // Start is called before the first frame update
    void Start()
    {
        borders = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        speed = 100;

        body2d = GetComponent<Rigidbody2D>();
        //body2d.AddForce(Vector3.right * Time.deltaTime * speed, ForceMode2D.Impulse);

        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.right * Time.deltaTime * speed);
        if (move)
        {
            body2d.AddForce(new Vector3(1, transform.position.y, transform.position.z) * Time.deltaTime * speed, ForceMode2D.Impulse);
            move = false;
        }
        
        toroidalSpace();
    }

    void toroidalSpace()
    {
        if (transform.position.x < -borders.x - 5)
        {
            transform.position = new Vector3(borders.x + 2, transform.position.y, transform.position.z);
        }

        if (transform.position.x > borders.x + 5)
        {
            transform.position = new Vector3(-borders.x - 2, transform.position.y, transform.position.z);
        }

        if (transform.position.y < -borders.y - 5)
        {
            transform.position = new Vector3(transform.position.x, borders.y + 2, transform.position.z);
        }

        if (transform.position.y > borders.y + 5)
        {
            transform.position = new Vector3(transform.position.x, -borders.y - 2, transform.position.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            //spawnManager.asteroids_counter--;
        }
    }

}
