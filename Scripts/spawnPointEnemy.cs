using UnityEngine;
using System.Collections;

public class spawnPointEnemy : MonoBehaviour {

	public Transform[] spawn;
	public GameObject[] prefabEnemyTipo1;
	private int index;

	private float nextSpawn;
	public float spawnRate;
	private bool instanciado;

	// Varivel para habilitar inimigos
	public bool habilitaEnemies = true;


	// Use this for initialization	
	void Start () {

		spawn [0].position = new Vector3 (Random.Range (1.5f, 17), 5, 0);
		spawn [1].position = new Vector3 (Random.Range (1.5f, 17), -5, 0);
//		spawn [2].position = new Vector3 (17, Random.Range(-4.0f, 4.0f), 0);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(habilitaEnemies == true) {
			if (Time.time > nextSpawn) {			
				if (!instanciado) {
					InstEnemy ();
				}
				nextSpawn = Time.time + spawnRate;
				GameObject tempEnemyPrefab = Instantiate (prefabEnemyTipo1 [0]) as GameObject;
				tempEnemyPrefab.transform.position = spawn [index].position;
				instanciado = false;
				
			}			
		}

	}

	void InstEnemy() {
		index = Random.Range (0, 2);
		instanciado = true;
	}

}
