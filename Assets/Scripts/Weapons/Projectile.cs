using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] private Rigidbody myRigidBody;
	[SerializeField] private float forceMultiplier = 300.0f;
	[SerializeField] private float duration = 5.0f;
	[SerializeField] private ForceMode forceMode = ForceMode.Impulse;
	private void Awake()
	{
		Destroy(gameObject, duration);
	}

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

		myRigidBody.AddForce(forward * forceMultiplier, forceMode);
	}

	private void OnCollisionEnter(Collision collision)
	{
		Destroy(gameObject);
	}
}
