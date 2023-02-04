using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
	float speed = 0.2f;
	Vector3 direction;

	private void FixedUpdate()
	{
		transform.Translate(direction * speed);
	}

	public void SetSpeed(float s)
	{
		speed = s;
	}

	public void SetDirection(Vector3 dir)
	{
		direction = dir;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		string tag = collision.gameObject.tag;
		if (tag == "Fog")
		{
			//Do nothing
		}
		if (tag == "Wall")
		{
			//Do nothing
		}
		if (tag == "Enemy")
		{
			collision.gameObject.GetComponent<EnemyBehaviourScript>().TakeDamage();
		}
		Destroy(gameObject);
	}
}
