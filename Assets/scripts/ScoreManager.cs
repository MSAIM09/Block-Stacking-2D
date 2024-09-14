using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    public Text HighscoreText;

    int score = 0, highscore=0;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        highscore = PlayerPrefs.GetInt("HighScore", 0);
        scoreText.text =   "Score:" + score.ToString();
        HighscoreText.text = "HighScore: " + highscore.ToString();

    }
    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore()
    {
        score += 2;
        scoreText.text = "Score:" + score.ToString();

        if (highscore < score)
            PlayerPrefs.SetInt("HighScore", score);
    }
}
