using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
	
	private Vector3 MoveVector = Vector3.zero;
	private CharacterController ControlPersonaje;
	private float SpeedVertical;
	public float gravity = 10;
	public float jumpForce = 30;
	public float moveSpeed = 6;
	public float runSpeed = 30;
	
	void Start () {
		ControlPersonaje = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Camera.main == null)
			return;
		
		InputMotion();
		Motor ();
	}
	
	void InputMotion(){
		var h = Input.GetAxis ("Horizontal");
		var v = Input.GetAxis ("Vertical");
		MoveVector = Vector3.zero;
		MovHorizontal(h,v);
	}
	void MovHorizontal(float h, float v){
		float deadZone = 0.2f;
		if(v > deadZone || v < -deadZone || h > deadZone || h < -deadZone){
			
			MoveVector = new Vector3(h,0,v);
			
		}
	}
	void Motor (){
		MoveVector = Vector3.Normalize(MoveVector);
		
		if(Input.GetKey(KeyCode.LeftShift))
			MoveVector *= runSpeed;
		else
			MoveVector *= moveSpeed;
		MoveVector *= Time.deltaTime;
		ControlPersonaje.Move (MoveVector);
	}
}










