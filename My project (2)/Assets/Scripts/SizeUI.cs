using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SizeUI : MonoBehaviour
{
    public BallController Player;
    public TMP_Text Size;

    void Update()
    {
        Size.text = "Size: " + Player.size.ToString("#.###");
    }
}
