using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using LootLocker.Requests;

public class ScoreAndTimer : MonoBehaviour
{
    public BallController Player;
    public TMP_Text Size;
    public TMP_Text Highscore;

    public int ID;

    //string MemberID= "123456";

    float Score;

    bool GameEnd;

    float Timer = 30.0f;
    public TMP_Text TimeLeft;

    private void Start()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");

                return;
            }

            Debug.Log("successfully started LootLocker session");
            PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
        });
        //Score = PlayerPrefs.GetFloat("score");
        //Highscore.text = Score.ToString("#.###");
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
            GameEnd = true;
            if (GameEnd)
            {
            SubmitScore();

            }
        }
    }

    void SubmitScore()
    {
        string playerID = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.SubmitScore(playerID, int.Parse(Player.size.ToString("#.###")), ID, (response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");

                return;
            }

            Debug.Log("successfully Submited");
        });
    }
}
