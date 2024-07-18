using UnityEngine;

public class PauseControl : MonoBehaviour{

    public static bool gameIsPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused =! gameIsPaused;
            PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            SoundManager.musicON =! SoundManager.musicON;
			if (SoundManager.musicON)
				SoundManager.PlayMusic();
			else SoundManager.PauseMusic();
        }
    }

    public static void PauseGame()
    {
        if (gameIsPaused)
        {
            //GameOverText.Message="  GAME PAUSED!";
            Time.timeScale = 0f;
			SoundManager.PauseMusic();
        }
        else 
        {
			//GameOverText.Message="";
            Time.timeScale = 1;
			SoundManager.PlayMusic();
        }
    }

	public static void PressPause()
	{
		gameIsPaused = true;
		PauseGame();
	}
}
