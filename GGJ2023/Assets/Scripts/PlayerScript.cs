using DevKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	int invincibilityFrames = 3;
	HealthManager healthManager;
	BoxCollider2D collision;
	[SerializeField] LayerMask layerMask;
	[SerializeField] GameObject UIMouse;

	public bool hasOrb = false;

	private void Start()
	{
		healthManager = GetComponent<HealthManager>();
		collision = GetComponent<BoxCollider2D>();

		MusicManager.instance.SwitchTrack("Main");
		AudioManager.instance.PlayOneShot("Spawn");
	}

	public void Update()
	{
		CheckFog();
	}

	void CheckFog()
    {
		Vector3 pos = transform.position;
		Vector3 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - pos).normalized;
		dir.z = 0;
		dir.Normalize();
		RaycastHit2D hit = Physics2D.Raycast(pos, dir, 1, layerMask);

		if (hit)
		{
			if (hit.collider.gameObject.tag == "Fog" && UIManager.instance.GetMana() >= 10)
			{
				UIMouse.SetActive(true);
				if (Input.GetKeyDown(KeyCode.F))
				{
					Destroy(hit.collider.gameObject);
					UIManager.instance.RemoveMana(10);
					UIMouse.SetActive(false);
				}
			}
			else
			{
				UIMouse.SetActive(false);
			}
		}
    }

	public IEnumerator TakeDamage(int d)
	{
		healthManager.TakeDamage(d);
		Physics2D.IgnoreLayerCollision(7, 8, true);
		
		yield return new WaitForSeconds(invincibilityFrames);

		Physics2D.IgnoreLayerCollision(7, 8, false);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ManaOrb")
        {
			Destroy(collision.gameObject);
			//Add Sound
			UIManager.instance.AddMana();
			AudioManager.instance.PlayOneShot("PickupMana");
        }
		if(collision.gameObject.tag == "LifeOrb")
        {
			Destroy(collision.gameObject);
			hasOrb = true;
			AudioManager.instance.PlayOneShot("PickupOrb");
		}
    }
}
