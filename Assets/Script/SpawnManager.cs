using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject asteroids;
    public GameObject ufo;
    public GameObject spaceship;

    public int asteroids_counter = 0;
    private float startDelay = 1.0f;
    private float spawnInterval = 2.0f;
    private float half_x_size_camera;
    private float half_y_size_camera;
    private float x_left_borders;
    private float y_bottom_borders;

    Vector3 borders;
    Vector3 lookDirection;

    // Start is called before the first frame update
    void Start()
    {
        borders = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        half_x_size_camera = (Main.main.gameCamera.transform.position.x - borders.x);
        half_y_size_camera = (Main.main.gameCamera.transform.position.y - borders.y);
        x_left_borders = Main.main.gameCamera.transform.position.x + half_x_size_camera;
        y_bottom_borders = Main.main.gameCamera.transform.position.y + half_y_size_camera;

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

            float left_x_pos= Random.Range(x_left_borders -5, x_left_borders);
            float right_x_pos = Random.Range(borders.x, borders.x + 5);

            float bottom_y_pos = Random.Range(y_bottom_borders - 5, y_bottom_borders);
            float top_y_pos = Random.Range(borders.y, borders.y + 5);

            int spawnAxisPosition = Random.Range(0, 2);
            int spawnExtremePosition = Random.Range(0, 2);

            spawnPosition = new Vector3(left_x_pos, Random.Range(y_bottom_borders, borders.y), 0);
            
            //spawnAxisPosition = 0 --> horizontal Axis
            if (spawnAxisPosition == 0)
            {
                if (spawnExtremePosition == 0)
                {
                    spawnPosition = new Vector3(left_x_pos, Random.Range(y_bottom_borders, borders.y), 0);
                    lookDirection = new Vector3(0, 0, Random.Range(-30, 30));
                }
                else if (spawnExtremePosition == 1)
                {
                    spawnPosition = new Vector3(right_x_pos, Random.Range(y_bottom_borders, borders.y), 0);
                    lookDirection = new Vector3(0, 0, Random.Range(-150, -210));
                }
            }
            
            else if (spawnAxisPosition == 1)
            {
                if (spawnExtremePosition == 0)
                {
                    spawnPosition = new Vector3(Random.Range(left_x_pos, borders.x), bottom_y_pos, 0);
                    lookDirection = new Vector3(0, 0, Random.Range(10, 170));
                }
                else if (spawnExtremePosition == 1)
                {
                    spawnPosition = new Vector3(Random.Range(left_x_pos, borders.x), top_y_pos, 0);
                    lookDirection = new Vector3(0, 0, Random.Range(-10, -170));
                }
            }

            Quaternion direction = new Quaternion(0,0,0,0);
            direction.eulerAngles = lookDirection;

            //Instantiate(asteroids, spawnPosition, direction);
            Instantiate(asteroids, spawnPosition, direction, this.transform);
            asteroids_counter++;
        }
    }
}
