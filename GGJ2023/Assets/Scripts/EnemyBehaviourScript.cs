using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{
	[SerializeField] GameObject enemy;
    GameObject player;
    float speed = 2f;
	int health = 2;

	private void Start()
	{
        player = FindObjectOfType<PlayerScript>().gameObject;
	}


	void Update()
    {
        Move();
    }

	private void Move()
	{
		Vector2 direction = player.transform.position - transform.position;
		direction.Normalize();

		transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
	}

	public void TakeDamage()
	{
		if (health > 0)
		{
			health--;
		}
		else
		{
			Destroy(enemy);
		}
	}
}
