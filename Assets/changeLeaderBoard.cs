using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class changeLeaderBoard : MonoBehaviour
{

    public Text leaderText;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLeaderScore();

    }
    public void UpdateLeaderScore()
    {
        leaderText.text = "Leaders: \n";
        //for (int i = 0; i < GameControl.leaders.Capacity; i++) {
        //    leaderText.text += GameControl.leaders[i] + "\n";
        //}
        foreach (string leader in GameControl.leaders)
        {
            leaderText.text += leader + "\n";
        }
        scoreText.text = "Score: \n";
        //for (int i = 0; i < GameControl.leaderScores.Capacity; i++)
        //{
        //    scoreText.text += GameControl.leaderScores[i] + "\n";
        //}
        foreach (int score in GameControl.leaderScores) {
            scoreText.text += score.ToString() + "\n";
        }
    }
}
