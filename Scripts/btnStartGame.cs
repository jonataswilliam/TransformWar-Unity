using UnityEngine;
using System.Collections;

public class btnStartGame : MonoBehaviour {

	public string botao;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTouchDown () {
		switch (botao) {
		case "btnStart":
			Application.LoadLevel ("fase_1");


			break;
		}
	}
}
