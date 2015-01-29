using UnityEngine;
using System.Collections;

public class TottemDisparador : MonoBehaviour {

	public int _estado = 0;
	public GameObject _flecha;
	public bool invokeActivo = false;
	public float rangoRepeticion;

	// 0 nada
	// 1 disparar3

	public int vida;

	void Start () {
		InvokeRepeating("lanzarFlecha", 1.5f, rangoRepeticion);
	}
	

	void Update () {
		if(transform.parent.transform.GetComponent<Tottem>()._estado == 3){
			invokeActivo = true;
		}else{
			invokeActivo = false;
		}
	}

	void lanzarFlecha(){
		if(invokeActivo){
			GameObject tag = Instantiate(_flecha, transform.position, Quaternion.identity) as GameObject;
			//tag.transform.parent = transform;
			/*tag.transform.eulerAngles = new Vector3 (0,0,0);
			tag.transform.localEulerAngles = new Vector3(0,0,0);*/
			tag.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y,-transform.rotation.eulerAngles.z));
		}
	}
}
