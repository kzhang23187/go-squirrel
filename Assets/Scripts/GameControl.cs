using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public static GameControl instance;
    public static List<string> leaders = new List<string>();
    public static List<int> leaderScores = new List<int>();

    public GameObject gameOverText;
    public InputField nameInputField;
    public Text nameInput;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    public Text scoreText;
    public bool addedToLeaderBoard = false;

    private int score = 0;
    // Use this for initialization
    private void Awake()
    {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }
    }
    void Start () {
        addedToLeaderBoard = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SquirrelScored() {
        if (gameOver) {
            return;
        }
        score++;
        scoreText.text = "Score: " + score.ToString();


    }
    public void SquirrelDied() {
        gameOverText.SetActive(true);
        gameOver = true;

         }
    public void UpdateLeader() {
        if (!addedToLeaderBoard) {
            bool inserted = false;
            for (int i = 0; i < leaderScores.Count; i++)
            {
                if (score > leaderScores[i])
                {
                    leaderScores.Insert(i, score);
                    leaders.Insert(i, nameInput.text);
                    inserted = true;
                    break;
                }
            }
            if (leaderScores.Capacity < 10 && !inserted)
            {
                leaderScores.Add(score);
                leaders.Add(nameInput.text);
            }
            addedToLeaderBoard = true;
            nameInputField.text = "";
        }


    }
    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoToLeaderboard() {
        SceneManager.LoadScene("Leaderboard");
    }



   
}
