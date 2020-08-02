using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

	private float speed = -12;

	private float deadLine = -10;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {

		audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		//move cube
		transform.Translate(this.speed * Time.deltaTime, 0, 0);

		//delete when it disappeared off screen
		if (transform.position.x < this.deadLine) {
			Destroy(gameObject);
		}
	}


	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag != "UnityChan")
        {
            audioSource.Play();
		}
	}
}
