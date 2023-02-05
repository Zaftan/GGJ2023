using DevKit;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerAttackScript : MonoBehaviour
{
	[SerializeField] GameObject bullet;

	int currentAmmo, maxAmmo;
	float bulletSpeed, waitInSeconds;
	bool reload = false;

	private void Start()
	{
		currentAmmo = 5;
		maxAmmo = 5;
		waitInSeconds = 1.5f;
		bulletSpeed = 0.5f;

		UpdateAmmoGUI();
	}

	public void Shoot()
    {
		if (currentAmmo > 0 && reload != true)
		{
			Vector3 pos = transform.position;
			Vector3 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - pos).normalized;
			dir.z = 0;
			dir.Normalize();
			GameObject b = Instantiate(bullet, pos, Quaternion.identity);
			b.GetComponent<BulletBehaviour>().SetDirection(dir);
			currentAmmo--;
			UpdateAmmoGUI();
			AudioManager.instance.PlayOneShot("Shoot");
		}
		else if(currentAmmo <= 0 && reload == false)
		{
			reload = true;
			StartCoroutine(Reload());
		}
	}

	IEnumerator Reload()
	{
		//Feedback
		yield return new WaitForSeconds(waitInSeconds);
		currentAmmo = maxAmmo;
		UpdateAmmoGUI();
		reload = false;
	}

	void UpdateAmmoGUI()
	{
		UIManager.instance.SetAmmoGUI(currentAmmo, maxAmmo);
	}
}