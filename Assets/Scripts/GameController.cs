using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject asteroid;

    private int score;
    private int hiscore;
    private int asteroidsRemaining;
    private int lives;
    private int wave;
    private int increaseEachWave = 4;

    public Text scoreText;
    public Text livesText;
    public Text waveText;
    public Text hiscoreText;

	void Start ()
    {
        hiscore = PlayerPrefs.GetInt("hiscore", 0);
        BeginGame();
	}
	

	void Update ()
    {
        // Quit if the player presses escape.
        if (Input.GetKey("escape"))
            Application.Quit();
	}

    void BeginGame ()
    {
        score = 0;
        lives = 3;
        wave = 1;

        // Prepare the HUD
        scoreText.text = "SCORE: " + score;
        hiscoreText.text = "HISCORE: " + hiscore;
        livesText.text = "LIVES: " + lives;
        waveText.text = "WAVE: " + wave;

        SpawnAsteroids();
    }

    void SpawnAsteroids()
    {
        DestroyExistingAsteroids();

        // Decide how many asteroids to spawn.
        // If there are any asteroids left over from the previous game, subtract time.
        asteroidsRemaining = (wave * increaseEachWave);

        for (int i = 0; i < asteroidsRemaining; i++)
        {
            // Spawn an asteroid
            Instantiate(asteroid, new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(-6.0f, 6.0f), 0), Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));
        }

        waveText.text = "WAVE: " + wave;
    }

    public void IncrementScore()
    {
        score++;

        scoreText.text = "SCORE: " + score;

        if (score > hiscore)
        {
            hiscore = score;
            hiscoreText.text = "HISCORE: " + hiscore;
        }

        // Has the player destroyed all the asteroids?
        if (asteroidsRemaining < 1)
        {
            // Start the next wave!
            wave++;
            SpawnAsteroids();
        }
    }

    public void DecrementLives()
    {
        lives--;
        livesText.text = "LIVES: " + lives;

        // Has the player run out of lives?!
        if (lives < 1)
        {
            // RESTART THE FUCKING GAME!
            BeginGame();
        }
    }

    public void DecrementAsteroids()
    {
        asteroidsRemaining--;
    }

    public void SplitAsteroid()
    {
        // Two extra asteroids
        // - big one
        // +3 little ones
        // = 2
        asteroidsRemaining += 2;
    }

    void DestroyExistingAsteroids()
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("roidBig");

        foreach(GameObject current in asteroids)
        {
            GameObject.Destroy(current);
        }

        GameObject[] asteroids2 = GameObject.FindGameObjectsWithTag("roidSmall");

        foreach (GameObject current in asteroids2)
        {
            GameObject.Destroy(current);
        }
    }
}
