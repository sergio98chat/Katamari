using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{

    public AudioSource _audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _audioSource.volume = PlayerPrefs.GetFloat("musicVol");
    }
    public void PlayMusic()
    {
        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }
        else
        {
            _audioSource.Play();

        }
    }

    public void SaveVol()
    {
        PlayerPrefs.SetFloat("musicVol", _audioSource.volume);
    }
}
