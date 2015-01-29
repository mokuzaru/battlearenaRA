using UnityEngine;
using System.Collections;

public class JoyStick : MonoBehaviour {

	public static Vector3 rotacion;
	public static Quaternion rotacionq;
	public static bool presionActiva = false;
	public GameObject eje;
	public GameObject estirador;

	public GUITexture _guiButton1;

	void Start () {
	
	}

	void Update () {
		rotacion = new Vector3(0,eje.transform.rotation.eulerAngles.x,0);
		//capturarMouse ();
		capturarMouse ();
	}

	void capturarMousee(){
		if(Input.GetMouseButtonDown(0)){
			eje.transform.position = Input.mousePosition;
			/////////////////////////////////presionActiva = true;
		}else if(Input.GetMouseButton(0)){
			Vector3 relativePos = estirador.transform.position - transform.position;
			Quaternion rotation = Quaternion.LookRotation(relativePos);
			transform.rotation = rotation;



			/*rotacionq = eje.transform.rotation;

			estirador.transform.position = Input.mousePosition;
			eje.transform.lo(estirador.transform.position);
			float x = eje.transform.rotation.eulerAngles.x;*/
			//if(x <= 180f){ x = -x;}
			//rotacion = new Vector3(0,x,0);// Debug.Log (x);
		}else if(Input.GetMouseButtonUp(0)){
			presionActiva = false;
		}


	}

	void capturarMouse(){
		if(Input.GetMouseButton(0) && _guiButton1.HitTest(Input.mousePosition))
		{
			Inputs.golpearEsPresionado = true;
		}
	}

}
