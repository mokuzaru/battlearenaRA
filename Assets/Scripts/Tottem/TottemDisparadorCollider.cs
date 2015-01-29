using UnityEngine;
using System.Collections;

public class TottemDisparadorCollider : MonoBehaviour {

	void OnTriggerEnter(Collider obj){
		if(obj.CompareTag("Inca")){
			if(transform.parent.transform.parent.GetComponent<Tottem>()._estado == 2){Debug.Log("ne");
				transform.parent.transform.parent.GetComponent<Tottem>()._objetivo = obj.gameObject;
				transform.parent.transform.parent.GetComponent<Tottem>()._estado = 3;
			}
		}
	}

}
