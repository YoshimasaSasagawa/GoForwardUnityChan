using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {
	//compornent for animation
	Animator animator;

	//compornent for move UnityChan
	Rigidbody2D rigid2D;

	//ground position
	private float groundLevel = -3.0f;

	//reduct jump velocity
	private float dump = 0.8f;

	float jumpVelocity = 20;

	private float deadLine = -9;

	// Use this for initialization
	void Start () {
		this.animator = GetComponent<Animator>();
		this.rigid2D = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		//adjust Animator paramater in order to play running animation
		this.animator.SetFloat("Horizontal", 1);

		//check if it's ground
		bool isGround = (transform.position.y > this.groundLevel) ? false : true;
		this.animator.SetBool("isGround", isGround);

		//ジャンプ状態でボリューム0
		GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

		//when clicked
		if (Input.GetMouseButtonDown(0) && isGround) {
			//get upper force
			this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
		}

		//when not clicked
		if (Input.GetMouseButton(0) == false) {
			if (this.rigid2D.velocity.y > 0) {
				this.rigid2D.velocity *= this.dump;
			}
		}

		//デッドラインを超えたらゲームオーバーにする
		if (transform.position.x < this.deadLine)
        {
			GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
			Destroy(gameObject);
        }
	}
}
