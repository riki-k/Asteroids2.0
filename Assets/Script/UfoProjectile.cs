using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoProjectile : MonoBehaviour
{
    public GameObject target;

    float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 look = transform.InverseTransformPoint(target.transform.position);
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;

        transform.Rotate(0, 0, angle);

        transform.Translate(Vector3.right * Time.deltaTime * speed);

        destroyOnPlayerDead();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
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
}
