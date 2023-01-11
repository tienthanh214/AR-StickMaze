using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static Dictionary<string, AudioClip> sounds;
	static AudioSource audioSource;

	private void Awake()
	{
		sounds = new Dictionary<string, AudioClip>();

		sounds["collectItem"] = Resources.Load<AudioClip>("Audio/Sounds/collectItem");
		sounds["jump"] = Resources.Load<AudioClip>("Audio/Sounds/jump");
        sounds["die"] = Resources.Load<AudioClip>("Audio/Sounds/die");

		sounds["button"] = Resources.Load<AudioClip>("Audio/Sounds/button");
		sounds["throwTrash"] = Resources.Load<AudioClip>("Audio/Sounds/throwTrash");
		sounds["switch"] = Resources.Load<AudioClip>("Audio/Sounds/switch");

		sounds["win"] = Resources.Load<AudioClip>("Audio/Sounds/win");
		sounds["lose"] = Resources.Load<AudioClip>("Audio/Sounds/lose");

        sounds["gameStart"] = Resources.Load<AudioClip>("Audio/Sounds/gameStart");
        sounds["click"] = Resources.Load<AudioClip>("Audio/Sounds/click");
        sounds["mapDetected"] = Resources.Load<AudioClip>("Audio/Sounds/mapDetected");


        audioSource = GetComponent<AudioSource>();
	}
	public static void PlaySound(string clip)
	{
		Debug.Log(clip);
		if (sounds.ContainsKey(clip))
		{
            audioSource.PlayOneShot(sounds[clip]);
        }
			
	}

	public static void PlayButtonSound()
	{
		PlaySound("click");
	}

    public static void PlayStartSound()
    {
        PlaySound("gameStart");
    }
}
