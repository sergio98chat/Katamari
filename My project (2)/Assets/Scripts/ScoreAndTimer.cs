using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreAndTimer : MonoBehaviour
{
    public BallController Player;
    public TMP_Text Size;
    public TMP_Text Highscore;

    float HighScore;

    bool GameEnd;

    float Timer = 30.0f;
    public TMP_Text TimeLeft;

    private void Start()
    {
        HighScore = PlayerPrefs.GetFloat("highscore");
        Highscore.text = HighScore.ToString("#.###");
    }

    void Update()
    {
        Size.text = "Size: " + Player.size.ToString("#.###");

        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        double b = System.Math.Round(Timer, 2);
        TimeLeft.text = "TimeLeft:" + b.ToString();
        if (Timer < 0 && !GameEnd)
        {
            SubmitScore();
            GameEnd = true;
        }
    }

    public void SubmitScore()
    {
        if(Player.size >= HighScore)
        {
            HighScore = Player.size;

            PlayerPrefs.SetFloat("highscore", HighScore);
            Highscore.text = HighScore.ToString("#.###");
        }
    }
    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("highscore");
        HighScore = PlayerPrefs.GetFloat("highscore");
        Highscore.text = HighScore.ToString("#.###");
    }
}
