using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Player player;
    private Spawner spawner;

    public Text title;
    public Text scoreText;
    public Text gameOver;
    public GameObject playButton;
    public int score { get; private set; }

    public void Start()
    {
        gameOver.gameObject.SetActive(false);
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;

        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();

        Pause();
    }

    public void Play()
    {
    	SoundManager.PlaySound("gamestart");

        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.gameObject.SetActive(false);
        title.gameObject.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;
        player.Reset();        

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }

    public void GameOver()
    {
        playButton.SetActive(true);
        gameOver.gameObject.SetActive(true);
        title.gameObject.SetActive(true);
   	    SoundManager.PlaySound("gameover");
        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}