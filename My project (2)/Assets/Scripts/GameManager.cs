using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class GameManager : MonoBehaviour
{ 
    public TMP_InputField MemberID;
    public int ID;
    int MaxScores = 10;
    public TMP_Text[] Enteries;
     
    void Start()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");

                return;
            }

            Debug.Log("successfully started LootLocker session");
        });
    }
    public void SaveName()
    {
        LootLockerSDKManager.SetPlayerName(MemberID.text, (response) =>
        {

        });
    }
    public void ShowScores()
    {
        LootLockerSDKManager.GetScoreList(ID, MaxScores, (response) =>
        {
            if (response.success) { 

                LootLockerLeaderboardMember[] scores = response.items;
                for (int i = 0; i < scores.Length; i++)
                {
                    Enteries[i].text = (scores[i].rank + ".     " + scores[i].score);
                }

                if(scores.Length < MaxScores)
                {
                    for(int i = scores.Length; i < MaxScores; i++)
                    {
                        Enteries[i].text = (i + 1).ToString() + ".       " + "none";
                    }
                }
            }

        });
    }

    public void SubmitScore()
    {
        float playerscore = PlayerPrefs.GetFloat("score");
        LootLockerSDKManager.SubmitScore(MemberID.text, int.Parse(playerscore.ToString()), ID, (response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");

                return;
            }

            Debug.Log("successfully started LootLocker session");
        });
    }
}
