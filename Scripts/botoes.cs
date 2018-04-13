using UnityEngine;
using System.Collections;

public class botoes : MonoBehaviour {

	private player player;
//	private Shooter Shooter;
	public string botao;


	
	// Use this for initialization
	void Start () {
		player = FindObjectOfType (typeof(player)) as player;
//		Shooter = FindObjectOfType (typeof(Shooter)) as Shooter;
	}
	
	public void OnTouchDown () {
		switch (botao) {
			case "btnA":			
				player.indexShot = 1;				
			break;		

			case "btnB":
				player.indexShot = 0;				
				break;

		}
	
	}

	public void gameOver(string idTela) {
		Application.LoadLevel (idTela);
	}

}
