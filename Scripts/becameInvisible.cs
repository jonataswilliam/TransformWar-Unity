using UnityEngine;
using System.Collections;

public class becameInvisible : MonoBehaviour {
	void OnBecameInvisible() {
		Destroy (this.gameObject);
	}

}
