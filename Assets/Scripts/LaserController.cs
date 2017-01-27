using System.Collections;
using UnityEngine;

public class LaserController : MonoBehaviour
{

    public float boltLifetime = 1.0f;
    public float pewForce = 400.0f;

	void Start ()
    {
        // Set the laser to destroy itself after ttd.
        Destroy(gameObject, boltLifetime);

        // Push the laser in the direction that it is facing.
        GetComponent<Rigidbody2D>().AddForce(transform.up * pewForce);
	}
	
}
