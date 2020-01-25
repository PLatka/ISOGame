using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace UntitleGame
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private float moveSpeed = 1.0f;
		[SerializeField] private Weapon weapon;

		private InputAction action;
		public void Move(InputAction.CallbackContext context)
		{
			action = context.action;
		}


		private Vector3 MousePosition
		{
			get
			{
				Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit))
				{
					return hit.point;
				}
				else
				{
					return Vector3.zero;
				}
			}
		}

		public void Follow(InputAction.CallbackContext context)
		{
			Vector3 heading = MousePosition - transform.position;
			heading.y = 0;
			transform.rotation = Quaternion.LookRotation(heading.normalized, transform.up);

		}

		public void Shoot(InputAction.CallbackContext context)
		{
			weapon.Fire();
		}

		private Coroutine jumpRoutine;

		public void Jump(InputAction.CallbackContext context)
		{
			if(jumpRoutine == null) {
				jumpRoutine = StartCoroutine(JumpToLocation(MousePosition));	
			}
		}

		private IEnumerator JumpToLocation(Vector3 mousePosition)
		{
			const float MAX_TIME = 1.0f;
			float time = MAX_TIME;
			Vector3 startPosition = transform.position;
			while(time > 0.0f)
			{
				yield return new WaitForEndOfFrame();
				time -= Time.deltaTime;
				float t = time / MAX_TIME;
				Vector3 curPos = Vector3.Lerp(startPosition, mousePosition, 1-(t));

				float y = -4 * Mathf.Pow((t - 0.5f), 2) + 1;
				curPos.y = y;
				transform.position = curPos;
			}

			jumpRoutine = null;
		}

		private void Update()
		{
			if (action != null && jumpRoutine == null)
			{
				Vector2 input = action.ReadValue<Vector2>();
				if(input.magnitude > 0.1f)
				{
					Debug.Log(input);
					input = input * Time.deltaTime * moveSpeed;
					Vector3 position = transform.position;
					position = new Vector3(position.x + input.x, position.y, position.z + input.y) ;
					transform.position = position;
				}

			}
		}
	}
}
