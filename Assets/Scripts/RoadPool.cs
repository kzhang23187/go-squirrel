using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPool : MonoBehaviour {
    public int roadPoolSize = 5;
    public static GameObject[] roads;

    public GameObject roadPrefab;
    public float spawnRate = 4f;

    private Vector2 objectPosition = new Vector2(-15f, 0);
    private float timeSinceLastSpawned;
    private int currentRoad = 0;


	// Use this for initialization
	void Start () {
        roads = new GameObject[roadPoolSize];
        for (int i = 0; i < roadPoolSize; i++)
        {
            roads[i] = (GameObject)Instantiate(roadPrefab, objectPosition, Quaternion.identity);
        }

    }
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) {
            timeSinceLastSpawned = 0;
            roads[currentRoad].transform.position = new Vector2(11f, 0);

            currentRoad++;
            if (currentRoad >= roadPoolSize)
            {
                currentRoad = 0;
            }
        }
		
	}
}
