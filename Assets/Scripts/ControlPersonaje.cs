using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPersonaje : MonoBehaviour {

	//Variables
	public float velCorrer;
	public float velCaminar;
	public static bool mirarDerecha;

	Rigidbody playerRig;
	Animator playerAnim;




	// Use this for initialization
	void Start () {
		//Obtenemos los componentes del rigidbody y animator del personaje
		playerRig = GetComponent<Rigidbody>();
		playerAnim = GetComponent<Animator> ();
		mirarDerecha = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		//Obtenemos los movimientos en horizontal de los botones
		//Obtiene el parametro "velocidad" del Animator
		float movimiento = Input.GetAxis ("Horizontal");
		playerAnim.SetFloat ("Velocidad", Mathf.Abs (movimiento));

		//Fire 3 es igual al boton shift
		//Obtiene el parametro "Shift" que se usa para correr del Animator
		float shiftRun = Input.GetAxisRaw("Fire3");
		playerAnim.SetFloat ("Shift", shiftRun);

		//Movimiento conforme a la velocidad dada
		if(shiftRun > 0) {
			playerRig.velocity = new Vector3 (movimiento * velCorrer, playerRig.velocity.y, 0);
		} else {
			playerRig.velocity = new Vector3 (movimiento * velCaminar, playerRig.velocity.y, 0);
		}
			
		//Condicion para el cambio de sentido del personaje
		if (movimiento > 0 && !mirarDerecha)
			darVuelta();
		else if (movimiento < 0 && mirarDerecha)
			darVuelta();
	}

	public void darVuelta(){
		//Se cambian el uno al otro-->Derecha<--Izquierda
		mirarDerecha = !mirarDerecha;
		//Tomamos el valor del tamaño "z" para invertirlo
		Vector3 tamaño = transform.localScale;
		tamaño.z *= -1;
		//Seteamos el nuevo tamaño en z
		transform.localScale = tamaño;

	}
}
