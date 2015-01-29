using UnityEngine;
using System.Collections;

public class Inputs : MonoBehaviour {

	public static bool saltarEsPresionado;
	public static bool caminarEsPresionado;
	public static bool retrocederEsPresionado;
	public static bool derechaEsPresionado;
	public static bool izquierdaEsPresionado;

	public static bool golpearEsPresionado;
	public static bool colisionEsActiva;

	public static GameObject enemigoActual;
	public static Vector3 rotacion;

	void Start () {
		rotacion = new Vector3 (0,45,0);
	}

	void Update () {
		//detectarTeclado();
		detectarMouse ();
	}

	void detectarTeclado(){
		if(Input.GetKey(KeyCode.W)){
			caminarEsPresionado = true;
		}
		if(Input.GetKey(KeyCode.S)){
			retrocederEsPresionado = true;
		}
		if(Input.GetKey(KeyCode.Space)){
			saltarEsPresionado = true;
		}
		if(Input.GetKey(KeyCode.A)){
			izquierdaEsPresionado = true;
		}
		if(Input.GetKey(KeyCode.D)){
			derechaEsPresionado = true;
		}
	}

	void detectarMouse(){rotacion = JoyStick.rotacion;
		if(JoyStick.presionActiva){
			//rotacion = JoyStick.rotacion;
			caminarEsPresionado = true;
		}else{

		}
	}

	public static void limpiarInputs(){
		saltarEsPresionado = false;
		caminarEsPresionado = false;
		retrocederEsPresionado = false;
		derechaEsPresionado = false;
		izquierdaEsPresionado = false;
		golpearEsPresionado = false;
	}
}
