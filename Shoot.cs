using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	public KeyCode shootKey = KeyCode.F;
	//public GameObject projectile;
	//public float shootForce;
	[SerializeField] Transform fireLocation;
	[SerializeField] GameObject arrow;
	[SerializeField] float disappearTime = 3f;


	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(shootKey))
		{
			/*GameObject shot = GameObject.Instantiate(projectile, transform.position, transform.rotation);
			shot.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);*/
			FireArrow();
		}
	}

	public void FireArrow()
	{
		GameObject newArrow = Instantiate(arrow) as GameObject;
		newArrow.transform.position = fireLocation.position;
		newArrow.transform.rotation = transform.rotation;
		newArrow.GetComponent<Rigidbody>().velocity = transform.forward * 25f;
		Destroy (newArrow, disappearTime);
	}
		
}