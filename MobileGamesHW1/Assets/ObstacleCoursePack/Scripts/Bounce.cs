using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
	public float force = 100f; //Force 10000f
	public float stunTime = 0.5f;
	private Vector3 hitDir;

	void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			Debug.DrawRay(contact.point, contact.normal * 10, Color.red);
			if (collision.gameObject.tag == "Player")
			{
				collision.gameObject.GetComponent<Rigidbody>().AddForce(-contact.normal * force, ForceMode.Impulse);
				return;
			}
		}

	}
}
