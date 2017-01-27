using System.Collections;
using UnityEngine;

public class roidController : MonoBehaviour
{

    public AudioClip roid_explosion;
    public GameObject roidSmall;

    private GameController gameController;
    
	void Start ()
    {
        // Get a ereference to the game controller object and script.
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        gameController = gameControllerObject.GetComponent<GameController>();

        // Push the asteroid in the direction it is facing.
        GetComponent<Rigidbody2D>().AddForce(transform.up * Random.Range(-50.0f, 150f));

        // Give a randomg angular velocity.
        GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-0.0f, 90.0f);
	}

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag.Equals("Laser"))
        {
            // Destroy the laser bolt
            Destroy(c.gameObject);

            // If large asteroid, spawn new ones
            if (tag.Equals ("roidBig"))
            {
                // Spawn small asteroids
                Instantiate(roidSmall, new Vector3(transform.position.x - 0.5f, transform.position.y - 0.5f, 0), Quaternion.Euler(0, 0, 90));

                // Spawn small asteroids
                Instantiate(roidSmall, new Vector3(transform.position.x + 0.5f, transform.position.y + 0f, 0), Quaternion.Euler(0, 0, 0));

                // Spawn small asteroids
                Instantiate(roidSmall, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.5f, 0), Quaternion.Euler(0, 0, 270));

                gameController.SplitAsteroid(); // +2
            }

            else
            {
                // Just a small asteroid destroyed
                gameController.DecrementAsteroids();
            }

            // Play a sound
            AudioSource.PlayClipAtPoint(roid_explosion, Camera.main.transform.position);

            // Add to the score
            gameController.IncrementScore();

            // Destroy the current asteroid
            Destroy(gameObject);
        }
    }
}
