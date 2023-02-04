using DevKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	int invincibilityFrames = 3;
	HealthManager healthManager;
	BoxCollider2D collision;

	private void Start()
	{
		healthManager = GetComponent<HealthManager>();
		collision = GetComponent<BoxCollider2D>();
	}

	public void Update()
	{
		transform.rotation = LookAt2D.LookAtMouse(transform);
	}

	public IEnumerator TakeDamage(int d)
	{
		healthManager.TakeDamage(d);
		collision.enabled = false;
		
		yield return new WaitForSeconds(invincibilityFrames);

		collision.enabled = true;
	}
}
