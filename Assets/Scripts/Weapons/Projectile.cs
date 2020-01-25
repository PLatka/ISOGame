using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] Rigidbody myRigidBody;
	[SerializeField] float forceMultiplier = 300.0f;
	private Rigidbody MyRigidBody
	{
		get
		{
			if(myRigidBody == null)
			{
				myRigidBody = GetComponentInChildren<Rigidbody>();
			}
			return myRigidBody;
		}
	}
    public void Fire(Vector3 forward)
	{
		if(MyRigidBody == null)
		{
			return;
		}

		myRigidBody.AddForce(forward * 1.0f, ForceMode.Impulse);
	}

	private void OnCollisionEnter(Collision collision)
	{
		Destroy(gameObject);
	}
}
