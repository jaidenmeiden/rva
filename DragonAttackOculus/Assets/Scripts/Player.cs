using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	int orden;
	// Velocidad de movimiento
	public float speed;

	// Start is called before the first frame update
	void Start()
    {
		orden = 0;
		speed = 10f;
	}

    // Update is called once per frame
    void Update()
    {
		Vector3 pos = this.transform.position;

		if (Input.GetKeyDown(KeyCode.R))
		{
			orden = 0;
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			orden = 1;
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			orden = 2;
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			orden = 3;
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
			orden = 4;
		}
		if (Input.GetKeyDown(KeyCode.Q))
		{
			orden = 5;
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			orden = 6;
		}

		if (orden == 1)
        {
			pos.z -= speed * Time.deltaTime;
			if (pos.z <= -250)
            {
				orden = 2;
			}
		} else if (orden == 2)
		{
			pos.z += speed * Time.deltaTime;
			if (pos.z >= 250)
			{
				orden = 1;
			}
		} else if (orden == 3)
		{
			pos.x -= speed * Time.deltaTime;
			if (pos.x <= -250)
			{
				orden = 4;
			}
		} else if (orden == 4)
		{
			pos.x += speed * Time.deltaTime;
			if (pos.x >= 250)
			{
				orden = 3;
			}
		} else if (orden == 5)
		{
			pos.y -= speed * Time.deltaTime;
			if (pos.x + 1 <= 0)
			{
				orden = 6;
			}
		} else if (orden == 6)
		{
			pos.y += speed * Time.deltaTime;
			if (pos.x >= 150)
			{
				orden = 5;
			}
		}

		this.transform.position = pos;
	}
}
