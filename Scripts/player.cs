using UnityEngine;
using System.Collections;

//Funnção equivalente ao serialize. Importa todas as variaveis e classes criadas. Necessario colocar para cada classe.
[System.Serializable]
// Classe para definir o limite da tela 
public class Limite {
	public float xMin, xMax, yMin, yMax;
}

[System.Serializable]
public class Movimento {
	public float movimentoY, movimentoX, tilt;
}

public class player : MonoBehaviour {

	public int life = 100;

	public Movimento movimento;
	public Limite limite;

	public Transform posicaoPlayer;
	public Rigidbody2D rigidBodyPlayer;
	public float speedVertical;
	public float speedHorizontal;

	public float turbo = 1;


	public GameObject[] shot;
	public Transform spawnShot;

	public int indexShot = 1;
	public float fireRate;  //.. Armazena intervalo entre um tiro e outro

	private float nextFire; //..Armazena tempo para execucao do proximo tiro

	public Joystick stick;
//	public Joystick stick2;

	public float eixoX;

	public GameObject pontuacao;




	// Use this for initialization
	void Start () {
		
	}

	void Update () {

		PlayerPrefs.SetInt ("pontos", 0);

		eixoX = stick.JoystickPosition.x;

		if(eixoX != 0) {			
			atirar ();
		}

		Vector2 stickPosition = stick.JoystickPosition;
		movimento.movimentoX = stickPosition.x;
		movimento.movimentoY = stickPosition.y;



		// Ativando tiro
		if (Input.GetButton ("Jump") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			//Instantiate (shot[indexShot], spawnShot.position, spawnShot.rotation);

			GameObject tempShotPrefb = Instantiate (shot[indexShot]) as GameObject;
			tempShotPrefb.transform.position = spawnShot.position;
			//tempShotPrefb.transform.rotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);
		}


		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
/*
#if UNITY_EDITOR
		movimento.movimentoY = Input.GetAxis ("Vertical");
		movimento.movimentoX = Input.GetAxis ("Horizontal");

		if (Input.GetButton ("Fire1")) {
			turbo = 2;
		} else {
			turbo = 1;
		}

#endif

*/

		// Movimentação da Nav
		rigidBodyPlayer.velocity =  new Vector2 (movimento.movimentoX * speedHorizontal * turbo, movimento.movimentoY * speedVertical * turbo);

		// Limita Movimentação da nave na tela
		rigidBodyPlayer.position = new Vector3 ( Mathf.Clamp (rigidBodyPlayer.position.x, limite.xMin, limite.xMax), Mathf.Clamp (rigidBodyPlayer.position.y, limite.yMin, limite.yMax), 0.0f );

		// Movimento de Rotação quando a nave acelera e freia
		posicaoPlayer.rotation = Quaternion.Euler (0.0f, 0.0f, rigidBodyPlayer.velocity.x * -movimento.tilt);


		// Trocando de Arma
		if (Input.GetKey (KeyCode.Alpha1)) {
			indexShot = 0;	
		}

		if (Input.GetKey (KeyCode.Alpha2)) {
			indexShot = 1;
		}



	}

	void OnTriggerEnter2D (Collider2D col) {	
		Debug.Log (col);	
		if (col.tag == "enemy") {			
			Destroy (this.gameObject);
			Application.LoadLevel ("gameOver");
		}
	}


	public void ApplyDamagePlayer(int damage) {		
		life -= damage;
		if (life <= 0) {
			Destroy (this.gameObject);

			Application.LoadLevel ("gameOver");

		}
	}

	public void atirar() {
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			//Instantiate (shot[indexShot], spawnShot.position, spawnShot.rotation);

			GameObject tempShotPrefb = Instantiate (shot[indexShot]) as GameObject;
			tempShotPrefb.transform.position = spawnShot.position;
			//tempShotPrefb.transform.rotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);
		}
	}


}
