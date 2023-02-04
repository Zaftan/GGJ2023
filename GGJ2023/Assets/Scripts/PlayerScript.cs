using DevKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public void Update()
	{
		transform.rotation = LookAt2D.LookAtMouse(transform);
	}
}
