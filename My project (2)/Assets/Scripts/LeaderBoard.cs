using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderBoard : MonoBehaviour
{
    public TMP_Text n1, n2, n3, n4, n5, n6, n7, n8, n9, n10;//name for each of the places
    public TMP_Text s1, s2, s3, s4, s5, s6, s7, s8, s9, s10;//score for each place

    void Start()
    {

        s1.text = PlayerPrefs.GetFloat("highscore1").ToString("#.###");
        s2.text = PlayerPrefs.GetFloat("highscore2").ToString("#.###");
        s3.text = PlayerPrefs.GetFloat("highscore3").ToString("#.###");
        s4.text = PlayerPrefs.GetFloat("highscore4").ToString("#.###");
        s5.text = PlayerPrefs.GetFloat("highscore5").ToString("#.###");
        s6.text = PlayerPrefs.GetFloat("highscore6").ToString("#.###");
        s7.text = PlayerPrefs.GetFloat("highscore7").ToString("#.###");
        s8.text = PlayerPrefs.GetFloat("highscore8").ToString("#.###");
        s9.text = PlayerPrefs.GetFloat("highscore9").ToString("#.###");
        s10.text = PlayerPrefs.GetFloat("highscore10").ToString("#.###");
    }


}
