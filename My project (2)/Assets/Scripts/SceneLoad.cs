using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public GameObject Leaderboard, mainButtons;
    public void LoadFirstSene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void leaderBoardShow()
    {
        mainButtons.SetActive(false);
        Leaderboard.SetActive(true);
    }
    public void leaderBoardHide()
    {
        mainButtons.SetActive(true);
        Leaderboard.SetActive(false);
    }
    }
