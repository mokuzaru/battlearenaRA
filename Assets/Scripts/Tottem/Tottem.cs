using UnityEngine;
using System.Collections;

public class Tottem : MonoBehaviour {

	public int _estado = 1;
	public GameObject _objetivo;
	// 0 no iniciado
	// 1 giro

	public int _vida;
	public GameObject _efecto1;
	public int contadorMuerte = 0;

	void Start () {
	
	}

	void Update () {
		if(_estado == 1){
			animacion1();
		}else if(_estado == 2){
			animacion2();
		}else if(_estado == 3){
			animacion3();
		}
		calcularVida ();
	}

	void animacion1(){
		transform.Rotate (new Vector3(0,1,0));
	}

	void animacion2() {
		transform.Rotate (new Vector3(0,5,0));
	}

	void animacion3(){
		transform.LookAt (new Vector3(_objetivo.transform.position.x,transform.position.y,_objetivo.transform.position.z));
	}

	void calcularVida(){
		if(_vida <= 0){
			if(contadorMuerte == 0)
			Instantiate(_efecto1,transform.position,Quaternion.identity);
			contadorMuerte++;
			if(contadorMuerte >= 100){
				Destroy(gameObject);
			}
		}
	}
}
