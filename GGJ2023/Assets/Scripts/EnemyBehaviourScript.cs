using DevKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{
	[SerializeField] GameObject enemy;
    GameObject player;
    float speed = 2f;
	int health = 2;
	int attack = 2;
	bool move = true;

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
		if(move)
		{
			Vector2 direction = player.transform.position - transform.position;
			direction.Normalize();

			transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
		}
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
			UIManager.instance.SetKillGUI();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		string tag = collision.gameObject.tag;
		if (tag == "Player")
		{
			move = false;
			StartCoroutine(collision.gameObject.GetComponent<PlayerScript>().TakeDamage(attack));
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		string tag = collision.gameObject.tag;
		if (tag == "Player")
		{
			move = true;
		}
	}
}