using System.Collections;
using UnityEngine;

public class roidController : MonoBehaviour
{

    public AudioClip destroy;
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
	

}
