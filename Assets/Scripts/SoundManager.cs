using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static AudioClip potionSound;
	public static AudioClip jump00Sound;
	public static AudioClip jump01Sound;
	public static AudioClip jump02Sound;

	public static AudioClip gamestartSound;
	public static AudioClip gameoverSound;
	public static bool musicON = true;

	static AudioSource AudioSource;
	// Use this for initialization
	void Start () {	

		potionSound = Resources.Load<AudioClip>("potion");
		jump00Sound = Resources.Load<AudioClip>("jump00");
		jump01Sound = Resources.Load<AudioClip>("jump01");
		jump02Sound = Resources.Load<AudioClip>("jump02");


		gamestartSound = Resources.Load<AudioClip>("gamestart");
		gameoverSound = Resources.Load<AudioClip>("gameover");

		AudioSource = GetComponent<AudioSource>();
	}
	
	public static void PlaySound (string clip)
	{
		if (musicON)
		{
			switch (clip)
			{			
				case "gamestart":
					AudioSource.PlayOneShot(gamestartSound);
					break;	

				case "gameover":
					AudioSource.PlayOneShot(gameoverSound);
					break;

				case "potion":
					AudioSource.PlayOneShot(potionSound);
					break;
				case "jump00":
					AudioSource.PlayOneShot(jump00Sound);
					break;
				case "jump01":
					AudioSource.PlayOneShot(jump01Sound);
					break;
				case "jump02":
					AudioSource.PlayOneShot(jump02Sound);
					break;
			}
		}			
	}	
	
	public static void PlayMusic()
	{
		AudioSource.Play();
	}

	public static void PauseMusic()
	{
		AudioSource.Pause();
	}
}
