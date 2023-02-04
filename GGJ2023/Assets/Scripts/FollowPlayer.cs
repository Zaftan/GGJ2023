using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
	Vector3 pos;

	private void FixedUpdate()
	{
		pos = player.transform.position;
		pos.z = -1;

		transform.position = pos;
	}
}
