using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] private Projectile projectile;
	[SerializeField] private Transform muzzleMount;
	public void Fire()
	{
		GameObject.Instantiate(projectile, muzzleMount.position, muzzleMount.rotation).GetComponent<Projectile>().Fire(muzzleMount.forward);
	}
    
}
