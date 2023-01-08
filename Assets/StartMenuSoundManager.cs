using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartMenuSoundManager : MonoBehaviour
{
    public static Dictionary<string, AudioClip> sounds;
    static AudioSource audioSource;
    private void Start()
    {
        sounds = new Dictionary<string, AudioClip>();
        sounds["gameStart"] = Resources.Load<AudioClip>("Audio/Sounds/gameStart");
        sounds["click"] = Resources.Load<AudioClip>("Audio/Sounds/click");


        audioSource = GetComponent<AudioSource>();
    }

    public void PlayButtonClick()
    {
        audioSource.PlayOneShot(sounds["click"]);
    }

    public void PlayStartGame()
    {
        audioSource.PlayOneShot(sounds["gameStart"]);
    }
}
