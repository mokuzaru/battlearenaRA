using UnityEngine;
using System.Collections;

public class IA_Inca : MonoBehaviour {

	public float _velocidadCaminar;
	public float _velocidadRetroceder;
	public int _movimiento = 0;
	// 0 idle
	// 1 caminar
	// 2 retroceder
	// 3 derecha
	// 4 izquierda

	public int _animacion;
	// 0 idle
	// 1 caminar
	// 2 correr
	// 3 saltar
	// 50 ataque1

	public int _direccion;
	// 1 arriba
	// 2 derecha
	// 3 abajo
	// 4 izquierda
	// 5 derecha-arriba
	// 6 derecha-abajo
	// 7 izquierda-abajo
	// 8 izquierda-arriba

	public Vector3 _rotacionInicial;
	private Vector3 MoveVector = Vector3.zero;
	private Animator _animator;

	public GameObject _efecto1;
	public GameObject _mano1;
	public int contadorEfecto = 0;

	public CharacterController _character;




	public Vector3 moveDirection = Vector3.zero;
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	void Start () {
		_rotacionInicial = transform.rotation.eulerAngles;
		_animator = GetComponent<Animator>();
		_character = GetComponent<CharacterController> ();
	}

	void Update () {
		limpiarControles();
		obtenerControles();
		ejecutarMovimientos();
		contadorEfecto++;




		/*CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);*/
	}

	void obtenerControles(){
		if(Inputs.caminarEsPresionado){
			_movimiento = 1;
			_direccion = 1;
		}
		if(Inputs.retrocederEsPresionado){
			_movimiento = 1;
			_direccion = 3;
		}
		if(Inputs.derechaEsPresionado){
			_movimiento = 1;
			_direccion = 2;
		}
		if(Inputs.izquierdaEsPresionado){
			_movimiento = 1;
			_direccion = 4;
		}
		if(Inputs.caminarEsPresionado && Inputs.derechaEsPresionado){
			_movimiento = 1;
			_direccion = 5;
		}
		if(Inputs.retrocederEsPresionado && Inputs.derechaEsPresionado){
			_movimiento = 1;
			_direccion = 6;
		}
		if(Inputs.caminarEsPresionado && Inputs.izquierdaEsPresionado){
			_movimiento = 1;
			_direccion = 8;
		}
		if(Inputs.retrocederEsPresionado && Inputs.izquierdaEsPresionado){
			_movimiento = 1;
			_direccion = 7;
		}
		if(Inputs.golpearEsPresionado){
			_movimiento = 0;
			_animacion = 50;
			logicaGolpear();
		}else{
			_animacion = 0;
		}
		Inputs.limpiarInputs ();
	}

	void ejecutarMovimientos(){
		if(_movimiento == 1){
			logicaCaminar();
			ejecutarAnimacion(1);
		}else{
			ejecutarAnimacion(_animacion);
		}
	}

	void logicaCaminar(){
		/*Vector3 moveDirection = Vector3.zero;
		moveDirection = new Vector3 (0,0,1f*_velocidadCaminar);
		moveDirection =	 transform.TransformDirection(moveDirection);
		moveDirection *= Time.deltaTime;
		_character.Move (moveDirection);*/


		//Vector3 forward = transform.TransformDirection(Vector3.forward);
		//_character.SimpleMove (forward*Time.deltaTime*_velocidadCaminar);

		//transform.Translate(Vector3.forward*Time.deltaTime*_velocidadCaminar);
		//transform.Translate (new Vector3(0f,0,0.f));
		//transform.Translate(Vector3.up * Time.deltaTime*5, Space.World);

		transform.Translate(new Vector3(0,0,_velocidadCaminar) * Time.deltaTime);
		//transform.Translate (new Vector3(0,0,0.2f));

		/*MoveVector = Vector3.Normalize(MoveVector);
		MoveVector *= _velocidadCaminar*80;
		MoveVector *= Time.deltaTime;

		GetComponent<CharacterController> ().Move (MoveVector);*/

		//logicaGirar ();
	}

	void logicaGirar(){
		/*if(i == 1){
			transform.rotation = Quaternion.Euler(0,0,0);
		}else if(i == 2){
			transform.rotation = Quaternion.Euler(0,90,0);
		}else if(i == 3){
			transform.rotation = Quaternion.Euler(0,180,0);
		}else if(i == 4){
			transform.rotation = Quaternion.Euler(0,270,0);
		}else if(i == 5){
			transform.rotation = Quaternion.Euler(0,45,0);
		}else if(i == 6){
			transform.rotation = Quaternion.Euler(0,135,0);
		}else if(i == 7){
			transform.rotation = Quaternion.Euler(0,225,0);
		}else if(i == 8){
			transform.rotation = Quaternion.Euler(0,315,0);
		}*/
		/*Quaternion q = new Quaternion ();
		q. = Inputs.rotacion;
		Transform t = transform;
		t.rotation = q;*/
		//= Quaternion.Euler(Inputs.rotacion);
		/*Quaternion qq = JoyStick.rotacionq;
		qq.eulerAngles.y = qq.eulerAngles.x;
		qq.eulerAngles.x = 0;
		qq.eulerAngles.z = 0;
		transform.rotation = qq;*/
		////////////////transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,Inputs.rotacion.y,transform.rotation.z);

		//Vector3 rotation = transform.localEulerAngles;
		//rotation.y = Inputs.rotacion.y;
		//transform.localEulerAngles = rotation;

		//transform.rotation = Quaternion.LookRotation ();
		//Debug.Log(transform.rotation.eulerAngles);
	}

	void logicaRetroceder(){
		transform.Translate(Vector3.back*Time.deltaTime*_velocidadRetroceder);
	}

	void logicaDerecha(){
		transform.Translate(Vector3.right*Time.deltaTime*_velocidadRetroceder);
	}

	void ejecutarAnimacion(int n){
		_animator.SetInteger ("_animacion",n);
	}

	void logicaGolpear(){
		if(Inputs.colisionEsActiva && contadorEfecto>=100){
			Instantiate (_efecto1,Inputs.enemigoActual.transform.position,Quaternion.identity);
			Inputs.enemigoActual.transform.parent.transform.GetComponent<Tottem>()._vida-=1;
			contadorEfecto = 0;
		}
	}

	void limpiarControles(){
		_movimiento = 0;
		JoyStick.presionActiva = false;
	}
}
