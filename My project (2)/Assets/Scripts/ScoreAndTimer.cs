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
    public TMP_InputField PlayerID;
    public int ID;
    public GameObject NameScore;
    //string MemberID= "123456";

    float Score;

    bool GameEnd;

    float Timer = 60.0f;
    public TMP_Text TimeLeft;

    private void Start()
    {
        Cursor.visible = false;
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
        if(Input.GetKey(KeyCode.Escape))
        {
            NameScore.SetActive(true);
        }
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
            NameScore.SetActive(true);
            Cursor.visible = true;
            if (GameEnd)
            {

                //SubmitScore();
            }
        }
    }

    public void SubmitScore()
    {
        //string playerID = PlayerPrefs.GetString("PlayerID");
        float ScoreSend = Player.size * 1000;
        LootLockerSDKManager.SubmitScore(PlayerID.text, int.Parse(ScoreSend.ToString("####")), ID, (response) =>
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
