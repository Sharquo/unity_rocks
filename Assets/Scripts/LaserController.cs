using System.Collections;
using UnityEngine;

public class LaserController : MonoBehaviour
{

    public float ttd = 1.0f;
    public float pew = 400.0f;

	void Start ()
    {
        // Set the laser to destroy itself after ttd.
        Destroy(gameObject, ttd);

        // Push the laser in the direction that it is facing.
        GetComponent<Rigidbody2D>().AddForce(transform.up * pew);
	}
	
}
