using UnityEngine;
using System.Collections;

public class colliderInca : MonoBehaviour {
	
	void OnTriggerStay(Collider obj){
		if(obj.CompareTag("Enemigo")){
			Inputs.colisionEsActiva = true;
			Inputs.enemigoActual = obj.gameObject;
		}
	}

	void OnTriggerExit(Collider obj){
		if(obj.CompareTag("Enemigo")){
			Inputs.colisionEsActiva = false;
		}
	}
}
