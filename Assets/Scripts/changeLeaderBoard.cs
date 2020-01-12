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
        int num_leaders = 0;
        foreach (string leader in GameControl.leaders)
        {
            if (num_leaders > 10) {
                break;
            }
            leaderText.text += leader + "\n";
            num_leaders++;
        }
        scoreText.text = "Score: \n";
        //for (int i = 0; i < GameControl.leaderScores.Capacity; i++)
        //{
        //    scoreText.text += GameControl.leaderScores[i] + "\n";
        //}
        int num_scores = 0;
        foreach (int score in GameControl.leaderScores) {
            if (num_scores > 10) {
                break;
            }
            scoreText.text += score.ToString() + "\n";
            num_scores++;
        }
    }
}
