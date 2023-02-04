using DevKit;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttackScript : MonoBehaviour
{
	[SerializeField] GameObject bullet;

	int currentAmmo, maxAmmo, waitInSeconds;
	float bulletSpeed;

	private void Start()
	{
		currentAmmo = 5;
		maxAmmo = 5;
		waitInSeconds = 3;
		bulletSpeed = 0.5f;

		UpdateAmmoGUI();
	}

	public void Shoot()
    {
		Vector3 pos = transform.position;
		Vector3 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - pos).normalized;
		dir.z = 0;
		dir.Normalize();
		GameObject b = Instantiate(bullet, pos, Quaternion.identity);
		b.GetComponent<BulletBehaviour>().SetDirection(dir);

		currentAmmo--;
		UpdateAmmoGUI();

		if(currentAmmo <= 0)
		{
			Reload();
		}
	}

	void Reload()
	{
		//Feedback
		//wait time
		currentAmmo = maxAmmo;
		UpdateAmmoGUI();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		string tag = collision.gameObject.tag;
		if (tag == "Enemy")
		{
			Debug.Log("E");
		}
	}

		void UpdateAmmoGUI()
	{
		UIManager.instance.SetAmmoGUI(currentAmmo, maxAmmo);
	}
}