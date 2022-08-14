using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public GameObject Leaderboard, mainButtons,Settings;
    public void LoadFirstSene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
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
    public void SettingShow()
    {
        mainButtons.SetActive(false);
        Settings.SetActive(true);
    }
    public void SettingsHide()
    {
        Settings.SetActive(false);
        mainButtons.SetActive(true);
    }

    public void leave()
    {
        Application.Quit();
    }
}
