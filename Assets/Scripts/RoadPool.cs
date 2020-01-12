using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPool : MonoBehaviour {
    public RepeatingBackground background;
    public int roadPoolSize = 5;
    public static GameObject[] roads;
    private double[] roadPositions;
    private int currentRoadPosition;

    public GameObject roadPrefab;
    public float spawnRate = 1f;

    private Vector2 objectPosition = new Vector2(-15f, 0);
    private float timeSinceLastSpawned;
    private int currentRoad = 0;


    // Use this for initialization
    void Start()
    {
        currentRoadPosition = 0;
        double start = background.start;
        roadPositions = new double[] {start + 1.16, start + 6.21, start + 11.53, start + 16.67};
        roads = new GameObject[roadPoolSize];
        for (int i = 0; i < roadPoolSize; i++)
        {
            roads[i] = (GameObject)Instantiate(roadPrefab, objectPosition, Quaternion.identity);
        }

    }
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSpawned += Time.deltaTime;
        double start = background.start;
        roadPositions = new double[] { start + 1.16, start + 6.21, start + 11.53, start + 16.67 };

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) {
            timeSinceLastSpawned = 0;
            roads[currentRoad].transform.position = new Vector2((float)roadPositions[currentRoadPosition], 0);
            currentRoad++;
            currentRoadPosition++;
            if (currentRoad >= roadPoolSize)
            {
                currentRoad = 0;
            }
            if (currentRoadPosition >= roadPositions.Length) {
                currentRoadPosition = 0;
            }
        }
		
	}
}
