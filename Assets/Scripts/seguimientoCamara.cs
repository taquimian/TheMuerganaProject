using UnityEngine;
using System.Collections;

public class seguimientoCamara : MonoBehaviour {

	private GameObject Personaje;
	public float cameraVel = 4.0f;

	// Use this for initialization
	void Start () {
		Personaje = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (GameInit.gameIsPlaying == true) {
			//seguimiento de la posicion X
			Vector3 camPos = transform.position;

			transform.position = Vector3.Lerp (transform.position, camPos, 3 * Time.fixedDeltaTime);
			if (ControlPersonaje.mirarDerecha == true) {
				camPos.x = Personaje.transform.position.x + 2.0f;
			} else{
				camPos.x = Personaje.transform.position.x - 2.0f;
					}

			//seguimiento de la posicion Y
			camPos.y = Personaje.transform.position.y + 2;
			transform.position = Vector3.Lerp (transform.position, camPos, 7.0f * Time.fixedDeltaTime);
		
		} else {
			Vector3 deathCamPos = transform.position;
			deathCamPos.x = Personaje.transform.position.x;
			transform.position = Vector3.Lerp (transform.position, deathCamPos, 2.0f * Time.fixedDeltaTime);
		}
	}
}
