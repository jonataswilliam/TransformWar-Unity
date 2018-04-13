using UnityEngine;
using System.Collections;

public class move_offset_bg : MonoBehaviour {


	private Material currentMaterial;
	public float speed;
	private float offset;

	// Use this for initialization
	void Start () {

		// Carrega o material do componente e armazena na variavel 
		currentMaterial = GetComponent<MeshRenderer> ().material;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		offset += speed * Time.deltaTime;

		currentMaterial.SetTextureOffset ("_MainTex", new Vector2 (offset, 0));
	}
}
