using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{

	// Initialize variables
	public GameObject rightHand, leftHand;
	// Initialize the previous of the hands
	Vector3 lastPositionRight, lastPositionLeft;

	// Create the game objects to manipulate the objects defined in each hand
	public GameObject leftWeapon, rightWeapon, rightWeaponAlternative, magicLaunchPoint;
	// Create the game objects to launch magic
	public GameObject currentMagic, fireMagic;

	// Define the times to change weapons, hide shield and cast magic
	public float weaponCooldown, magicCooldown = 0.0f;
	// Cooldown to prevent continuous jump for magic and weapons
	public const float WEAPON_COOLDOWN_TIME = 0.5f;
	public const float MAGIC_COOLDOWN_TIME = 2.0f;

	// Define if the shield is active or not
	public bool shieldActive = false;

	// Launch audio click
	public AudioClip fireClip;

	// Use this for initialization
	void Start()
	{
		rightWeaponAlternative.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		//Time.deltaTime is the time that has passed since the last time an event occurred
		weaponCooldown += Time.deltaTime;
		magicCooldown += Time.deltaTime;		

		// Left trigger (HTC_VIU_UnityAxis9) => Review class UnityEngineVRModule into HTC.UnityPlugin/VRModule/Modules (line 166)
		// Shield movement for defense. It is validated if I have pressed the key
		// and if the shield is in the game
		if (Input.GetAxis("HTC_VIU_UnityAxis9") > 0.1 && leftWeapon.activeInHierarchy)
		{
			shieldActive = true;
		} else
		{
			shieldActive = false;
		}
		
		//Right Grip (HTC_VIU_UnityAxis12) => Review class UnityEngineVRModule into HTC.UnityPlugin/VRModule/Modules (line 194)
		// Weapon change. It is validated if we press the 'RightArrow' key and more than the
		// necessary time has passed so that a quick jump is not seen, the weapon is changed.
		if (Input.GetAxis("HTC_VIU_UnityAxis12") > 0.1 && weaponCooldown > WEAPON_COOLDOWN_TIME)
		{
			weaponCooldown = 0;
			// Weapons status changed
			rightWeapon.SetActive(!rightWeapon.activeInHierarchy);
			rightWeaponAlternative.SetActive(!rightWeaponAlternative.activeInHierarchy);

			// If the active weapon is the spear we assign the magic, otherwise it is destroyed
			if (rightWeaponAlternative.activeInHierarchy)
			{
				LoadMagic();
			}
			else
			{
				Destroy(currentMagic);
			}
		}
		
		//Right trigger => Review class UnityEngineVRModule into HTC.UnityPlugin/VRModule/Modules (line 167)
		// Cast magic if the spear is selected
		if (Input.GetAxis("HTC_VIU_UnityAxis10") > 0.1 && magicCooldown > MAGIC_COOLDOWN_TIME)
		{
			if (currentMagic != null)
			{
				magicCooldown = 0;

				Debug.Log("Usando " + rightHand.transform.position + "!");

				// Speed at which the user moves the right hand multiplied by an increment
				/*Vector3 force = 20.0f * (rightHand.transform.position -
									   lastPositionRight) / Time.deltaTime;*/
				
				Vector3 force = 20.0f * (new Vector3(0.0f, 0.0f, -1.553f));

				Debug.Log("Usando " + force + "!");

				// Undock the fireball
				currentMagic.transform.parent = null;
				// We remove the lock restrictions on the Rigidbody.
				// Said restrictions were previously entered
				currentMagic.GetComponent<Rigidbody>().constraints =
					RigidbodyConstraints.None;
				// We apply the launch force in the form of an impulse to the bullet
				currentMagic.GetComponent<Rigidbody>().
					AddForce(force, ForceMode.Impulse);

				// Add launch sound
				currentMagic.GetComponent<AudioSource>().PlayOneShot(fireClip);

				// We invoke each recharge of the magic after it is cast
				Invoke("LoadMagic", MAGIC_COOLDOWN_TIME);
			}

		}

		//Left Grip (HTC_VIU_UnityAxis11) => Review class UnityEngineVRModule into HTC.UnityPlugin/VRModule/Modules (line 193)
		// Hide shield. It is validated if we press the 'DownArrow' key and more than the necessary
		// time has passed so that a quick jump is not seen, the shield is hidden or shown.
		if (Input.GetAxis("HTC_VIU_UnityAxis11") > 0.1 && weaponCooldown > WEAPON_COOLDOWN_TIME)
		{
			weaponCooldown = 0;
			// Shield status changed
			leftWeapon.SetActive(!leftWeapon.activeInHierarchy);
		}


		lastPositionRight = rightHand.transform.position;
		lastPositionLeft = leftHand.transform.position;
	}

	void LoadMagic()
	{
		// If there is already a magic assigned, we destroy it
		if (currentMagic != null)
		{
			Destroy(currentMagic);
		}
		// We create a new instance of the magic in the transformation of the respective object
		currentMagic = Instantiate(fireMagic, magicLaunchPoint.transform);
	}
}
