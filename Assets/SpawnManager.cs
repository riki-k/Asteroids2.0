using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject asteroids;
    public GameObject ufo;
    public GameObject spaceship;

    private int asteroids_counter = 0;
    private float startDelay = 1.0f;
    private float spawnInterval = 2.0f;

    Vector3 borders;
    Vector3 lookDirection;

    // Start is called before the first frame update
    void Start()
    {
        borders = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        InvokeRepeating("spawnAsteroids", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //manage the spawn position and direction of the asteroids
    void spawnAsteroids()
    {
        if (asteroids_counter < 12)
        {
            Vector3 spawnPosition = new Vector3(0, 0, 0);

            float externalXMinusBorder = Random.Range(-5 - borders.x, -borders.x);
            float externalXBorder = Random.Range(borders.x, borders.x + 5);

            float externalYMinusBorder = Random.Range(-5 - borders.y, -borders.y);
            float externalYBorder = Random.Range(borders.y, borders.y + 5);

            int spawnAxisPosition = Random.Range(0, 2);
            int spawnExtremePosition = Random.Range(0, 2);

            //spawnAxisPosition = 0 --> horizontal Axis
            if (spawnAxisPosition == 0)
            {
                if (spawnExtremePosition == 0)
                {
                    spawnPosition = new Vector3(externalXMinusBorder, Random.Range(-borders.y, borders.y), 0);
                    lookDirection = new Vector3(0, 0, Random.Range(-30, 30));
                }
                else if (spawnExtremePosition == 1)
                {
                    spawnPosition = new Vector3(externalXBorder, Random.Range(-borders.y, borders.y), 0);
                    lookDirection = new Vector3(0, 0, Random.Range(-150, -210));
                }
            }
            else if (spawnAxisPosition == 1)
            {
                if (spawnExtremePosition == 0)
                {
                    spawnPosition = new Vector3(Random.Range(-borders.x, borders.x), externalYMinusBorder, 0);
                    lookDirection = new Vector3(0, 0, Random.Range(10, 170));
                }
                else if (spawnExtremePosition == 1)
                {
                    spawnPosition = new Vector3(Random.Range(-borders.x, borders.x), externalYBorder, 0);
                    lookDirection = new Vector3(0, 0, Random.Range(-10, -170));
                }
            }

            Quaternion direction = new Quaternion(0,0,0,0);
            direction.eulerAngles = lookDirection;

            Instantiate(asteroids, spawnPosition, direction);
            asteroids_counter++;
        }
    }
}
