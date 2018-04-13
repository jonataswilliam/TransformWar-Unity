using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {


	public Rigidbody2D rigidbodyShooter;
	public float speed;

	private player player;

	public int enemyShoot_1 = 10;
	public float playerShot = 10;

	// Use this for initialization
	void Start () {		
		player = FindObjectOfType (typeof(player)) as player;

		if (rigidbodyShooter.tag == "enemy_shoot") {
			rigidbodyShooter.AddForce (new Vector2( -500, 0));
		} else {
			atirar();	
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (this.gameObject.tag == "armas") {			
			if (col.tag == "enemy") {				
				col.gameObject.SendMessage("ApplyDamage", playerShot, SendMessageOptions.DontRequireReceiver);
				Destroy (this.gameObject);
			}
		}

		if (this.gameObject.tag == "enemy_shoot") {			
			if (col.tag == "Player") {			
				player.ApplyDamagePlayer (enemyShoot_1);
				Destroy (this.gameObject);
			}
		}

	/*	if (this.gameObject.tag == "armas") {		
			if (col.tag == "enemy_shoot") {
				Destroy (this.gameObject);
			}

		} else {
			if (col.tag == "Player") {
				Destroy (this.gameObject);
			}
		}*/
	}

	public void atirar() {
		rigidbodyShooter.velocity = transform.right * speed;
	}
}

