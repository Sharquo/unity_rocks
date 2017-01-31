using System.Collections;
using UnityEngine;

public class shipController : MonoBehaviour
{

    public float rotationSpeed = 100.0f;
    public float thrustForce = 3f;

    public AudioClip lose;
    public AudioClip laser1;

    public GameObject laser;

    public Transform shotSpawn;

    private GameController gameController;

	void Start ()
    {
        // Get a reference to the game controller object and the script
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        gameController = gameControllerObject.GetComponent<GameController>();
	}
	
	void FixedUpdate ()
    {
        // Rotate the ship if necessary
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);

        // Thrust the ship if neccessary
        GetComponent<Rigidbody2D>().AddForce(transform.up * thrustForce * Input.GetAxis("Vertical"));

        // Has a laser been fired?
        if (Input.GetKeyDown ("space"))
        {
            ShootLaser();
        }
	}

    private void OnTriggerEnter2D(Collider2D c)
    {
        // Anything except a laser bolt is an asteroid
        if (c.gameObject.tag != "Laser")
        {
            AudioSource.PlayClipAtPoint(lose, Camera.main.transform.position);

            // Move the ship to the centre of the screen
            transform.position = new Vector3(0, 0, 0);

            // Remove all velocity from the ship
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);

            gameController.DecrementLives();
        }
    }

    void ShootLaser()
    {
        // Spawn a laser bolt
        Instantiate(laser, shotSpawn.position, shotSpawn.rotation);

        // Play pew pew noise
        AudioSource.PlayClipAtPoint(laser1, Camera.main.transform.position);
    }
}
