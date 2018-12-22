using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPool : MonoBehaviour
{
    public int carPoolSize = 18;
    public GameObject carPrefab;
    public float spawnRate = 4f;

    //public static int carStart = -6;
    //public static int carEnd = 10;
    //public static float[] spawnCoordinate;

    public static float spawnYposition = 5.5f;
    private Vector2 objectPosition = new Vector2(-15f, 0);
    public static GameObject[] cars;
    private float timeSinceLastSpawned;
    private int currentCar = 0;

    // Use this for initialization
    void Start()
    {

        cars = new GameObject[carPoolSize];
        for (int i = 0; i < carPoolSize; i++)
        {
            cars[i] = (GameObject)Instantiate(carPrefab, objectPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            int randRoad = Random.Range(0, RoadPool.roads.Length);
            float roadX = RoadPool.roads[randRoad].transform.position.x;
            cars[currentCar].transform.position = new Vector2(roadX, spawnYposition);
            currentCar++;

            if (currentCar >= carPoolSize)
            {
                currentCar = 0;
            }


        }

    }

}
