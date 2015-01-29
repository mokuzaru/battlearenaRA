using UnityEngine;
using System.Collections;

public class Flecha : MonoBehaviour {
	
	void Start () {
		//transform.rotation.eulerAngles = Quaternion.Euler (new Vector3(90,0,0));
		//transform.eulerAngles = new Vector3 (90,0,-60);
		Invoke ("autodestruir",2f);
	}

	void Update () {
		transform.Translate (new Vector3(0,0.2f,0f));
	}

	void autodestruir(){
		Destroy (gameObject);
	}
}
