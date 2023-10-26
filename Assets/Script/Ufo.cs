using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo : MonoBehaviour
{
    public GameObject ufoProjectile;
    [SerializeField] AudioClip destruction;
    private AudioSource effects;

    private float startShoot = 0.5f;
    private float delayShoot = 20f;

    bool outOfBorders;
    //direction 0 = right, 1 = left
    bool direction;
    float speed = 7f;

    // Start is called before the first frame update
    void Start()
    {
        outOfBorders = false;
        if (transform.position.x > -20)
            direction = false;
        else
            direction = true;

        effects = GetComponent<AudioSource>();

        InvokeRepeating("shoot", startShoot, delayShoot);

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
        {
            if (transform.childCount == 0)
                Destroy(gameObject);
            outOfBorders = true;
        }

    }

    void shoot()
    {
        if (!outOfBorders)
            Instantiate(ufoProjectile, this.transform);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            Main.main.playerPoint += 200;
        }

        effects.clip = destruction;
        effects.Play();
    }
}
