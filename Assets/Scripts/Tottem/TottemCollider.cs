using UnityEngine;
using System.Collections;

public class TottemCollider : MonoBehaviour {

	public int _tipo;
	// 1 largo

	void OnTriggerEnter(Collider obj){
		if(obj.CompareTag("Inca"))
		transform.parent.GetComponent<Tottem> ()._estado = 2;
	}

	void OnTriggerExit(Collider obj){
		if(obj.CompareTag("Inca"))
		transform.parent.GetComponent<Tottem> ()._estado = 1;
	}
}
