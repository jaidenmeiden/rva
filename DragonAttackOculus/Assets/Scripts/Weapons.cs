using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{

	// Inicializamos las variables
	public GameObject rightHand, leftHand;
	// Inicializamos las posiciones anteriores de las manos
	Vector3 lastPositionRight, lastPositionLeft;

	// Creamos los Game objects para manipular los objetos definidos en cada mano
	public GameObject leftWeapon, rightWeapon, rightWeaponAlternative, magicLaunchPoint;
	// Creamos los Game objects para lanzar magia
	public GameObject currentMagic, fireMagic;

	// Definimos los tiempos de cambio de arma, ocultar escudo y lanzar magia
	public float weaponCooldown, magicCooldown = 0.0f;
	// Tiempos de recarga para evitar el salto continuo para armas y magia
	public const float WEAPON_COOLDOWN_TIME = 0.5f;
	public const float MAGIC_COOLDOWN_TIME = 2.0f;

	// Definimos si esta activo o no el escudo
	public bool shieldActive = false;

	// Click de audio de lanzamiento
	public AudioClip fireClip;

	// Use this for initialization
	void Start()
	{
		rightWeaponAlternative.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		//Time.deltaTime es el tiempo que ha pasado desde la ultima vez que ucurrio un evento
		weaponCooldown += Time.deltaTime;
		magicCooldown += Time.deltaTime;		

		// Movimiento escudo para defensa. Se valida si tengo presionada la tecla
		// y si esta tengo escudo en el juego
		if (Input.GetKeyDown(KeyCode.LeftArrow) && leftWeapon.activeInHierarchy)
		{
			shieldActive = true;
		} else
        {
			shieldActive = false;
		}

		// Cambio de arma. Se valida si pulso la tecla 'RightArrow' y ha pasado más del
		// tiempo necesario para que no se vea un salto rapido, se cambia el arma.
		if (Input.GetKeyDown(KeyCode.RightArrow) && weaponCooldown > WEAPON_COOLDOWN_TIME)
		{
			weaponCooldown = 0;
			// Se cambia estado de armas
			rightWeapon.SetActive(!rightWeapon.activeInHierarchy);
			rightWeaponAlternative.SetActive(!rightWeaponAlternative.activeInHierarchy);

			// Si el activo es la lanza le asignamos la magia, sino se destruye
			if (rightWeaponAlternative.activeInHierarchy)
			{
				LoadMagic();
			}
			else
			{
				Destroy(currentMagic);
			}
		}

		// Lanza magia si la lanza esta seleccionada
		if (Input.GetKeyDown(KeyCode.UpArrow) && magicCooldown > MAGIC_COOLDOWN_TIME)
		{
			if (currentMagic != null)
			{
				magicCooldown = 0;

				Debug.Log("Usando " + rightHand.transform.position + "!");

				// Velocidad a la que el usuario mueve la mano derecha multiplicado por un incremento
				/*Vector3 force = 20.0f * (rightHand.transform.position -
									   lastPositionRight) / Time.deltaTime;*/
				
				Vector3 force = 20.0f * (new Vector3(0.0f, 0.0f, -1.553f));

				Debug.Log("Usando " + force + "!");

				// Desacoplamos la boal de fuego
				currentMagic.transform.parent = null;
				// Quitamos las restricciones del bloqueo en el Rigidbody.
				// Dichas restricciones fueron ingresadas previamente
				currentMagic.GetComponent<Rigidbody>().constraints =
					RigidbodyConstraints.None;
				// Aplicamos la fuerza de lanzamiento en forma de impulso  a la bala
				currentMagic.GetComponent<Rigidbody>().
							AddForce(force, ForceMode.Impulse);

				// Agregamos el sonido de lanzamiento
				currentMagic.GetComponent<AudioSource>().PlayOneShot(fireClip);

				// Invocamos cada recarga de la magia despues de ser lanzada
				Invoke("LoadMagic", MAGIC_COOLDOWN_TIME);
			}

		}

		// Ocultar escudo. Se valida si pulso la tecla 'DownArrow' y ha pasado más del
		// tiempo necesario para que no se vea un salto rapido, se oculta o mustra el escudo.
		if (Input.GetKeyDown(KeyCode.DownArrow) && weaponCooldown > WEAPON_COOLDOWN_TIME)
		{
			weaponCooldown = 0;
			// Se cambia estado de escudo
			leftWeapon.SetActive(!leftWeapon.activeInHierarchy);
		}


		lastPositionRight = rightHand.transform.position;
		lastPositionLeft = leftHand.transform.position;
	}

	void LoadMagic()
	{
		// Si ya hay una magia asignada la destruimos
		if (currentMagic != null)
		{
			Destroy(currentMagic);
		}
		// Creamos una nuva instancia de la magia en la transformación del objeto respentivo
		currentMagic = Instantiate(fireMagic, magicLaunchPoint.transform);
	}
}
