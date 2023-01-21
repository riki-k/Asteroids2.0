using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    private float speed;
    private Rigidbody2D projRB;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        projRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("projectile position" + transform.rotation.eulerAngles);
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        destroyOutLimits();
    }

    void destroyOutLimits()
    {
        Vector3 borders = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        if (transform.position.x < -borders.x)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > borders.x)
        {
            Destroy(gameObject);
        }

        if (transform.position.y > borders.y)
        {
            Destroy(gameObject);
        }

        if (transform.position.y < -borders.y)
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
