using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class enemies_comportament : MonoBehaviour {
	public Transform enemyGameObj;
	public Rigidbody2D	rigidbodyEnemy;
	public GameObject[] enemyShoot;
	public Transform	spawnShot;

	private player player;




	public int indexShot;

	public float fireRate;
	public float nextFire;
	private float speed;
	public float movimentoX;
	public float movimentoY;
	private bool definido;
	public int enemylife = 30;

	public int teste;

	// Use this for initialization
	void Start () {
		indexShot = 0;
		player = FindObjectOfType (typeof(player)) as player;


	}

	void Update () {
		if (Time.time > nextFire) {
			if (!definido) {
				DefineDirecao ();
			}
			nextFire = Time.time + fireRate;
			GameObject tempShotPrefab = Instantiate (enemyShoot [indexShot]) as GameObject;
			tempShotPrefab.transform.position = spawnShot.position;
			
		}		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		

	}

	void DefineDirecao() {
		speed = Random.Range (0, 2.5f);

		movimentoX = Random.Range (-1, 0);

		if(enemyGameObj.position.y == 5) {
			movimentoY = Random.Range(-1, -3);
		} else if (enemyGameObj.transform.position.y == -5 ) {
			movimentoY = Random.Range(1, 3);
		} else {
			movimentoY = Random.Range(-2, 2);
		}

		rigidbodyEnemy.velocity = new Vector2 (movimentoX * speed, movimentoY * speed);
		definido = true;

	}

	void ApplyDamage(int damage) {
		enemylife -= damage;
		if (enemylife <= 0) {
			Destroy (this.gameObject);
			string pontAnt = player.pontuacao.GetComponent<Text> ().text;

			int pont = int.Parse(pontAnt)+1;

			player.pontuacao.GetComponent<Text>().text = pont.ToString ();

		}

	}
}

